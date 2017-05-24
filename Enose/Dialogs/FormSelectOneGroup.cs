using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuadroSoft.Enose.Dialogs
{
    public partial class FormSelectOneGroup : Form
    {
        private FormSelectOneGroup()
        {
            InitializeComponent();
        }

        private static FormSelectOneGroup instance = null;

        public static FormSelectOneGroup Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed) instance = new FormSelectOneGroup();
                instance.measureTree.ShowMeasures = false;
                return instance;
            }
        }


        public static QuadroSoft.Enose.DataAccess.DataProvider.GroupTreeNode getNode()
        {
            FormSelectOneGroup inst = Instance;
            if (inst.ShowDialog() == DialogResult.OK)
                if (inst.measureTree.SelectedGroup != null)
                    return inst.measureTree.SelectedGroup;
                else return null;
            else return null;            
        }
    }
}
