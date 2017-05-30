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

        List<DataGridViewComboBoxCell> combos;
        CheckBox[] checks;

        ComboBox cbm;
        DataGridViewCell currentCell;

        static bool flagMouseClick = false;
        public MeasureProfile usedProfile = null;
        static bool flag = false;
        static int storedid = -1;

        private static FormMeasureProfileSelect instance = null;

        public static FormMeasureProfileSelect getInstance(int id)
        {
            if (instance == null)
                instance = new FormMeasureProfileSelect(id);
            storedid = id;

            instance.fillProfiles(id);
            //instance.fillCombos(null);
            instance.fillMasks();

            return instance;
        }

        private void fillGridProfile2(MeasureProfile prof)
        {

        }

        private void fillProfiles(int selectedPID)
        {

            List<MeasureProfile> list = Program.DataProvider.getMeasureProfiles();
            combos = new List<DataGridViewComboBoxCell>();
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

        private void fillGrid()
        {
            var name = new DataGridViewComboBoxColumn();
            name.HeaderText = "Название сенсора";
            name.Name = "Column2";
            var list11 = new List<Sensor>();
            list11.AddRange(Program.DataProvider.SensorList.ToArray());
            List<String> list = new List<String>();
            foreach (Sensor curr in list11)
            {
                name.Items.Add(curr.Name + " " + curr.SID);
            }

            var number = new DataGridViewTextBoxColumn();
            number.HeaderText = "Номер сенсора";
            number.Name = "Column1";

            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { number, name });
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
        }

        private void updateBoxes()
        {
            int current = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewComboBoxCell cell = row.Cells[1] as DataGridViewComboBoxCell;
                combos.Add(cell);
                if (flagMouseClick)
                {
                    combos[current].Value = dataGridView1.CurrentRow.Cells[1].Value;
                }
                current++;
            }
        }
        private void fillGridProfile(MeasureProfile prof)
        {
            if (dataGridView1.Columns.Count == 0)
            {
                fillGrid();
                if (!flag) { flag = true; }
                else
                {
                    return;
                }
            }
            dataGridView1.Rows.Clear();
            combos.Clear();
            if (prof != null)
            {
                foreach (int pos in prof.Settings.Keys)
                {
                    DataGridViewComboBoxCell dol = new DataGridViewComboBoxCell();
                    dataGridView1.Rows.Add(Convert.ToString(pos + 1), dol);
                }
                try
                {
                    int count = 0;
                    foreach (int pos in prof.Settings.Keys)
                    {
                        DataGridViewComboBoxCell cell = dataGridView1.Rows[count].Cells[1] as DataGridViewComboBoxCell;
                        if (cell != null)
                        {
                            for (int i = 0; i < cell.Items.Count; i++)
                            {
                                string compare = prof.Settings[pos].Name + " " + prof.Settings[pos].SID;
                                if ((string)cell.Items[i] == compare)
                                {
                                    cell.Value = cell.Items[i];
                                }
                            }
                        }
                        count++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (prof.MaskID > 0)
                    foreach (object o in comboBoxMasks.Items)
                        if ((o as Mask).ID == prof.MaskID)
                            comboBoxMasks.SelectedItem = o;
                if (prof.Time > 0)
                    numericUpDownTime.Value = prof.Time;
            }
            updateBoxes();
        }

        public void AdjustForTask(bool willMeasure)
        {
            if (willMeasure)
            {
                splitContainer.Panel1Collapsed = false;
                buttonMeas.Visible = buttonMeas.Enabled = true;
            }
            else
            {
                splitContainer.Panel1Collapsed = true;
                buttonMeas.Visible = buttonMeas.Enabled = false;
            }
        }

        private void _testDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1) // 1 - индекс колонки с комбо-боксами
            {
                ComboBox cellComboBox = (ComboBox)e.Control;
                if (cellComboBox != null)
                {
                    // обработчик уже мог записаться при предыдущем вызове этого события, так что удаляем
                    cellComboBox.SelectionChangeCommitted -= new EventHandler(cellComboBox_SelectionChangeCommitted);
                    // и наконец записываем
                    cellComboBox.SelectionChangeCommitted += new EventHandler(cellComboBox_SelectionChangeCommitted);
                }
            }
        }

        void cellComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cellComboBox = (ComboBox)dataGridView1.EditingControl;
            //int testId = Convert.ToInt32(cellComboBox.SelectedValue);
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

            Sensor[] list = Program.DataProvider.SensorList.ToArray();
            Dictionary<int, Sensor> sens = new Dictionary<int, Sensor>();
            for (int i = 0; i < combos.Count; i++)
            {
                /*if (combos[i].SelectedItem != null && checks[i].Checked)              
                    {*/

                //if (!sens.ContainsValue(combos[i].Value as Sensor))
                for (int j = 0; j < list.Length; j++)
                {
                    //MessageBox.Show(Convert.ToString(combos[i].Value)+"\n"+ list[j].Name + " " + list[j].SID);
                    if (Convert.ToString(combos[i].Value) == list[j].Name + " " + list[j].SID)
                    {
                        //MessageBox.Show(Convert.ToString(combos[i].Value));
                        sens.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), list[j]);
                        break;
                    }
                }
            }
            //else
            //return null;
            /*}
            else checks[i].Checked = false;*/
            if (sens.Count == 0)
            {
                return null;
            }
            prof.Settings = sens;
            return prof;
        }

        public FormMeasureProfileSelect() : this(-1) { }

        public FormMeasureProfileSelect(int initProfile)
        {
            InitializeComponent();
            storedid = initProfile;
            fillProfiles(initProfile);
            /*foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewComboBoxCell cell = row.Cells[1] as DataGridViewComboBoxCell;
                combos.Add(cell);
            }*/
            //checks = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };

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
            /*if (comboBoxProfiles.SelectedItem != null)
                fillCombos(Program.Presets.CurrentProfile = comboBoxProfiles.SelectedItem as MeasureProfile);*/
            fillGridProfile(Program.Presets.CurrentProfile = comboBoxProfiles.SelectedItem as MeasureProfile);
        }

        bool checkSame()
        {
            List<Sensor> sensors = new List<Sensor>();
            for (int i = 0; i < combos.Count; i++)
                if (checks[i].Checked)
                    if (sensors.Contains(combos[i].Value as Sensor))
                        return false;
                    else
                        sensors.Add(combos[i].Value as Sensor);
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

                for (int pos = 0; pos < combos.Count; pos++)
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            flagMouseClick = true;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.dataGridView1.CurrentCell = cell;
                this.dataGridView1.BeginEdit(false);
            }
            if (e.ColumnIndex == 1)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridView1.BeginEdit(true);
                SendKeys.Send("{F4}");
                dataGridView1.BeginEdit(false);
            }
        }
        //  вылетает  ошибка  с профилем///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void dataGridView1_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            DataGridViewComboBoxCell dol = new DataGridViewComboBoxCell();
            dataGridView1.Rows.Add("", dol);
            combos.Clear();
            updateBoxes();
        }

        private void buttonDelRow_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            combos.Clear();
            updateBoxes();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (flagMouseClick)
            {
                if (dataGridView1[1, dataGridView1.CurrentRow.Index].Selected)
                {
                    int current = dataGridView1.CurrentRow.Index;
                    //MessageBox.Show(Convert.ToString(combos[current].Value) + "=" + Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value));       
                    //MessageBox.Show(Convert.ToString(combos[current].Value));
                    combos[current].Value = dataGridView1.CurrentRow.Cells[1].Value;
                    //MessageBox.Show(Convert.ToString(combos[current].Value));
                }
            }

        }
    }
}

