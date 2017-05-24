using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuadroSoft.Enose.Dialogs;
using QuadroSoft.Enose.DataModel;
using GUI;
using QuadroSoft.Enose.Graph;
using QuadroSoft.Enose.Statistics;

namespace QuadroSoft.Enose
{
    public partial class FormProcessMeasures : Form
    {
        public FormProcessMeasures()
        {
            InitializeComponent();
            setMasks();
        }

        private void setMasks()
        {
            comboBoxMasks.Items.Clear();
            comboBoxMasks.Items.AddRange(Program.DataProvider.Masks.ToArray());
        }

        private void calcMedian()
        {
            Dictionary<MeasureData, double> _measures = new Dictionary<MeasureData, double>();
            Mask _mask = comboBoxMasks.SelectedItem as Mask;
            if (_mask == null) return;

            foreach (object o in listBoxMeasures.Items)
                _measures.Add(o as MeasureData, (multiGraph.Plotters[o as MeasureData] as MovableGraph).Correcture);

            if (_measures.Count < 1) return;

            double _maxlen = double.MaxValue;

            foreach (MeasureData data in _measures.Keys)
                _maxlen = Math.Min(_maxlen, data.FullMeasureLength);

            if (_maxlen < 1d) return;

            MeasureData measuredata = Measure.calculateMedianMeasure(_measures, _mask, _maxlen);

            movableGraphMedian.initWData(measuredata);

        }

        private void stackSensors()
        {
            List<Sensor> sensors = new List<Sensor>();
            foreach (object o in listBoxMeasures.Items)
            {
                MeasureData data = o as MeasureData;
                foreach (Sensor sen in data.AllData.Keys)
                    if (!sensors.Contains(sen))
                        sensors.Add(sen);
            }
            sensors.Sort();

            checkedListBoxSensors.Items.Clear();
            checkedListBoxSensors.Items.AddRange(sensors.ToArray());

            for (int i = 0; i < checkedListBoxSensors.Items.Count; i++)
            {
                bool checkd = false;
                foreach (object o in listBoxMeasures.Items)
                {
                    MeasureData data = o as MeasureData;
                    if (data.Used.ContainsKey(checkedListBoxSensors.Items[i] as Sensor) && data.Used[checkedListBoxSensors.Items[i] as Sensor])
                        checkd = true;
                }
                checkedListBoxSensors.SetItemChecked(i, checkd);
            }
        }

        private void corrchanged(object sender, EventArgs args)
        {
            calcMedian();
        }

        private void Stack(MeasureData[] measures)
        {
            Dictionary<object, UserControl> newplotters = new Dictionary<object, UserControl>();
            foreach (MeasureData dat in measures)
            {
                MovableGraph mg;
                newplotters.Add(dat, mg = new MovableGraph(dat));
                mg.CorrectureChaged += new EventHandler(corrchanged);
            }
            multiGraph.initWGraph(newplotters, 900, 260, 5, 12);

            stackSensors();

            calcMedian();
        }

        private MeasureData[] toArray(System.Windows.Forms.ListBox.ObjectCollection collection)
        {
            MeasureData[] data = new MeasureData[collection.Count];
            int i = 0;
            foreach (object o in collection)
                data[i++] = o as MeasureData;
            return data;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (listBoxMeasures.SelectedItem != null)
                listBoxMeasures.Items.Remove(listBoxMeasures.SelectedItem);

            Stack(toArray(listBoxMeasures.Items));
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSelectOneMeasure inst = FormSelectOneMeasure.Instance;
            
            if (inst.ShowDialog() == DialogResult.OK)
            {
                MeasureData data = inst.GetMeasureData();
                if (data != null)
                {
                    bool ok = true;
                    foreach (object o in listBoxMeasures.Items)
                        if ((o as MeasureData).ID == data.ID) ok = false;
                    if (
                        ok 
                        || 
                        MessageBox.Show("Вы пытаетесь добавить уже выбранное измерение. Продолжить?", "Добавление измерения", MessageBoxButtons.YesNo) == DialogResult.Yes
                        )
                    listBoxMeasures.Items.Add(data);

                    foreach (object o in comboBoxMasks.Items)
                        if (data.DefaultMask != null && (o as Mask).ID == data.DefaultMask.ID)
                            comboBoxMasks.SelectedItem = o;
                        else
                            if (comboBoxMasks.Items.Count > 0)
                                comboBoxMasks.SelectedIndex = 0;
                }

                
            }

            Stack(toArray(listBoxMeasures.Items));
        }

