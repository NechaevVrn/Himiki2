namespace QuadroSoft.Enose.Dialogs
{
    partial class FormMeasureProfileSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxProfiles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveThis = new System.Windows.Forms.Button();
            this.buttonMeas = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownTime = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMasks = new System.Windows.Forms.ComboBox();
            this.labelmask = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.buttonDelRow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxProfiles
            // 
            this.comboBoxProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProfiles.FormattingEnabled = true;
            this.comboBoxProfiles.Location = new System.Drawing.Point(22, 38);
            this.comboBoxProfiles.Name = "comboBoxProfiles";
            this.comboBoxProfiles.Size = new System.Drawing.Size(403, 24);
            this.comboBoxProfiles.TabIndex = 16;
            this.comboBoxProfiles.SelectedIndexChanged += new System.EventHandler(this.comboBoxProfiles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Текущий профиль измерения";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(665, 523);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSaveThis
            // 
            this.buttonSaveThis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveThis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveThis.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveThis.Location = new System.Drawing.Point(470, 523);
            this.buttonSaveThis.Name = "buttonSaveThis";
            this.buttonSaveThis.Size = new System.Drawing.Size(189, 29);
            this.buttonSaveThis.TabIndex = 20;
            this.buttonSaveThis.Text = "Сохранить профиль";
            this.buttonSaveThis.UseVisualStyleBackColor = true;
            this.buttonSaveThis.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonMeas
            // 
            this.buttonMeas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMeas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMeas.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMeas.Location = new System.Drawing.Point(13, 523);
            this.buttonMeas.Name = "buttonMeas";
            this.buttonMeas.Size = new System.Drawing.Size(162, 29);
            this.buttonMeas.TabIndex = 21;
            this.buttonMeas.Text = "Старт измерения";
            this.buttonMeas.UseVisualStyleBackColor = true;
            this.buttonMeas.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDel.Location = new System.Drawing.Point(443, 38);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(27, 26);
            this.buttonDel.TabIndex = 22;
            this.buttonDel.Text = "X";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(21, 28);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(692, 22);
            this.textBoxName.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Наименование нового измерения";
            // 
            // numericUpDownTime
            // 
            this.numericUpDownTime.Location = new System.Drawing.Point(500, 210);
            this.numericUpDownTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTime.Name = "numericUpDownTime";
            this.numericUpDownTime.Size = new System.Drawing.Size(167, 22);
            this.numericUpDownTime.TabIndex = 25;
            this.numericUpDownTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownTime.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(481, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Длительность измерения (сек)";
         //   this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboBoxMasks
            // 
            this.comboBoxMasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMasks.FormattingEnabled = true;
            this.comboBoxMasks.Location = new System.Drawing.Point(500, 262);
            this.comboBoxMasks.Name = "comboBoxMasks";
            this.comboBoxMasks.Size = new System.Drawing.Size(165, 24);
            this.comboBoxMasks.TabIndex = 27;
            // 
            // labelmask
            // 
            this.labelmask.AutoSize = true;
            this.labelmask.Location = new System.Drawing.Point(481, 244);
            this.labelmask.Name = "labelmask";
            this.labelmask.Size = new System.Drawing.Size(208, 16);
            this.labelmask.TabIndex = 28;
            this.labelmask.Text = "Временная маска измерения";
            // 
            // splitContainer
            // 
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(1, 2);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.label2);
            this.splitContainer.Panel1.Controls.Add(this.textBoxName);
           // this.splitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer_Panel1_Paint);
            this.splitContainer.Panel1MinSize = 64;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.buttonDelRow);
            this.splitContainer.Panel2.Controls.Add(this.label4);
            this.splitContainer.Panel2.Controls.Add(this.buttonAddRow);
            this.splitContainer.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer.Panel2.Controls.Add(this.comboBoxProfiles);
            this.splitContainer.Panel2.Controls.Add(this.buttonMeas);
            this.splitContainer.Panel2.Controls.Add(this.labelmask);
            this.splitContainer.Panel2.Controls.Add(this.buttonSaveThis);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.comboBoxMasks);
            this.splitContainer.Panel2.Controls.Add(this.buttonCancel);
            this.splitContainer.Panel2.Controls.Add(this.buttonDel);
            this.splitContainer.Panel2.Controls.Add(this.numericUpDownTime);
            this.splitContainer.Panel2.Controls.Add(this.label3);
            this.splitContainer.Panel2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          //  this.splitContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer_Panel2_Paint);
            this.splitContainer.Panel2MinSize = 0;
            this.splitContainer.Size = new System.Drawing.Size(778, 647);
            this.splitContainer.SplitterDistance = 81;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 29;
            // 
            // buttonDelRow
            // 
            this.buttonDelRow.Location = new System.Drawing.Point(497, 127);
            this.buttonDelRow.Name = "buttonDelRow";
            this.buttonDelRow.Size = new System.Drawing.Size(167, 23);
            this.buttonDelRow.TabIndex = 35;
            this.buttonDelRow.Text = "Удалить";
            this.buttonDelRow.UseVisualStyleBackColor = true;
            this.buttonDelRow.Click += new System.EventHandler(this.buttonDelRow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(497, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "Редактирование";
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(497, 97);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(167, 23);
            this.buttonAddRow.TabIndex = 33;
            this.buttonAddRow.Text = "Добавить";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(450, 381);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // FormMeasureProfileSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximumSize = new System.Drawing.Size(800, 700);
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "FormMeasureProfileSelect";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Настройка профиля измерения";
        //    this.Load += new System.EventHandler(this.FormMeasureProfileSelect_Load);
            this.Shown += new System.EventHandler(this.FormMeasureProfileSelect_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxProfiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSaveThis;
        private System.Windows.Forms.Button buttonMeas;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxName;
        public System.Windows.Forms.NumericUpDown numericUpDownTime;
        private System.Windows.Forms.Label labelmask;
        public System.Windows.Forms.ComboBox comboBoxMasks;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonDelRow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddRow;
    }
}