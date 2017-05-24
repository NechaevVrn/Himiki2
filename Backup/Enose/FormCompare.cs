using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuadroSoft.Enose.DataModel;
using System.Drawing.Imaging;

namespace QuadroSoft.Enose
{
    public partial class FormCompare : Form
    {
        public FormCompare()
        {
            InitializeComponent();
        }

        private double zoom = 1.3d;

        MeasureData Data1, Data2;
        Mask mask;
        double dd, du;

        public void setValues(MeasureData down, double dd, MeasureData up, double du, Mask mask)
        {
            Data1 = down;
            Data2 = up;
            this.du = du;
            this.dd = dd;
            this.mask = mask;
            recolor();
            RePlot();
          


        }

        private void recolor()
        {
            Bitmap b, c, s;
            Graphics gb, gc, gs;
            b = new Bitmap(pictureBoxBase.Width, pictureBoxBase.Height);
            c = new Bitmap(pictureBoxCompared.Width, pictureBoxCompared.Height);
            s = new Bitmap(pictureBoxSum.Width, pictureBoxSum.Height);

            gb = Graphics.FromImage(b);
            gc = Graphics.FromImage(c);
            gs = Graphics.FromImage(s);

            gb.FillRectangle(plotterBox.BackGround, new Rectangle(new Point(0,0), b.Size));
            gb.FillRectangle(plotterBox.Brush, new Rectangle(new Point(0,0), b.Size));

            gc.FillRectangle(plotterBox.BackGround, new Rectangle(new Point(0,0), c.Size));
            gc.FillRectangle(plotterBox.SecondBrush, new Rectangle(new Point(0,0), c.Size));

            
            gs.FillRectangle(plotterBox.BackGround, new Rectangle(new Point(0,0), s.Size));
            gs.FillRectangle(plotterBox.Brush, new Rectangle(new Point(0, 0), s.Size));
            gs.FillRectangle(plotterBox.SecondBrush, new Rectangle(new Point(0, 0), s.Size));

            pictureBoxBase.Image = b;
            pictureBoxCompared.Image = c;
            pictureBoxSum.Image = s;

        }

        private void RePlot()
        {
            if (Data1 == null || Data2 == null || mask == null)
            {
                plotterBox.Data = null;
            }
            else
            {
                Dictionary<Sensor, double> init1 = Data1.StartValues;
                Dictionary<Sensor, double> init2 = Data2.StartValues;
                Measure measure1 = new Measure(Data1, mask, dd);
                Measure measure2 = new Measure(Data2, mask, du);
                Dictionary<Sensor, List<PointD>> maskdata1 = measure1.getMaskData();
                Dictionary<Sensor, List<PointD>> maskdata2 = measure2.getMaskData();

                #region Rose

                List<double> list1 = new List<double>();
                List<string> notes = new List<string>();

                List<double> list2 = new List<double>();

                double[][] doubledata1 = new double[maskdata1.Count][];
                double[][] doubledata2 = new double[maskdata2.Count][];
                int c = 0;
                int maxL = int.MaxValue;

                if (maskdata1.Count > 0 && maskdata2.Count > 0)
                {
                    foreach (Sensor s in maskdata1.Keys)
                    {
                        doubledata1[c] = new double[maskdata1[s].Count];
                        doubledata2[c] = new double[maskdata2[s].Count];
                        int r = 0;

                        foreach (PointD p in maskdata1[s])
                            //doubledata[c][r++] = Math.Abs(p.Y - init[s]);
                            doubledata1[c][r++] = init1[s] - p.Y;
                        r = 0;
                        foreach (PointD p in maskdata2[s])
                            //doubledata[c][r++] = Math.Abs(p.Y - init[s]);
                            doubledata2[c][r++] = init2[s] - p.Y;
                        maxL = Math.Min(r, maxL);

                        c++;
                    }

                    for (int i = 0; i < maxL; i++)
                        for (int j = 0; j < doubledata1.Length; j++)
                        {
                            list1.Add(doubledata1[j][i]);
                            list2.Add(doubledata2[j][i]);
                        }
                }

                plotterBox.Data = list1.ToArray();
                plotterBox.SecondData = list2.ToArray();
                plotterBox.MarkerGap = maskdata2.Keys.Count;

                for (int i = 0; i < mask.TimePoints.Length; i++)
                {
                    notes.Add(mask.TimePoints[i].ToString());
                    for (int j = 0; j < maskdata1.Keys.Count - 1; j++)
                        notes.Add("");
                }

                plotterBox.Notes = notes.ToArray();
                plotterBox.Minimum = Math.Min(0d, Math.Min(measure1.MinDelta, measure2.MinDelta));
                plotterBox.Maximum = Math.Max(measure1.MaxDelta, measure2.MaxDelta) + 0.5d;
                plotterBox.Refresh();

                #endregion
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (Data1 != null && Data2 != null && mask != null)
            {
                Measure measure1 = new Measure(Data1, mask, 0d);
                Measure measure2 = new Measure(Data2, mask, 0d);
                plotterBox.Minimum = Math.Min(0d, Math.Min(measure1.MinDelta, measure2.MinDelta));
                plotterBox.Maximum = Math.Max(measure1.MaxDelta, measure2.MaxDelta) + 0.5d;
                plotterBox.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plotterBox.Maximum = plotterBox.Minimum + (plotterBox.Maximum - plotterBox.Minimum) * zoom;
            plotterBox.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            plotterBox.Maximum = plotterBox.Minimum + (plotterBox.Maximum - plotterBox.Minimum) / zoom;
            plotterBox.Refresh();
        }

        private void checkBoxMain_CheckedChanged(object sender, EventArgs e)
        {
            plotterBox.DrawBoldLines = checkBoxMain.Checked;
            plotterBox.Refresh();
        }

        private void checkBoxAdd_CheckedChanged(object sender, EventArgs e)
        {
            plotterBox.DrawThinLines = checkBoxAdd.Checked;
            plotterBox.Refresh();
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
                    plotterBox.SaveToFile(path, ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка сохранения: " + ex.Message);
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            recolor();
        }


    }
}
