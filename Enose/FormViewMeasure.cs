using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuadroSoft.Enose.DataModel;
using QuadroSoft.Enose.DataAccess;
using QuadroSoft.Enose.Dialogs;
using System.IO;
using System.Drawing.Imaging;
using GUI;

namespace QuadroSoft.Enose
{
    public partial class FormViewMeasure : Form
    {
        private double zoom = 1.3d;

        private MeasureData measureData;
        private Mask mask;
        private bool saved;

        /// <summary>
        /// отобразить сводку по измерению
        /// </summary>
        public void ShowReport()
        {
           
            string name = "Название: " + measureData.Name + "\r\n";
            richTextBox.Text = "";
            richTextBox.SelectionFont = labelbld.Font;
            richTextBox.AppendText("Название: ");
            richTextBox.SelectionFont = labelnobld.Font;
            richTextBox.AppendText(measureData.Name + "\r\n");

            richTextBox.SelectionFont = labelbld.Font;
            richTextBox.AppendText("Начало измерения: ");
            richTextBox.SelectionFont = labelnobld.Font;
            richTextBox.AppendText(measureData.StartTime.ToString("dd/MM/yyyy HH:mm:ss") + "\r\n");
            richTextBox.AppendText( "-------------------\r\n");

            Dictionary<Sensor, double> st = measureData.StartValues;

            foreach (Sensor sen in measureData.AllData.Keys)
            {                
                richTextBox.SelectionFont = labelbld.Font;
                richTextBox.AppendText(sen.ToString() + ": \r\n");
                richTextBox.SelectionFont = labelnobld.Font;
                
                
                double max, maxt, min, mint, maxa, maxat;
                mint = maxt = maxat = -1d;
                
                min = double.MaxValue;
                max = double.MinValue;
                maxa = 0d;

                foreach (PointD p in measureData.AllData[sen])
                {
                    if (st[sen] - p.Y < min) { min = st[sen] - p.Y; mint = p.X; }
                    if (st[sen] - p.Y > max) { max = st[sen] - p.Y; maxt = p.X; }
                    if (Math.Abs(p.Y - st[sen]) > Math.Abs(maxa)) { maxa =st[sen] - p.Y; maxat = p.X; }
                }

                richTextBox.AppendText("    Базовая частота ν: " + st[sen].ToString("0.00") + " Гц\r\n");
                richTextBox.AppendText("    Минимум Δ: (" + mint.ToString("0.00") + " с; " + min.ToString("0.00") + " Гц)\r\n");
                richTextBox.AppendText("    Максимум Δ: (" + maxt.ToString("0.00") + " с; " + max.ToString("0.00") + " Гц)\r\n");
                richTextBox.AppendText("    Абс. максимум Δ: (" + maxat.ToString("0.00") + " с; " + maxa.ToString("0.00") + " Гц)\r\n");
            }
 
            if (measureData.DispData != null && measureData.DispData.Count > 0)
            {
                richTextBox.SelectionFont = labelbld.Font;
                richTextBox.AppendText("---------------------------\r\nЗначения доверительных интервалов:\r\n");
                richTextBox.SelectionFont = labelnobld.Font;

                Dictionary<Sensor, double> str = measureData.StartValues;

                foreach (Sensor s in measureData.DispData.Keys)
                {
                    richTextBox.SelectionFont = labelbld.Font;

                    richTextBox.AppendText(s.ToString() + ":\r\n");


                    double min = double.MaxValue;
                    double max = 0d;
                    double avg = 0d;

                    foreach (double d in measureData.DispData[s].Values)
                    {
                        if (max < d) max = d;
                        if (min > d) min = d;
                        avg += d;
                    }

                    avg /= measureData.DispData[s].Values.Count;
                    richTextBox.SelectionFont = labelbld.Font;
                    richTextBox.AppendText("  [минимум; ± " + min.ToString("0.00") + "]\r\n");
                    richTextBox.SelectionFont = labelbld.Font;
                    richTextBox.AppendText("  [максимум; ± " + max.ToString("0.00") + "]\r\n");
                    richTextBox.SelectionFont = labelbld.Font;
                    richTextBox.AppendText("  [среднее; ± " + avg.ToString("0.00") + "]\r\n");
                    richTextBox.SelectionFont = labelnobld.Font;

                    foreach (double d in measureData.DispData[s].Keys)
                    {
                        Dictionary<Sensor, double> di = measureData.GetDataAtTheMoment(measureData.StartTime.AddSeconds(d));
                                                
                        if (di.ContainsKey(s) && st.ContainsKey(s))
                            richTextBox.AppendText("    [" + d.ToString("0.00") + "; " + (str[s] - di[s]).ToString("0.00") + " ± " + measureData.DispData[s][d].ToString("0.00") + "]\r\n");
                    }
                }
            }
        }

