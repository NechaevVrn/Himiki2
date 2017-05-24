using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuadroSoft.Enose.DataModel;

namespace QuadroSoft.Enose.Dialogs
{
    public partial class FormSelectOneMeasure : Form
    {
        private FormSelectOneMeasure()
        {
            InitializeComponent();
        }

        private static FormSelectOneMeasure instance;

        public static FormSelectOneMeasure Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new FormSelectOneMeasure();
                instance.measureTree.ShowMeasures = true;
                return instance;
            }
        }

        public MeasureData GetMeasureData()
        {
                object o = measureTree.TagOfSelected;
                if (o != null && o is Int32)
                    return Program.DataProvider.getMeasureDataByID((int)o);
                else return null;
        }
    }
}
