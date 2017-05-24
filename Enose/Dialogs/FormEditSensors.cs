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
    public partial class FormEditSensors : Form
    {
        private FormEditSensors()
        {
            InitializeComponent();
        }

        private void setList()
        {
            Program.DataProvider.getSensorList();
            List<Sensor> list = Program.DataProvider.SensorList;

            listBox.Items.Clear();
            listBox.Items.AddRange(list.ToArray());
            if (listBox.Items.Count > 0) listBox.SelectedIndex = 0;
        }

        private static FormEditSensors instance = null;

        public static FormEditSensors Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new FormEditSensors();

                return instance;
            }
        }

        public void Show()
        {
            setList();
            base.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Sensor sensor = listBox.SelectedItem as Sensor;

                if (sensor.SID != textBoxSID.Text)
                {
                    if (MessageBox.Show("Вы изменили идентификатор сенсора! Продолжить?", "Изменение идентификатора сенсора", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        textBoxSID.Text = sensor.SID;
                        return;
                    }
                }
                string sid = sensor.SID;
                sensor.Name = textBoxName.Text;
                sensor.SID = textBoxSID.Text;
                sensor.PassportAmplitude = Convert.ToDouble(numericAmp.Value);
                sensor.PassportFrequency = Convert.ToDouble(numericFreq.Value);

                Program.DataProvider.updateSensor(sensor, sid);

                setList();
                listBox.SelectedItem = sensor;
            }
            else
            {
                MessageBox.Show("Не выбран сенсор.");
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> set = new Dictionary<string, object>();
                set.Add(Sensor.PASSPORT_FREQ, Convert.ToDouble(numericFreq.Value));
                set.Add(Sensor.PASSPORT_AMP, Convert.ToDouble(numericAmp.Value));
                Sensor sensor = new Sensor(textBoxSID.Text, textBoxName.Text, "", set);
                Program.DataProvider.insertSensor(sensor);
                setList();
                if (listBox.Items.Count > 0)
                    listBox.SelectedIndex = listBox.Items.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }


        void showDiap()
        {
            string f = "Частота: " + (numericFreq.Value - numericAmp.Value).ToString("0.00") + ".." + (numericFreq.Value + numericAmp.Value).ToString("0.00");
            labelDiap.Text = f;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Sensor sensor = listBox.SelectedItem as Sensor;
                string name = sensor.Name;
                string sid = sensor.SID;
                double freq = sensor.PassportFrequency;
                double amp = sensor.PassportAmplitude;

                textBoxName.Text = name;
                textBoxSID.Text = sid;
                
                numericFreq.Value = Convert.ToDecimal(freq);
                numericAmp.Value = Convert.ToDecimal(amp);

                showDiap();
            }
        }

        private void numericFreq_ValueChanged(object sender, EventArgs e)
        {
            showDiap();
        }
    }
}