        private void comboBoxMasks_SelectedIndexChanged(object sender, EventArgs e)
        {

            MeasureData[] datas = toArray(listBoxMeasures.Items);
            foreach (MeasureData data in datas)
                data.DefaultMask = comboBoxMasks.SelectedItem as Mask;

            Stack(datas);
        }

        private void checkedListBoxSensors_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (object o in listBoxMeasures.Items)
            {
                MeasureData dat = o as MeasureData;

                for (int i = 0; i < checkedListBoxSensors.Items.Count; i++)
                    if (dat.Used.ContainsKey(checkedListBoxSensors.Items[i] as Sensor))
                        dat.Used[checkedListBoxSensors.Items[i] as Sensor] = checkedListBoxSensors.GetItemChecked(i);
                   
            }

            Stack(toArray(listBoxMeasures.Items));
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (movableGraphMedian.MeasureData != null)
                movableGraphMedian.MeasureData.Name = textBoxName.Text;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<MeasureData, double> _measures = new Dictionary<MeasureData, double>();
                string err = "Должно быть выбрано ровно 2 измерения.\r\nПервое должно быть 'усреднённым' и содержать статистическую информацию [Σ+].";
                foreach (object o in listBoxMeasures.Items)
                    if (multiGraph.Plotters.ContainsKey(o))
                        _measures.Add(o as MeasureData, (multiGraph.Plotters[o] as MovableGraph).Correcture);

                Mask _mask = comboBoxMasks.SelectedItem as Mask;


                if (_measures.Count < 2)
                {
                    MessageBox.Show(err);
                    return;
                }
                double _maxlen = double.MaxValue;

                foreach (MeasureData data in _measures.Keys)
                    _maxlen = Math.Min(_maxlen, data.FullMeasureLength);

                if (_maxlen < 1d) return;


