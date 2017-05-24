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
    public partial class FormCreateMask : Form
    {
        private FormCreateMask()
        {
            InitializeComponent();
        }

        static FormCreateMask fcm;

        static FormCreateMask Instance
        {
            get { if (fcm == null || fcm.IsDisposed) fcm = new FormCreateMask(); return fcm; }
        }

        public static void Work()
        {
            FormCreateMask f = FormCreateMask.Instance;
            f.ShowDialog();
        }


        private void FormCreateMask_Shown(object sender, EventArgs e)
        {
            List<Mask> masks = Program.DataProvider.Masks;

            textBoxData.Text = "";
            textBoxMaskName.Text = "";

            comboBox1.Items.Clear();
            comboBox1.Text = "";

            comboBox1.Items.AddRange(masks.ToArray());


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Mask m = comboBox1.SelectedItem as Mask;
                textBoxMaskName.Text = m.Name;
                string data = "";
                foreach (double tm in m.TimePoints)
                    data += " " + tm;
                textBoxData.Text = data;
            }
        }

        List<double> StrToPoints(string str)
        {
            
            List<double> data = new List<double>();
            string[] strs = str.Replace(".", ",").Split(new char[] { ' ', '\r', '\n', '\t' });
            foreach (string s in strs)
            {
                double d;

                if (s.Trim() != "")
                    if (double.TryParse(s.Trim(), out d))
                        if (!data.Contains(d))
                            data.Add(d);
            }
            
            data.Sort();
            return data;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Будет добавлена новая маска", "Добавление маски", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                List<double> data = StrToPoints(textBoxData.Text);
                string name = textBoxMaskName.Text;
                Mask m = new Mask(-1, name, data.ToArray());
                Program.DataProvider.insertMask(m);
                FormCreateMask_Shown(null, null);
            }
        }

        private void buttonSaveNew_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (MessageBox.Show("Данные в текущей маске будут изменены", "Изменение маски", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    List<double> data = StrToPoints(textBoxData.Text);
                    string name = textBoxMaskName.Text;
                    Mask m = new Mask((comboBox1.SelectedItem as Mask).ID, name, data.ToArray());
                    Program.DataProvider.updateMask(m);
                    FormCreateMask_Shown(null, null);
                }
            }
            else
                MessageBox.Show("Не выбрана маска");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить текущую маску?", "Удаление маски", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Program.DataProvider.delete("Mask", "ID=" + (comboBox1.SelectedItem as Mask).ID);
                    Program.DataProvider.getAllMasks();
                }
                FormCreateMask_Shown(null, null);
            }
            else
                MessageBox.Show("Не выбрана маска");
        }
    }
}
