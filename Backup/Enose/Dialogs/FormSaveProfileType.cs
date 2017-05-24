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
    public partial class FormSaveProfileType : Form
    {
        public FormSaveProfileType()
        {
            InitializeComponent();
        }

        private void radioButtonNew_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNew.Checked)
            {
                labelNowProfile.Enabled = false;
                labelNewName.Enabled = true;
                textBoxName.Enabled = true;
            }
            else
            {
                labelNowProfile.Enabled = true;
                labelNewName.Enabled = false;
                textBoxName.Enabled = false;

            }
        }


        private static FormSaveProfileType instance = null;

        public static FormSaveProfileType Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new FormSaveProfileType();
                return instance;
            }
        }


        public static bool Save(MeasureProfile current, MeasureProfile newprof)
        {
            FormSaveProfileType inst = FormSaveProfileType.Instance;

            if (current != null) inst.labelNowProfile.Text = "\'" + current.ToString() + "\'";

            if (inst.ShowDialog() == DialogResult.OK)
            {
                bool newp = inst.radioButtonNew.Checked;
                string name = inst.textBoxName.Text;

                if (!newp)
                {
                    if (current == null || current.ID < 0)
                    {
                        MessageBox.Show("Профиль не заменён: не выбран основной.");
                        return false;
                    }
                    else 
                    {
                        newprof.Name = current.Name;
                        Program.DataProvider.delete("MeasureProfile", "ID=" + current.ID);
                        Program.DataProvider.insertMeasureProfile(newprof);
                    }
                }
                else
                {

                    if (name.Trim() == "")
                    {
                        MessageBox.Show("Профиль не сохранён: вы не ввели название.");
                        return false;
                    }
                    else
                    {
                        newprof.Name = name;
                        Program.DataProvider.insertMeasureProfile(newprof);
                    }
                }

                return true;
            }
            else return false;
        }
    }
}