        /// <summary>
        /// расставить сенсоры в чеклистбоксе
        /// </summary>
        /// <param name="md">измерение</param>
        private void setChecks(MeasureData md)
        {
            checkedListBoxSensors.Items.Clear();
            foreach (Sensor sensor in md.Data.Keys)
                checkedListBoxSensors.Items.Add(sensor, true);

        }

        /// <summary>
        /// Установить маску для измерения
        /// </summary>
        /// <param name="m">маска</param>
        private void setMask(Mask m)
        {
            if (comboBoxMask.Items.Contains(m))
                comboBoxMask.SelectedItem = mask = m;
        }

        /// <summary>
        /// Измерение, отображаемое в форме
        /// </summary>
        public MeasureData Data
        {
            get { return measureData; }
            set { measureData = value; setChecks(measureData); RePlot(); }
        }

        /// <summary>
        /// Выбранная маска
        /// </summary>
        public Mask Mask
        {
            get { return mask; }
            set { mask = value; setMask(mask);  RePlot(); }
        }

        /// <summary>
        /// Перестроение всех картинков
        /// </summary>
        private void RePlot()
        {
            if (Data == null || Mask == null)
            {
                plotterBox.Data = null;
                plotter.Data = null;
                plotterBoxMax.Data = null;
            }
            else
            {
                RectangleD viewport = plotter.Viewport;

                Dictionary<Sensor, double> init = measureData.StartValues;
                
                Measure measure = new Measure(Data, Mask, 0d);


                Dictionary<Sensor, List<PointD>> maskdata = measure.getMaskData();
                
                dataColors.RowCount = maskdata.Count;

                int w = 0;
                int u = 0;
                int k = 0;

                Color[] colors = new Color[13];
                for (int i = 0; i < colors.Length; i++)
                    colors[i] = Color.Black;

                if (dataColors.Rows.Count > 1)
                    dataColors.Rows[1].Cells[0].Selected = true;

                List<Sensor> toCount = new List<Sensor>();

                foreach (object o in checkedListBoxSensors.Items)
                {
                    Sensor s = o as Sensor;

                    if (!checkedListBoxSensors.GetItemChecked(w))
                    {
                        if (maskdata.ContainsKey(s)) maskdata.Remove(s);
                        dataColors.Rows[w].DefaultCellStyle.BackColor = Color.White;
                       
                        u++;
                    }
                    else
                    {
                        dataColors.Rows[w].DefaultCellStyle.BackColor = Plotter.Colors[w];
                        colors[k] = Plotter.Colors[w];
                        toCount.Add(s);
                        k++;
                    }

                    dataColors.Rows[w].Selected = false;
                    w++;
                }



                double area = measure.area(toCount);

                textBoxArea.Text = area.ToString("0") + " Гц*с";

                plotter.CurveColor = colors;
                    
                #region Rose
                
                List<double> list = new List<double>();
                List<string> notes = new List<string>();


                double[][] doubledata = new double[maskdata.Count][];
                int c = 0;
                int maxL = int.MaxValue;

                if (maskdata.Count > 0)
                {
                    foreach (Sensor s in maskdata.Keys)
                    {
                        doubledata[c] = new double[maskdata[s].Count];
                        int r = 0;


                        foreach (PointD p in maskdata[s])
                            doubledata[c][r++] = init[s] - p.Y;
                        maxL = Math.Min(r, maxL);
                        c++;
                    }

                    for (int i = 0; i < maxL; i++)
                        for (int j = 0; j < doubledata.Length; j++)
                            list.Add(doubledata[j][i]);

                }

                plotterBox.Data = list.ToArray();
                plotterBox.MarkerGap = maskdata.Keys.Count;

                for (int i = 0; i < Mask.TimePoints.Length; i++)
                {
                    notes.Add(Mask.TimePoints[i].ToString());
                    for (int j = 0; j < maskdata.Keys.Count - 1 ; j++)
                        notes.Add("");
                }

                plotterBox.Notes = notes.ToArray();
                plotterBox.Minimum = measure.MinDelta;
                plotterBox.Maximum = measure.MaxDelta + 0.5d;
                plotterBox.Refresh();

                #endregion

                #region MaxRose

                List<double> vals = new List<double>();
                List<string> strs = new List<string>();

                foreach (double[] dd in doubledata)
                {
                    double mx = 0d;
                    foreach (double d in dd)
                        if (Math.Abs(d) > mx) mx = Math.Abs(d);

                    vals.Add(mx);
                }

                foreach (Sensor  sen in maskdata.Keys)
                    strs.Add(sen.SID);

                plotterBoxMax.Data = vals.ToArray();
                plotterBoxMax.Notes = strs.ToArray();
              
                plotterBoxMax.Refresh();
                button1_Click(null, null);
                plotterBoxMax.Refresh();
                #endregion

                #region Lines

                PointD[][] data = new PointD[maskdata.Keys.Count][];
                int cnt = 0;
                foreach (Sensor s in maskdata.Keys)
                {
                    data[cnt] = maskdata[s].ToArray();
                    for (int i = 0; i < data[cnt].Length; i++)
                        data[cnt][i].Y = init[s] - data[cnt][i].Y;
                    cnt++;
                }
                
                plotter.Viewport = viewport;
                plotter.Data = data;
                                
                #endregion

            }

        }

