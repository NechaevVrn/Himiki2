using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuadroSoft.Enose.Dialogs
{
    public partial class FormStringRequest : Form
    {
        static FormStringRequest form = null;

        public FormStringRequest()
        {
            InitializeComponent();
        }

        public static string GetString(string caption)
        {
            if (form == null || form.IsDisposed)
                form = new FormStringRequest();
            form.textBox1.Text = "";
            form.Text = caption;

            if (form.ShowDialog() == DialogResult.OK)
                return form.textBox1.Text;
            else return null; 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DialogResult = DialogResult.OK;
                Close();
            }

        }
    }
}