                if (_measures.Count != 2)
                {
                    MessageBox.Show(err);
                    return;
                }
                else if ((listBoxMeasures.Items[0] as MeasureData).IsMeasured)
                {
                    MessageBox.Show("Первое измерение не является 'усреднённым' [Σ].");
                    return;
                }
                else if ((listBoxMeasures.Items[0] as MeasureData).DispData == null)
                {
                    MessageBox.Show("Первое измерение не содержит статистической информации [+].");
                    return;
                }
                else
                {
                    MeasureData bm = listBoxMeasures.Items[0] as MeasureData;
                    MeasureData cm = listBoxMeasures.Items[1] as MeasureData;

                    double corr = (multiGraph.Plotters[cm] as MovableGraph).Correcture - (multiGraph.Plotters[bm] as MovableGraph).Correcture;

                    #region зачистка
                    foreach (Sensor s in cm.AllData.Keys)
                    {
                        if (!bm.Data.ContainsKey(s))
                            cm.Used[s] = false;
                    }

                    foreach (Sensor s in bm.AllData.Keys)
                    {
                        if (!cm.Data.ContainsKey(s))
                            bm.Used[s] = false;
                    }

                    #endregion Зачистка
                    
                    Dictionary<string, object> objs = AlgsList.Correspondence(bm, cm, corr);
                    if ((bool)objs["ok"])
                    {
                        Dictionary<Sensor, List<double>> insigma = objs["sigma"] as Dictionary<Sensor, List<double>>;
                        Dictionary<Sensor, List<double>> in3sigma = objs["3sigma"] as Dictionary<Sensor, List<double>>;
                        Dictionary<Sensor, List<double>> outof3sigma = objs["unstable"] as Dictionary<Sensor, List<double>>;

                        int count, in1, in3, out3;
                        count = in1 = in3 = out3 = 0;
                        foreach (Sensor sensor in insigma.Keys)
                            foreach (double d in insigma[sensor])
                            {
                                count++;
                                in1++;
                            }

                        foreach (Sensor sensor in in3sigma.Keys)
                            foreach (double d in in3sigma[sensor])
                            {
                                count++;
                                in3++;
                            }
                        foreach (Sensor sensor in outof3sigma.Keys)
                            foreach (double d in outof3sigma[sensor])
                            {
                                count++;
                                out3++;
                            }

                        FormCompare report = new FormCompare();

                        report.RTB.SelectionFont = report.Bold.Font;
                        report.RTB.AppendText("Сводка по сравнению:\r\n");
                        report.RTB.SelectionFont = report.Normal.Font;
                        report.RTB.AppendText("  Базовое измерение: " + bm.ToString() + "\r\n");
                        report.RTB.SelectionFont = report.Normal.Font;
                        report.RTB.AppendText("  Сравниваемое измерение: " + cm.ToString() + "\r\n");
                        report.RTB.SelectionFont = report.Italic.Font;
                        report.RTB.AppendText("  Всего сравнивалось точек: ");
                        report.RTB.SelectionFont = report.Normal.Font;
                        report.RTB.AppendText("" + count + " (" + ((100d / count) * count).ToString("0.00") + "%)\r\n");

                        report.RTB.SelectionColor = Color.Green;
                        report.RTB.SelectionFont = report.Italic.Font;
                        report.RTB.AppendText("  Попало в X±σ: ");
                        report.RTB.SelectionFont = report.Normal.Font;
                        report.RTB.AppendText("" + in1 + " (" + ((100d / count) * in1).ToString("0.00") + "%)\r\n");

                        report.RTB.SelectionColor = Color.Orange;
                        report.RTB.SelectionFont = report.Italic.Font;
                        report.RTB.AppendText("  Попало в X±3σ: ");
                        
                        report.RTB.SelectionFont = report.Normal.Font;
                        report.RTB.AppendText("" + (in1 + in3) + " (" + ((100d / count) * (in3 + in1)).ToString("0.00") + "%)\r\n");
                        report.RTB.SelectionFont = report.Normal.Font;
                        report.RTB.AppendText("  Значения точек в интервале\r\n  (-3σ; -σ)U(σ; 3σ):\r\n");

                        foreach (Sensor s in in3sigma.Keys)
                        {
                            report.RTB.SelectionFont = report.Normal.Font;
                            report.RTB.AppendText("    " + s.ToString() + ": ");

                            foreach (double d in in3sigma[s])
                            {
                                report.RTB.SelectionFont = report.Normal.Font;
                                report.RTB.AppendText(d.ToString() + "; ");
                            }
                            report.RTB.SelectionFont = report.Normal.Font;
                            report.RTB.AppendText("\r\n");
                        }

                        report.RTB.SelectionColor = Color.Red;
                        report.RTB.SelectionFont = report.Italic.Font;
                        report.RTB.AppendText("  Не попало в X±3σ: ");
                        report.RTB.SelectionFont = report.Normal.Font;
                        report.RTB.AppendText("" + out3 + " (" + ((100d / count) * out3).ToString("0.00") + "%)\r\n");

                        foreach (Sensor s in outof3sigma.Keys)
                        {
                            report.RTB.SelectionFont = report.Normal.Font;
                            report.RTB.AppendText("    " + s.ToString() + ": ");

                            foreach (double d in outof3sigma[s])
                            {
                                report.RTB.SelectionFont = report.Normal.Font;
                                report.RTB.AppendText(d.ToString() + "; ");
                            }
                            report.RTB.SelectionFont = report.Normal.Font;
                            report.RTB.AppendText("\r\n");
                        }

                        report.RTB.SelectionColor = Color.Black;

                        report.setValues(bm, _measures[bm], cm, _measures[cm], _mask);

                        report.Show();

                    }
                    else
                    {
                        MessageBox.Show("Ошибка сравнения: " + objs["errorlog"]);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка:\r\n" + ex.Message); }
        }

        private void buttonMiddle_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<MeasureData, double> _measures = new Dictionary<MeasureData, double>();
                Mask _mask = comboBoxMasks.SelectedItem as Mask;

                foreach (object o in listBoxMeasures.Items)
                    if (multiGraph.Plotters.ContainsKey(o as MeasureData))
                    _measures.Add(o as MeasureData, (multiGraph.Plotters[o as MeasureData] as MovableGraph).Correcture);

                if (_measures.Count < 3)
                {
                    MessageBox.Show("Недостаточно измерений:\r\nнеобходимо не менее трёх измерения для расчёта среднего.");
                    return;
                }

                double _maxlen = double.MaxValue;

                foreach (MeasureData data in _measures.Keys)
                    _maxlen = Math.Min(_maxlen, data.FullMeasureLength);

                if (_maxlen < 1d)
                {
                    MessageBox.Show("Самое короткое измерение имеет продолжительность менее секунды.");
                    return;
                }

                string s = FormStringRequest.GetString("Введите название измерения");
                MeasureData result = null;

                if (s != null)
                {
                    result = AlgsList.reliableMiddle(_measures, s, _mask, _maxlen);
                    FormViewMeasure.getFormForMeasure(result);
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка:\r\n" + ex.Message); }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxMeasures.Items.Clear();
            Stack(toArray(listBoxMeasures.Items));
        }
    }
}