        /// <summary>
        /// Инициализация формы
        /// </summary>
        void init()
        {
            comboBoxMask.Items.Clear();
            comboBoxMask.Items.AddRange(Program.DataProvider.Masks.ToArray());
        }

        public FormViewMeasure()
        {
            InitializeComponent();
        }

        public FormViewMeasure(MeasureData data)
        {
            InitializeComponent();

            try
            {
                init();

                this.mask = data.DefaultMask;

                if (mask == null)
                    if (comboBoxMask.Items.Count > 0)
                        this.mask = comboBoxMask.Items[0] as Mask;

                this.Data = data;
                this.saved = data.ID != -1;

                if (mask != null)
                    for (int i = 0; i < comboBoxMask.Items.Count; i++)
                        if (mask.ID == (comboBoxMask.Items[i] as Mask).ID)
                        {
                            comboBoxMask.SelectedIndex = i;
                            break;
                        }
          
                plotter.Viewport = new RectangleD(0, 1000000, measureData.FullMeasureLength + 0.5d, 200);
                RePlot();
                btnFit_Click(null, null); 
                button1_Click(null, null);
            }
            catch (Exception ex)
            {
                Error.Log(ex);
                MessageBox.Show("Ошибка инициализаци: " + ex.Message);
            }
        }

        public static FormViewMeasure getFormForMeasure(MeasureData data)
        {
            FormViewMeasure form = new FormViewMeasure(data);
            form.Text = "Просмотр измерения: " + data.ToString() + (data.ID != -1 ? "" : " * ");
            form.ShowReport();
            form.Show();
            return form;
        }

        private void comboBoxMask_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mask = comboBoxMask.SelectedItem as Mask;
        }

        private void checkedListBoxSensors_MouseUp(object sender, MouseEventArgs e)
        {
            RePlot();
        }

        private void FormViewMeasure_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.DefaultMask = comboBoxMask.SelectedItem as Mask;

            if (!saved)
            {
                if (MessageBox.Show("Вы просматривали несохранённое измерение. Сохранить?", "Сохранение?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataProvider.GroupTreeNode node = FormSelectOneGroup.getNode();
                    if (node != null)
                        Data.GroupID = node.ID;

                    Program.DataProvider.insertMeasureData(measureData);
                }
            }
            else
            {
                Program.DataProvider.updateMeasureData(Data);
            }
        }

        private void checkBoxBold_CheckedChanged(object sender, EventArgs e)
        {
            plotterBox.DrawBoldLines = checkBoxBold.Checked;
        }

        private void checkBoxThik_CheckedChanged(object sender, EventArgs e)
        {
            plotterBox.DrawThinLines = checkBoxThin.Checked;
        }

        private void checkBoxAdjust_CheckedChanged(object sender, EventArgs e)
        {
            plotter.Adjusting = checkBoxAdjust.Checked;
        }

        private void checkBoxMaxThin_CheckedChanged(object sender, EventArgs e)
        {
            plotterBoxMax.DrawThinLines = checkBoxMaxThin.Checked;
        }

        private void buttonLess_Click(object sender, EventArgs e)
        {

            plotterBox.Maximum = plotterBox.Minimum + (plotterBox.Maximum - plotterBox.Minimum) * zoom;
            plotterBox.Refresh();
        }

