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
using QuadroSoft.Enose.Statistics;

namespace QuadroSoft.Enose
{
    public partial class FormMeasure : Form
    {
        double length = 60d;
        MeasureProfile prof;
        double[] init;
        string name;
        Mask mask;
        MeasureData measureData;


        private FormMeasure()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Проведение измерения
        /// </summary>
        /// <param name="length">продолжительность измерения</param>
        /// <param name="name">наименование измерения</param>
        /// <param name="prof">профиль измерения</param>
        /// <param name="init">инициализирующие значения</param>
        /// <param name="mask">маска по умолчанию</param>
        public FormMeasure(double length, string name, MeasureProfile prof, double[] init, Mask mask)
        {
            this.prof = prof;
            this.length = length;
            this.init = init;
            this.mask = mask;

            InitializeComponent();

            this.Text = "Измерение: " + (this.name = name);
        }

        private void FormMeasure_Shown(object sender, EventArgs e)
        {
            plotter.Adjusting = true;
            plotter.PenWidth = 2;
            Program.nose.startMeasure();
            measureData = null;

            dataGridView1.RowCount = prof.Settings.Count;
            Dictionary<int, Sensor>.Enumerator en = prof.Settings.GetEnumerator();

            for (int i = 0; i < prof.Settings.Count; i++)
            {
                en.MoveNext();
                dataGridView1.Rows[i].Cells[0].Value = en.Current.Key + 1;
                Color c = plotter.CurveColor[i];
                int s = c.R + c.G + c.B;
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = c;
                Color f = s > 383 ? Color.Black : Color.White; 
                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = f;

                dataGridView1.Rows[i].Cells[1].Value = en.Current.Value;
                dataGridView1.Rows[i].Cells[2].Value = init[i];
            }
            plotter.Label = "Измерение";

            timer.Start();
            buttonOpen.Enabled = buttonSave.Enabled = buttonRepeat.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Program.nose == null) return;

            labelState.Text = "измерение...";
            int datasize = 8;
            Dictionary<DateTime, double[]> win = Program.nose.getMesureData();

            if (win.Keys.Count < 2)
                return;

            DateTime min, max;
            max = min = DateTime.Now;
            Dictionary<DateTime, double[]>.KeyCollection.Enumerator en = win.Keys.GetEnumerator();

            if (en.MoveNext())
                min = en.Current;
            else
                return;


            List<PointD>[] alldata = new List<PointD>[datasize];
            for (int i = 0; i < datasize; i++)
                alldata[i] = new List<PointD>();

            foreach (DateTime dt in win.Keys)
            {
                max = dt;
                double val = (dt.Ticks - min.Ticks) / 10e6d;
                for (int i = 0; i < datasize; i++)
                    alldata[i].Add(new PointD(val, win[dt][i]));

            }

            progressBar.Value = (int)Math.Min(Math.Max(0, (100d * ((max.Ticks - min.Ticks) / length / 1e7d))), 100);

            RectangleD viewport = new RectangleD(0, 1000000, length, 200);

            plotter.Viewport = viewport;
            PointD[][] data = new PointD[prof.Settings.Count][];


            for (int i = 0; i < prof.Settings.Count; i++)
            {
                double extr = 0d;
                data[i] = alldata[i].ToArray();
                for (int j = 0; j < data[i].Length; j++)
                {
                    data[i][j].Y = init[i] - data[i][j].Y;
                    if (Math.Abs(data[i][j].Y) > Math.Abs(extr))
                        extr = data[i][j].Y;
                }
                
                dataGridView1.Rows[i].Cells[3].Value = data[i][alldata[i].Count - 1].Y;
                dataGridView1.Rows[i].Cells[4].Value = extr;

                data[i] = new BezierLine(data[i], 0.4).GetPoints(5);
            }

            plotter.Data = data;

            if ((max.Ticks - min.Ticks) / 10e6d > length)
            {

                buttonOpen.Enabled = buttonSave.Enabled = buttonRepeat.Enabled = true;
                labelState.Text = "завершено";
                Program.nose.stopMeasure();
                timer.Stop();
                finish();
            }
        }

        private void finish()
        {
            Dictionary<DateTime, double[]> win = Program.nose.getMesureData();

            int len = prof.Settings.Count;
            bool[] used = new bool[len];
            Sensor[] sens = new Sensor[len];
            double[] inite = new double[len];
            for (int i = 0; i < len;i++)
                used[i] = true;

            int p = 0;
            foreach (int pos in prof.Settings.Keys)
            {
                inite[p] = init[p];
                sens[p++] = prof.Settings[pos];
            }

            MeasureData md = new MeasureData(win, inite, used, sens, -1, name, "", -1, length, 1d, true, mask);
            measureData = md;
        }

        private void FormMeasure_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.nose.stopMeasure();
            Program.Presets.MainWin.comboBoxProfiles.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            if (measureData != null)
            {
                DataProvider.GroupTreeNode node = FormSelectOneGroup.getNode();
                if (node != null)
                    measureData.GroupID = node.ID;

                measureData.ID = Program.DataProvider.insertMeasureData(measureData);
            }

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            FormViewMeasure.getFormForMeasure(measureData);
        }

        private void buttonRepeat_Click(object sender, EventArgs e)
        {
            Program.nose.startMeasure();
            measureData = null;

            dataGridView1.RowCount = prof.Settings.Count;
            Dictionary<int, Sensor>.Enumerator en = prof.Settings.GetEnumerator();

            for (int i = 0; i < prof.Settings.Count; i++)
            {
                en.MoveNext();
                dataGridView1.Rows[i].Cells[0].Value = en.Current.Key + 1;
                Color c = plotter.CurveColor[i];
                int s = c.R + c.G + c.B;
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = c;
                Color f = s > 383 ? Color.Black : Color.White;
                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = f;

                dataGridView1.Rows[i].Cells[1].Value = en.Current.Value;
                dataGridView1.Rows[i].Cells[2].Value = init[i];
            }
            plotter.Label = "Измерение";
            buttonOpen.Enabled = buttonSave.Enabled =  buttonRepeat.Enabled = false;
            
            timer.Start();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RectangleD viewport = new RectangleD(0, 1000000, length, 200);
            plotter.Viewport = viewport;
        }
    }
}
