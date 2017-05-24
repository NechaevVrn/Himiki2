using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuadroSoft.Enose.DataModel;

namespace QuadroSoft.Enose.Graph
{
    public partial class TwoRoses : UserControl
    {
        private MeasureData Data1, Data2;
        private Mask mask;

        public TwoRoses()
        {
            InitializeComponent();

            plotterBoxDown.BackGround = new Pen(Color.FromArgb(0, 255, 255, 255)).Brush;
            plotterBoxUp.BackGround = new Pen(Color.FromArgb(254, 255, 255, 255)).Brush;
            plotterBoxUp.Brush = new Pen(Color.FromArgb(60, 255, 128, 128)).Brush;
            plotterBoxUp.DrawBoldLines = plotterBoxUp.DrawThinLines = false;

        }

        public void setValues(MeasureData down, MeasureData up, Mask mask)
        {
            Data1 = down;
            Data2 = up;
            this.mask = mask;
            RePlot();
        }

        private void RePlot()
        {
            if (Data1 == null || Data2 == null|| mask == null)
            {
                plotterBoxUp.Data = null;
                plotterBoxDown.Data = null;
            }
            else
            {
                Dictionary<Sensor, double> init1 = Data1.StartValues;
                Dictionary<Sensor, double> init2 = Data2.StartValues;
                Measure measure1 = new Measure(Data1, mask, 0d);
                Measure measure2 = new Measure(Data2, mask, 0d);
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

                plotterBoxDown.Data = list1.ToArray();
                plotterBoxDown.MarkerGap = maskdata1.Keys.Count;

                plotterBoxUp.Data = list2.ToArray();
                plotterBoxUp.MarkerGap = maskdata2.Keys.Count;


                for (int i = 0; i < mask.TimePoints.Length; i++)
                {
                    notes.Add(mask.TimePoints[i].ToString());
                    for (int j = 0; j < maskdata1.Keys.Count - 1; j++)
                        notes.Add("");
                }

                plotterBoxUp.Notes = plotterBoxDown.Notes = notes.ToArray();
                plotterBoxUp.Minimum = plotterBoxDown.Minimum = Math.Min(measure1.MinDelta, measure2.MinDelta);
                plotterBoxUp.Maximum = plotterBoxDown.Maximum = Math.Max(measure1.MaxDelta, measure2.MaxDelta) + 0.5d;
                plotterBoxUp.Refresh();
                plotterBoxDown.Refresh();

                #endregion

          

            }

        }
    }
}
