using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuadroSoft.Enose.DataModel;
using GUI;

namespace QuadroSoft.Enose.Graph
{
    public partial class MovableGraph : UserControl
    {
        public EventHandler CorrectureChaged;

        MeasureData measureData;
        Mask mask;
               

        public MovableGraph(MeasureData measureData)
        {
            InitializeComponent();
            if (measureData != null)
            {
                this.measureData = measureData;
                this.mask = measureData.DefaultMask;
                plotter.Viewport = new RectangleD(0, -100, measureData.FullMeasureLength + 0.5d, 200);
                plotter.Label = measureData.ToString();
                RePlot();
            }
        }

        public void initWData(MeasureData data)
        {
            if (data != null)
            {
                this.measureData = data;
                this.mask = data.DefaultMask;
                plotter.Viewport = new RectangleD(0, -100, data.FullMeasureLength + 0.5d, 200);
                plotter.Label = data.ToString();
                RePlot();
            }
        }

        public MovableGraph(): this(null) {  }

        /// <summary>
        /// Перестроить интерфейс на основании данных
        /// </summary>
        private void RePlot()
        {
            if (measureData != null && mask != null)
            {
                Measure meas = new Measure(measureData, mask, Correcture);
                Dictionary<Sensor, List<PointD>> maskdat = meas.getMaskData();
                PointD[][] data = new PointD[maskdat.Count][];
                int i = 0;
                Dictionary<Sensor, double> init = measureData.StartValues;
                foreach (Sensor sen in maskdat.Keys)
                {
                    data[i] = maskdat[sen].ToArray();

                    for (int j = 0; j < data[i].Length; j++)
                        data[i][j].Y = init[sen] - data[i][j].Y;

                    i++;
                }
                plotter.Data = data;
            }
            else
                plotter.Data = null;
        }

        /// <summary>
        /// Поправка ко времени
        /// </summary>
        public double Correcture
        {
            get
            {
                return Convert.ToDouble(numericCorrecture.Value);
            }
            set
            {
                numericCorrecture.Value = Convert.ToDecimal(value);
                if (CorrectureChaged != null)
                    CorrectureChaged.Invoke(this, null);
            }
        }

        /// <summary>
        /// Текущая маска на измерение
        /// </summary>
        public Mask Mask
        {
            get
            {
                return mask;
            }
            set
            {
                mask = value; RePlot();
            }
        }

        /// <summary>
        /// Компонент плоттера
        /// </summary>
        public Plotter Plotter
        {
            get { return plotter; }
        }

        public MeasureData MeasureData
        {
            get
            {
                return measureData;
            }
        }

        private void buttonCan_Click(object sender, EventArgs e)
        {
            RectangleD rect = new RectangleD(0, -100, measureData.FullMeasureLength + 0.5d, 200);
            plotter.Viewport = rect;            
            Correcture = 0d;
        }

        private void numericCorrecture_ValueChanged(object sender, EventArgs e)
        {
            if (CorrectureChaged != null)
                CorrectureChaged.Invoke(this, null);
            RePlot();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            FormViewMeasure.getFormForMeasure(measureData);
        }
    }
}
