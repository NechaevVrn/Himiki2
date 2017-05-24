namespace QuadroSoft.Enose.Dialogs
{
    partial class FormSaveProfileType
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
            this.radioButtonRewrite = new System.Windows.Forms.RadioButton();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.labelNowProfile = new System.Windows.Forms.Label();
            this.labelNewName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButtonRewrite
            // 
            this.radioButtonRewrite.AutoSize = true;
            this.radioButtonRewrite.Checked = true;
            this.radioButtonRewrite.Location = new System.Drawing.Point(31, 13);
            this.radioButtonRewrite.Name = "radioButtonRewrite";
            this.radioButtonRewrite.Size = new System.Drawing.Size(218, 20);
            this.radioButtonRewrite.TabIndex = 0;
            this.radioButtonRewrite.TabStop = true;
            this.radioButtonRewrite.Text = "Заменить текущий профиль";
            this.radioButtonRewrite.UseVisualStyleBackColor = true;
            // 
            // radioButtonNew
            // 
            this.radioButtonNew.AutoSize = true;
            this.radioButtonNew.Location = new System.Drawing.Point(31, 55);
            this.radioButtonNew.Name = "radioButtonNew";
            this.radioButtonNew.Size = new System.Drawing.Size(194, 20);
            this.radioButtonNew.TabIndex = 1;
            this.radioButtonNew.Text = "Создать новый профиль";
            this.radioButtonNew.UseVisualStyleBackColor = true;
            this.radioButtonNew.CheckedChanged += new System.EventHandler(this.radioButtonNew_CheckedChanged);
            // 
            // labelNowProfile
            // 
            this.labelNowProfile.AutoSize = true;
            this.labelNowProfile.Location = new System.Drawing.Point(64, 36);
            this.labelNowProfile.Name = "labelNowProfile";
            this.labelNowProfile.Size = new System.Drawing.Size(24, 16);
            this.labelNowProfile.TabIndex = 2;
            this.labelNowProfile.Text = "\"\"";
            // 
            // labelNewName
            // 
            this.labelNewName.AutoSize = true;
            this.labelNewName.Enabled = false;
            this.labelNewName.Location = new System.Drawing.Point(64, 90);
            this.labelNewName.Name = "labelNewName";
            this.labelNewName.Size = new System.Drawing.Size(72, 16);
            this.labelNewName.TabIndex = 3;
            this.labelNewName.Text = "Название";
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(141, 86);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 22);
            this.textBoxName.TabIndex = 4;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(31, 123);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(134, 29);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(187, 123);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(134, 29);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FormSaveProfileType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 166);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelNewName);
            this.Controls.Add(this.labelNowProfile);
            this.Controls.Add(this.radioButtonNew);
            this.Controls.Add(this.radioButtonRewrite);
            this.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximumSize = new System.Drawing.Size(351, 197);
            this.MinimumSize = new System.Drawing.Size(351, 197);
            this.Name = "FormSaveProfileType";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сохранение профиля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNewName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.RadioButton radioButtonRewrite;
        public System.Windows.Forms.RadioButton radioButtonNew;
        public System.Windows.Forms.TextBox textBoxName;
        public System.Windows.Forms.Label labelNowProfile;
    }
}