using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuadroSoft.Enose
{
    public partial class FormExperiment : Form
    {
        public FormExperiment()
        {
            InitializeComponent();
        }

        private void checkBoxDA_CheckedChanged(object sender, EventArgs e)
        {
            extendedPlotterBoxD.DrawThinLines = checkBoxDA.Checked;
            extendedPlotterBoxD.Refresh();
        }

        private void checkBoxNA_CheckedChanged(object sender, EventArgs e)
        {
            extendedPlotterBoxN.DrawThinLines = checkBoxNA.Checked;
            extendedPlotterBoxN.Refresh();
        }
    }
}