        private void buttonMore_Click(object sender, EventArgs e)
        {
            plotterBox.Maximum = plotterBox.Minimum + (plotterBox.Maximum - plotterBox.Minimum) / zoom;
            plotterBox.Refresh();
        }

        private void buttonMaxLess_Click(object sender, EventArgs e)
        {
            plotterBoxMax.Maximum = plotterBoxMax.Minimum + (plotterBoxMax.Maximum - plotterBoxMax.Minimum) * zoom;
            plotterBoxMax.Refresh();
        }

        private void buttonMaxMore_Click(object sender, EventArgs e)
        {
            plotterBoxMax.Maximum = plotterBoxMax.Minimum + (plotterBoxMax.Maximum - plotterBoxMax.Minimum) / zoom;
            plotterBoxMax.Refresh();
        }

        private void buttonXML_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "XML files|*.xml";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, measureData.toXML());
                }
                catch (Exception ex)
                {
                    Error.Log(ex);
                    MessageBox.Show("Ошибка записи в файл: " + ex.Message);
                }
            }
            
        }

        private void btnFit_Click(object sender, EventArgs e)
        {
            double[] dd = plotterBoxMax.Data;
            double max = double.MinValue;
            double min = double.MaxValue;

            foreach (double d in dd)
            {
                max = Math.Max(d, max);
                min = Math.Min(d, min);
            }

            if (max > double.MinValue && min < double.MaxValue)
            {
                plotterBoxMax.Minimum = 0;
                plotterBoxMax.Maximum = max + 0.5d;
                plotterBoxMax.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] dd = plotterBox.Data;
            double max = double.MinValue;
            double min = double.MaxValue;
            
            foreach (double d in dd)
            {
                max = Math.Max(d, max);
                min = Math.Min(d, min);
            }
            if (max > double.MinValue && min < double.MaxValue)
            {
                plotterBox.Minimum = Math.Min(min, 0);
                plotterBox.Maximum = max;

                plotterBox.Refresh();
            }
        }

        private void buttonAutoPlotter_Click(object sender, EventArgs e)
        {
            plotter.Viewport = new RectangleD(0d, -100, measureData.FullMeasureLength + 0.5d, 200d);
            plotter.Adjusting = true;
            plotter.Adjusting = checkBoxAdjust.Checked;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saved)
                Program.DataProvider.updateMeasureData(Data);
            else
            {
                if (MessageBox.Show("Сохранить измерение\r\n'" + Data.ToString() + "'?", "Сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataProvider.GroupTreeNode node = FormSelectOneGroup.getNode();
                    if (node != null)
                        Data.GroupID = node.ID;
                    else
                        Data.GroupID = -1;
                    try
                    {
                        int id = Program.DataProvider.insertMeasureData(measureData);
                        saved = true;
                        measureData = Program.DataProvider.getMeasureDataByID(id);
                        RePlot();

                        Text = measureData.ToString();
                    }
                    catch (Exception ex)
                    {
                        Error.Log(ex);
                        MessageBox.Show("Ошибка сохранения:\r\n" + ex.Message);
                    }
                }
            }
        }

        private void buttonCSV_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Comma Separated Values файлы|*.csv";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, measureData.ToCSV(comboBoxMask.SelectedItem as Mask));
                }
                catch (Exception ex)
                {
                    Error.Log(ex);
                    MessageBox.Show("Ошибка записи в файл: " + ex.Message);
                }
            }
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            int min, max;
            min = max = 0;
            try
            {
                min = (int)numericMin.Value;
                max = (int)numericUpMax.Value;
            }
            catch { MessageBox.Show("Введите корректные значения."); return; }

            if (min >= max)
            { MessageBox.Show("Введите непротиворечивые значения."); return; }


            plotterBox.Minimum = min;
            plotterBox.Maximum = max;

            plotterBox.Refresh();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int min, max;
            min = max = 0;
            try
            {
                min = (int)numericMin.Value;
                max = (int)numericUpMax.Value;
            }
            catch { MessageBox.Show("Введите корректные значения."); return; }

            if (min >= max)
            { MessageBox.Show("Введите непротиворечивые значения."); return; }


            plotterBoxMax.Minimum = min;
            plotterBoxMax.Maximum = max;

            plotterBoxMax.Refresh();
        }

        private void buttonSaveTime_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "JPEG изображения|*.jpg;*.jpe;*.jpeg";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "jpg";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;

                try
                {
                    plotterBox.SaveToFile(path, ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    Error.Log(ex);
                    MessageBox.Show("Ошибка сохранения: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "JPEG изображения|*.jpg;*.jpe;*.jpeg";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "jpg";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;

                try
                {
                    plotter.getSnap().Save(path, ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    Error.Log(ex);
                    MessageBox.Show("Ошибка сохранения: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "JPEG изображения|*.jpg;*.jpe;*.jpeg";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "jpg";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;

                try
                {
                    plotterBoxMax.SaveToFile(path, ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    Error.Log(ex);
                    MessageBox.Show("Ошибка сохранения: " + ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Comma Separated Values файлы|*.csv";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string txt = measureData.ToCSV(measureData.DefaultMask);
                    StreamWriter sw = new StreamWriter(new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write), Encoding.GetEncoding(1251));
                    sw.Write(txt);
                    sw.Flush();
                    sw.Close();
                }
                catch (Exception ex)
                {
                    Error.Log(ex);
                    MessageBox.Show("Ошибка записи в файл: " + ex.Message);
                }
            }
        }

        private double[][] DirectionData(Measure m)
        {
            Dictionary<Sensor, List<PointD>> md = m.getMaskData();
            Dictionary<Sensor, double> st = m.MeasureData.StartValues;

            double[][] ddata = new double[md.Keys.Count][];

            double[] mins = new double[md.Keys.Count];

            int cnt = 0;
            foreach (List<PointD> v in md.Values)
            {
                ddata[cnt] = new double[v.Count];
                for (int j = 0; j < ddata[cnt].Length; j++) ddata[cnt][j] = 0d;
                mins[cnt++] = double.MaxValue;
            }

            cnt = 0;

            foreach (Sensor key in md.Keys)
            {
                List<PointD> dat = md[key];

                for (int i = 0; i < dat.Count; i++)
                {
                    double v = Math.Abs(st[key] - dat[i].Y);
                    if (v < mins[cnt]) mins[cnt] = v;
                }

                for (int k = 0; k <= cnt; k++)
                {
                    for (int i = 0; i < dat.Count; i++)
                    {
                        double v = Math.Abs(st[key] - dat[i].Y);
                        ddata[k][i] += v - mins[cnt];
                    }
                }
                cnt++;
            }

            return ddata;
        }


        private double[][] DerivationDirectionData(Measure m)
        {
            Dictionary<Sensor, List<PointD>> md = m.getMaskData();
            Dictionary<Sensor, double> st = m.MeasureData.StartValues;

            double[][] ddata = new double[md.Keys.Count][];

            int cnt = 0;
            foreach (List<PointD> v in md.Values)
            {
                ddata[cnt] = new double[v.Count];
                for (int j = 0; j < ddata[cnt].Length; j++) ddata[cnt][j] = 0d;
                cnt++;
            }

            cnt = 0;

            foreach (Sensor key in md.Keys)
            {
                List<PointD> dat = md[key];
                
                for (int k = 0; k <= cnt; k++)
                {
                    for (int i = 0; i < dat.Count; i++)
                    {
                        double v;
                        if (i == 0) v = 0;
                        else v = dat[i].Y - dat[i - 1].Y;

                        v = v > 0 ? v : 0;
                        ddata[k][i] += v;
                    }
                }
                cnt++;
            }

            return ddata;
        }




        private void button6_Click(object sender, EventArgs e)
        {
            Measure m = new Measure(measureData, mask, 0d);

            double[][] N = DirectionData(m);
            double[][] D = DerivationDirectionData(m);

            double maxN, maxD;
            maxD = maxN = 0d;

            if (N.Length > 0)
                foreach (double d in N[0])
                    if (d > maxN) maxN = d;

            if (D.Length > 0)
                foreach (double d in D[0])
                    if (d > maxD) maxD = d;

            FormExperiment fe = new FormExperiment();

            fe.extendedPlotterBoxD.Data = D;
            fe.extendedPlotterBoxN.Data = N;

            fe.extendedPlotterBoxD.Minimum = 0d;
            fe.extendedPlotterBoxN.Minimum = 0d;

            fe.extendedPlotterBoxD.Maximum = maxD;
            fe.extendedPlotterBoxN.Maximum = maxN;

            fe.extendedPlotterBoxD.Refresh();
            fe.extendedPlotterBoxN.Refresh();
         
            fe.Show();
        }
    }
}
