using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuadroSoft.Enose.DataModel;
using QuadroSoft.Enose.Dialogs;
using QuadroSoft.Enose.DataAccess;
using GUI;
using System.Threading;
using System.IO;
using QuadroSoft.Enose.Statistics;

namespace QuadroSoft.Enose
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Разложить графики сенсоров в соответствии с профилем
        /// </summary>
        /// <param name="profile1">профиль</param>
        public void stackPlotters(MeasureProfile profile1)
        {

            MeasureProfile profile = profile1 == null ? null : Program.DataProvider.getMeasureProfileByID(profile1.ID);

            try
            {
                Dictionary<int, Sensor> coll = new Dictionary<int, Sensor>();
                Dictionary<object, UserControl> newplotters = new Dictionary<object, UserControl>();

                if (profile != null)
                {
                    foreach (int key in profile.Settings.Keys)
                    {
                        string sid = profile.Settings[key].SID;
                        coll.Add(key, Program.DataProvider.getSensorBySID(sid));
                    }

                    profile.Settings = coll;

                    foreach (int pos in profile.Settings.Keys)
                    {
                        Plotter plt = new Plotter();
                        plt.CornerLabel = (pos + 1).ToString();
                        plt.Label = profile.Settings[pos].ToString();
                        plt.Adjusting = true;
                        plt.PenWidth = 2;
                        plt.DrawExtremum = true;
                        plt.BorderStyle = BorderStyle.FixedSingle;
                        plt.DrawVerticalBold = false;
                        plt.DrawBaseLine = true;
                        plt.Font = new Font("Courier New", 10);
                        plt.ReactOnScroll = false;
                        plt.BaseValue = profile.Settings[pos].PassportFrequency;
                        newplotters.Add(profile.Settings[pos], plt);
                      
                    }
                }

                multiGraph.initWGraph(newplotters, 450, 200, 2, 2);

            }
            catch (Exception ex) { Error.Log(ex); MessageBox.Show("Ошибка:\r\n" + ex.Message); }
        }

        /// <summary>
        /// Освежить комбобокс с профилями
        /// </summary>
        public void refreshComboProfiles()
        {
            comboBoxProfiles.Items.Clear();
            comboBoxProfiles.Items.AddRange(Program.DataProvider.getMeasureProfiles().ToArray());
            comboBoxProfiles.SelectedItem = Program.Presets.CurrentProfile;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                refreshComboProfiles();
                stackPlotters(Program.Presets.CurrentProfile);
                timer.Start();
            }
            catch (Exception ex) { Error.Log(ex); }
        }

        

        private void новоеИзмерениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxProfiles.Enabled = false;
            FormMeasureProfileSelect form = FormMeasureProfileSelect.getInstance(Program.Presets.CurrentProfile == null ? -1 : Program.Presets.CurrentProfile.ID);

            form.AdjustForTask(true);
            MeasureProfile applied;

            bool start = false;
            MeasureProfile p = Program.Presets.CurrentProfile;

            bool ok = true;


            if (form.ShowDialog() == DialogResult.OK)
                start = true;

            if (start)
            {
                ok = true;

                try
                {
                    if (p != null)
                    {
                        DateTime min, max;
                        Dictionary<Sensor, List<PointD>> toCheck = Program.Service.WinToData(Program.nose.getWindow(), Program.Presets.CurrentProfile, out min, out max);

                        foreach (Sensor key in toCheck.Keys)
                            ok &= Program.Service.checkOk(key, toCheck[key].ToArray()) == Program.Service.CHECK_STABLE;
                    }
                }
                catch (Exception ex) { Error.Log(ex); }

                if (ok || MessageBox.Show("Не все сенсоры стабильны. Вы всё равно хотите начать измерение?", "Нестабильность", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    Dictionary<DateTime, double[]> win = null;
                    if (Program.nose != null)
                        win = Program.nose.getWindow();

                    if (win == null || win.Count == 0)
                    {
                        MessageBox.Show("Неизвестная ошибка: всё пропало");
                        comboBoxProfiles.Enabled = true;
                        return;
                    }

                    applied = form.usedProfile;

                    
                    #region init values
                    /*
                    double[] init = new double[Program.nose.SensorCount];
                    int count = win.Count;
                    DateTime[] times = new DateTime[count];
                    win.Keys.CopyTo(times, 0);
                    DateTime last = times[times.Length - 1];

                    for (int i = 0; i < init.Length; i++) init[i] = 0d;

                    int c = 0;
                    ///!!!!! ТОНКО ТУТ ЕСЛИ НЕПРАВИЛЬНО - ФИКСИТЬ!!!!
                    for (int i = times.Length - 1; i >= 0 && (0d + last.Ticks - times[i].Ticks) / 1e7d < Program.Presets.stableTime; c++, i--)
                        for (int j = 0; j < Program.nose.SensorCount; j++)
                            init[j] += win[times[i]][j];

                    if (c > 0)
                        for (int i = 0; i < init.Length; i++) init[i] /= c;

                    double[] theinit = new double[applied.Settings.Count];

                    int ii = 0;
                    foreach (int pos in applied.Settings.Keys)
                        theinit[ii++] = (int)init[pos];
                    */
                    #endregion

                    double[] theinit = Program.Service.getInitValues(win, applied);

                    double len = (int)form.numericUpDownTime.Value;
                    string txt = form.textBoxName.Text;

                    FormMeasure meas = new FormMeasure(len, txt, applied, theinit, form.comboBoxMasks.SelectedItem as Mask);
                    meas.ShowDialog();
                    measureTree.ShowMeasures = measureTree.ShowMeasures;
                }
            }
            refreshComboProfiles();
            comboBoxProfiles.Enabled = true;
        }



        private void timer_Tick(object sender, EventArgs e)
        {

            if (Program.nose == null) return;
            if (Program.Presets.CurrentProfile == null) return;

            DateTime min, max;
            Dictionary<Sensor, List<PointD>> alldata = Program.Service.WinToData(Program.nose.getWindow(), Program.Presets.CurrentProfile, out min, out max);

            foreach (int pos in Program.Presets.CurrentProfile.Settings.Keys)
                try
                {
                    Sensor sensor = Program.Presets.CurrentProfile.Settings[pos];
                    RectangleD viewport = new RectangleD(-(max.Ticks - min.Ticks) / 10e6d, 100000, (max.Ticks - min.Ticks) / 10e6d + 0.5d, 200);

                    (multiGraph.Plotters[sensor] as Plotter).Viewport = viewport;

                    PointD[][] data = new PointD[1][];

                    data[0] = alldata[sensor].ToArray();

                    for (int i = 0; i < data[0].Length; i++)
                        data[0][i] = new PointD(data[0][i].X - data[0][data[0].Length - 1].X, data[0][i].Y);

                    //data[0] = new BezierLine(data[0], 0.5).GetPoints(4);

                    Color c = Color.White;

                    string note = "";
                    switch (Program.Service.checkOk(sensor, data[0]))
                    {
                        case Program.Service.CHECK_NO_SIGNAL:
                            note += "нет сигнала";
                            c = Color.Red;
                            break;
                        case Program.Service.CHECK_NOT_IN_PASSPORT:
                            note += "частота не соответствует паспорту";
                            c = Color.Red;
                            break;
                        case Program.Service.CHECK_NOT_STABLE:
                            note += "сенсор нестабилен";
                            c = Color.Yellow;
                            break;
                        case Program.Service.CHECK_STABLE:
                            note += "cенсор готов";
                            c = Color.Green;
                            break;
                    }
                    (multiGraph.Plotters[sensor] as Plotter).DownLabel = note;
                    (multiGraph.Plotters[sensor] as Plotter).Indicator = c;
                    (multiGraph.Plotters[sensor] as Plotter).Data = data;
                }
                catch { }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Program.nose.Dispose();
                Program.DataProvider.Disconnect();
                Program.writeConfig();
            }
            catch (Exception ex) { Error.Log(ex); }

        }

        private void созданиеМасокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateMask.Work();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void статистическаяОбработкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProcessMeasures fpm = new FormProcessMeasures();
            fpm.ShowDialog();
            measureTree.ShowMeasures = measureTree.ShowMeasures;
        }

        private void загрузитьИзXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "XML файлы|*.xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MeasureData m = null;
                try
                {
                    m = MeasureData.fromXML(File.ReadAllText(openFileDialog.FileName), Program.DataProvider.Masks, Program.DataProvider.SensorList);
                }
                catch (Exception ex) { Error.Log(ex); MeasureData.message = ex.Message; }

                if (m != null)
                {
                    FormViewMeasure.getFormForMeasure(m);
                }
                else
                {
                    MessageBox.Show("Ошибка чтения измерения: " + MeasureData.message);
                }
            }
        }

        private void выгрузитьВXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelectOneMeasure inst = FormSelectOneMeasure.Instance;
            if (inst.ShowDialog() == DialogResult.OK)
            {
                MeasureData data = inst.GetMeasureData();
                saveFileDialog.Filter = "XML файлы|*.xml";
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = "xml";
                if (data != null)
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        try
                        {
                            File.WriteAllText(saveFileDialog.FileName, data.toXML());
                        }
                        catch (Exception ex) { Error.Log(ex); MessageBox.Show("Ошибка сохранения: " + ex.Message); }
                }
                else
                    MessageBox.Show("Измерение не выбрано. Экспорт не будет произведён.");
            }
        }

        private void экспортВCSVutf8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelectOneMeasure inst = FormSelectOneMeasure.Instance;
            if (inst.ShowDialog() == DialogResult.OK)
            {
                MeasureData data = inst.GetMeasureData();
                saveFileDialog.Filter = "CSV файлы|*.csv";
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = "csv";
                if (data != null)
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        try
                        {
                            File.WriteAllText(saveFileDialog.FileName, data.ToCSV(data.DefaultMask));
                        }
                        catch (Exception ex) { Error.Log(ex); MessageBox.Show("Ошибка сохранения: " + ex.Message); }
                }
                else
                    MessageBox.Show("Измерение не выбрано. Экспорт не будет произведён.");
            }
        }

        private void редактированиеСенсоровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditSensors.Instance.Show();
            Program.DataProvider.getSensorList();
            Program.DataProvider.getMeasureProfiles();
            if (Program.Presets.CurrentProfile != null)
            {
                Program.Presets.CurrentProfile = Program.DataProvider.getMeasureProfileByID(Program.Presets.CurrentProfile.ID);
                stackPlotters(Program.Presets.CurrentProfile);
                comboBoxProfiles.SelectedItem = Program.Presets.CurrentProfile;
            }

        }

        private void экспортВCSVcp1251ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelectOneMeasure inst = FormSelectOneMeasure.Instance;
            if (inst.ShowDialog() == DialogResult.OK)
            {
                MeasureData data = inst.GetMeasureData();
                saveFileDialog.Filter = "CSV файлы|*.csv";
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = "csv";
                if (data != null)
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        try
                        {
                            string txt = data.ToCSV(data.DefaultMask);
                            StreamWriter sw = new StreamWriter(new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write), Encoding.GetEncoding(1251));
                            sw.Write(txt);
                            sw.Flush();
                            sw.Close();
                        }
                        catch (Exception ex) { Error.Log(ex); MessageBox.Show("Ошибка сохранения: " + ex.Message); }
                }
                else
                    MessageBox.Show("Измерение не выбрано. Экспорт не будет произведён.");
            }

            stackPlotters(Program.Presets.CurrentProfile);
        }

        private void comboBoxProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Presets.CurrentProfile = comboBoxProfiles.SelectedItem as MeasureProfile;
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            comboBoxProfiles.Enabled = true;
            try
            {
                comboBoxProfiles.SelectedItem = Program.Presets.CurrentProfile;
                stackPlotters(Program.Presets.CurrentProfile);
            }
            catch (Exception ex) { Error.Log(ex); }


//            measureTree.ShowMeasures = measureTree.ShowMeasures;
        }

        private void редактированиеПрофилейИзмеренийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMeasureProfileSelect form = FormMeasureProfileSelect.getInstance(Program.Presets.CurrentProfile == null ? -1 : Program.Presets.CurrentProfile.ID);
            comboBoxProfiles.Enabled = false;
            form.AdjustForTask(false);
            form.ShowDialog();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            comboBoxProfiles.Enabled = true;
        }
    }
}
