using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GUI;
using QuadroSoft.Enose.DataModel;

namespace QuadroSoft.Enose.Graph
{
    public partial class MultiGraph : UserControl
    {
        int w = 100;
        int h = 30;
        int Hgap = 3;
        int Vgap = 3;

        private Dictionary<object, UserControl> plotters;

        public MultiGraph()
        {
            InitializeComponent();
            Plotters = new Dictionary<object, UserControl>();
        }

        public Dictionary<object, UserControl> Plotters
        {
            get { return plotters; }
            set { initWGraph(value, w, h, Hgap, Vgap); }
        }

        public void initWGraph(Dictionary<object, UserControl> plotters, int w, int h, int Hgap, int Vgap)
        {

            if (this.Plotters != null)
                foreach (object sen in this.Plotters.Keys)
                    panel.Controls.Remove(this.Plotters[sen]);

            this.w = w;
            this.h = h;
            this.Hgap = Hgap;
            this.Vgap = Vgap;
            this.plotters = plotters;
            
            int Xpos = 0;
            int Ypos = Vgap;

            if (w + 2 * Hgap > panel.Width)
            {
                foreach (object sensor in plotters.Keys)
                {
                    UserControl plotter = plotters[sensor];

                    //plotter.MouseMove += new MouseEventHandler(plotter_MouseEnter);
                    
                    panel.Controls.Add(plotter);

                    plotter.Left = Hgap;
                    plotter.Top = Ypos;

                    plotter.Width = w;
                    plotter.Height = h;
                    Ypos += (2 * Vgap + plotter.Height);
                }
            }
            else
            {
                foreach (object sensor in plotters.Keys)
                {
                    UserControl plotter = plotters[sensor];

                    if (Xpos + w + Hgap > panel.Width)
                    {
                        Xpos = 0;
                        Ypos += (2 * Vgap + plotter.Height);
                    }

                    panel.Controls.Add(plotter);

                    plotter.Left = Xpos;
                    plotter.Top = Ypos;

                    plotter.Width = w;
                    plotter.Height = h;

                    Xpos += 2 * Hgap + w;
                }
            }
            this.Height = Ypos + 2 *  h + Vgap * 2;
        }

        void plotter_MouseEnter(object sender, MouseEventArgs e)
        {
            ///ЧЁДЕЛАТЬ ЧЁ ДЕЛАТЬ????
            /*
            if (sender != null)
            (sender as UserControl).Select();
             */
        }

        private void panel_SizeChanged(object sender, EventArgs e)
        {
            initWGraph(plotters, w, h, Hgap, Vgap);
        }
    }
}
