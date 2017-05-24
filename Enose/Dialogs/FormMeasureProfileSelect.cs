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
    public partial class FormMeasureProfileSelect : Form
    {

        ComboBox[] combos;
        CheckBox[] checks;
        public MeasureProfile usedProfile = null;

        static int storedid = -1;

        private static FormMeasureProfileSelect instance = null;

        public static FormMeasureProfileSelect getInstance(int id)
        {
            if (instance == null)
                instance = new FormMeasureProfileSelect(id);
            storedid = id;

            instance.fillProfiles(id);
            instance.fillCombos(null);
            instance.fillMasks();

            return instance;
        }

        private void fillProfiles(int selectedPID)
        {

            List<MeasureProfile> list = Program.DataProvider.getMeasureProfiles();

            MeasureProfile selected = null;
            comboBoxProfiles.Text = "";
            comboBoxProfiles.Items.Clear();

            foreach (MeasureProfile prof in list)
            {
                comboBoxProfiles.Items.Add(prof);

                if (prof.ID == selectedPID)
                    selected = prof;
            }

            if (selected != null)
                comboBoxProfiles.SelectedValue = comboBoxProfiles.SelectedItem = selected;

        }

        private void fillCombos(MeasureProfile prof)
        {
            foreach (ComboBox combo in combos)
            {
                combo.Items.Clear();
                combo.Items.AddRange(Program.DataProvider.SensorList.ToArray());
                combo.Text = "";
                combo.SelectedItem = null;
            }
            foreach (CheckBox check in checks)
                check.Checked = false;

            if (prof != null)
            {
                foreach (int pos in prof.Settings.Keys)
                {
                    checks[pos].Checked = true;
                    combos[pos].SelectedItem = prof.Settings[pos];
                }

                if (prof.MaskID > 0)
                    foreach (object o in comboBoxMasks.Items)
                        if ((o as Mask).ID == prof.MaskID)
                            comboBoxMasks.SelectedItem = o;
                
                

                if (prof.Time > 0)
                    numericUpDownTime.Value = prof.Time;
            }
        }

        private void fillMasks()
        {
            comboBoxMasks.Items.Clear();
            comboBoxMasks.Items.AddRange(Program.DataProvider.Masks.ToArray());
        }

        private MeasureProfile collectProfile(string name)
        {
            MeasureProfile prof = new MeasureProfile();
            prof.Name = name;

            if (numericUpDownTime.Value > 0)
                prof.Time = (int)numericUpDownTime.Value;

            if (comboBoxMasks.SelectedItem != null)
                prof.MaskID = (comboBoxMasks.SelectedItem as Mask).ID;
            
            Dictionary<int, Sensor> sens = new Dictionary<int, Sensor>();

            for (int i = 0; i < combos.Length; i++)
                if (combos[i].SelectedItem != null && checks[i].Checked)
                {
                    if (!sens.ContainsValue(combos[i].SelectedItem as Sensor))
                        sens.Add(i, combos[i].SelectedItem as Sensor);
                    else
                        return null;
                }
                else checks[i].Checked = false;
            prof.Settings = sens;
            return prof;
        }

        public FormMeasureProfileSelect() : this(-1) { }

        public FormMeasureProfileSelect(int initProfile)
        {
            InitializeComponent();
            storedid = initProfile;
            combos = new ComboBox[] { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8 };
            checks = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
        }

        private void FormMeasureProfileSelect_Shown(object sender, EventArgs e)
        {
            this.textBoxName.Text = "Новое измерение";
            this.textBoxName.SelectAll();
            this.textBoxName.Focus();

            fillProfiles(storedid);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MeasureProfile prf = collectProfile("");

            if (prf == null)
            {
                MessageBox.Show("Профиль собран некорректно. Вы не можете его сохранить!");
                return;
            }

            if (FormSaveProfileType.Save(comboBoxProfiles.SelectedItem as MeasureProfile, prf))
            {
                int c = Program.DataProvider.getMeasureProfiles().Count;
                if (c > 0)
                {
                    MeasureProfile mp = Program.DataProvider.MeasureProfiles[c - 1];
                    Program.Presets.MainWin.refreshComboProfiles();
                    Program.Presets.MainWin.stackPlotters(mp);
                    fillProfiles(mp.ID);
                }
            }
        }

        private void buttonSaveNew_Click(object sender, EventArgs e)
        {
            string name = FormStringRequest.GetString("Введите название профиля");
            if (name != null)
            {
                MeasureProfile prof = collectProfile(name);
                Program.DataProvider.insertMeasureProfile(prof);
                fillProfiles(-1);
                comboBoxProfiles.SelectedIndex = comboBoxProfiles.Items.Count - 1;
            }
        }

        private void comboBoxProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProfiles.SelectedItem != null)
                fillCombos(Program.Presets.CurrentProfile = comboBoxProfiles.SelectedItem as MeasureProfile);
        }

        bool checkSame()
        {
            List<Sensor> sensors = new List<Sensor>();
            for (int i = 0; i < combos.Length; i++)
                if (checks[i].Checked)
                    if (sensors.Contains(combos[i].SelectedItem as Sensor))
                        return false;
                    else
                        sensors.Add(combos[i].SelectedItem as Sensor);

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                textBoxName.Text != "Новое измерение"
                ||
                MessageBox.Show("Вы не ввели название измерения. Начать измерение с названием 'Новое измерение'?", "Название", MessageBoxButtons.YesNo) == DialogResult.Yes
               )
            {
                MeasureProfile prof = collectProfile("");
                MeasureProfile curr = comboBoxProfiles.SelectedItem as MeasureProfile;

                if (prof == null)
                {
                    MessageBox.Show("Профиль собран некорректно. Вы не можете его сохранить!");
                    DialogResult = DialogResult.Cancel;
                    return;
                }

                bool eq = true;

                for (int pos = 0; pos < combos.Length; pos++)
                {
                    if (curr == null || prof.Settings.ContainsKey(pos) ^ curr.Settings.ContainsKey(pos))
                        eq = false;
                    else if (prof.Settings.ContainsKey(pos))
                        if (!prof.Settings[pos].Equals(curr.Settings[pos]))
                            eq = false;
                }

                if (!eq)
                {

                    if (FormSaveProfileType.Save(comboBoxProfiles.SelectedItem as MeasureProfile, prof))
                    {
                        int c = Program.DataProvider.getMeasureProfiles().Count;
                        if (c > 0)
                        {
                            MeasureProfile mp = Program.DataProvider.MeasureProfiles[c - 1];
                            Program.Presets.MainWin.refreshComboProfiles();
                            Program.Presets.MainWin.stackPlotters(mp);
                            fillProfiles(mp.ID);
                            usedProfile = mp;
                        }
                        else
                            usedProfile = Program.Presets.CurrentProfile;
                    }
                    else
                        usedProfile = prof;
                    #region какой-то код
                    /*
                if (MessageBox.Show("Установки были изменены. Сохранить изменения?", "изменённые настройки", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string name = FormStringRequest.GetString("Введите название профиля");
                    if (name != null)
                    {
                        prof.Name = name;
                        Program.dataProvider.insertMeasureProfile(prof);
                        usedProfile = Program.dataProvider.MeasureProfiles[Program.dataProvider.MeasureProfiles.Count - 1];
                    }
                    else
                        usedProfile = collectProfile("неизвестный");

                }
                else
                    usedProfile = collectProfile("неизвестный");
                 */
                    #endregion
                }
                else
                    usedProfile = curr;

                Program.Presets.CurrentProfile = curr;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (comboBoxProfiles.SelectedItem != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить профиль?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Program.DataProvider.delete("MeasureProfile", "ID=" + (comboBoxProfiles.SelectedItem as MeasureProfile).ID);
                    Program.DataProvider.getMeasureProfiles();
                    fillProfiles(-1);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            buttonMeas.Enabled = checkSame();
        }

        public void AdjustForTask(bool willMeasure)
        {
            if (willMeasure)
            {
                splitContainer.Panel1Collapsed = false;
                buttonMeas.Visible =buttonMeas.Enabled = true;
            }
            else
            {
                splitContainer.Panel1Collapsed = true;
                buttonMeas.Visible = buttonMeas.Enabled = false;
            }
        }

    }
}
