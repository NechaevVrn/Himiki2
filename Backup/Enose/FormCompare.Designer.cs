namespace QuadroSoft.Enose
{
    partial class FormCompare
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
            this.components = new System.ComponentModel.Container();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.BoldItalic = new System.Windows.Forms.Label();
            this.Normal = new System.Windows.Forms.Label();
            this.Italic = new System.Windows.Forms.Label();
            this.Bold = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBoxBase = new System.Windows.Forms.PictureBox();
            this.pictureBoxCompared = new System.Windows.Forms.PictureBox();
            this.pictureBoxSum = new System.Windows.Forms.PictureBox();
            this.labelBase = new System.Windows.Forms.Label();
            this.labelCompared = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxMain = new System.Windows.Forms.CheckBox();
            this.checkBoxAdd = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.plotterBox = new Plotters.PlotterBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompared)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSum)).BeginInit();
            this.SuspendLayout();
            // 
            // RTB
            // 
            this.RTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB.Location = new System.Drawing.Point(451, -1);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(378, 519);
            this.RTB.TabIndex = 1;
            this.RTB.Text = "";
            // 
            // BoldItalic
            // 
            this.BoldItalic.AutoSize = true;
            this.BoldItalic.Font = new System.Drawing.Font("Courier New", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BoldItalic.Location = new System.Drawing.Point(500, 295);
            this.BoldItalic.Name = "BoldItalic";
            this.BoldItalic.Size = new System.Drawing.Size(56, 16);
            this.BoldItalic.TabIndex = 8;
            this.BoldItalic.Text = "label2";
            this.BoldItalic.Visible = false;
            // 
            // Normal
            // 
            this.Normal.AutoSize = true;
            this.Normal.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Normal.Location = new System.Drawing.Point(500, 268);
            this.Normal.Name = "Normal";
            this.Normal.Size = new System.Drawing.Size(56, 16);
            this.Normal.TabIndex = 7;
            this.Normal.Text = "label1";
            this.Normal.Visible = false;
            // 
            // Italic
            // 
            this.Italic.AutoSize = true;
            this.Italic.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Italic.Location = new System.Drawing.Point(500, 239);
            this.Italic.Name = "Italic";
            this.Italic.Size = new System.Drawing.Size(56, 17);
            this.Italic.TabIndex = 6;
            this.Italic.Text = "label1";
            this.Italic.Visible = false;
            // 
            // Bold
            // 
            this.Bold.AutoSize = true;
            this.Bold.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bold.Location = new System.Drawing.Point(500, 212);
            this.Bold.Name = "Bold";
            this.Bold.Size = new System.Drawing.Size(56, 16);
            this.Bold.TabIndex = 5;
            this.Bold.Text = "label1";
            this.Bold.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 41);
            this.button1.TabIndex = 9;
            this.button1.Text = "Автомасштаб";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(149, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 41);
            this.button2.TabIndex = 10;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(204, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 41);
            this.button3.TabIndex = 11;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBoxBase
            // 
            this.pictureBoxBase.Location = new System.Drawing.Point(274, 2);
            this.pictureBoxBase.Name = "pictureBoxBase";
            this.pictureBoxBase.Size = new System.Drawing.Size(28, 27);
            this.pictureBoxBase.TabIndex = 12;
            this.pictureBoxBase.TabStop = false;
            // 
            // pictureBoxCompared
            // 
            this.pictureBoxCompared.Location = new System.Drawing.Point(274, 35);
            this.pictureBoxCompared.Name = "pictureBoxCompared";
            this.pictureBoxCompared.Size = new System.Drawing.Size(28, 27);
            this.pictureBoxCompared.TabIndex = 13;
            this.pictureBoxCompared.TabStop = false;
            // 
            // pictureBoxSum
            // 
            this.pictureBoxSum.Location = new System.Drawing.Point(274, 68);
            this.pictureBoxSum.Name = "pictureBoxSum";
            this.pictureBoxSum.Size = new System.Drawing.Size(28, 27);
            this.pictureBoxSum.TabIndex = 14;
            this.pictureBoxSum.TabStop = false;
            // 
            // labelBase
            // 
            this.labelBase.AutoSize = true;
            this.labelBase.Location = new System.Drawing.Point(308, 2);
            this.labelBase.Name = "labelBase";
            this.labelBase.Size = new System.Drawing.Size(109, 13);
            this.labelBase.TabIndex = 15;
            this.labelBase.Text = "Базовое измерение";
            // 
            // labelCompared
            // 
            this.labelCompared.AutoSize = true;
            this.labelCompared.Location = new System.Drawing.Point(308, 35);
            this.labelCompared.Name = "labelCompared";
            this.labelCompared.Size = new System.Drawing.Size(141, 13);
            this.labelCompared.TabIndex = 16;
            this.labelCompared.Text = "Сравниваемое измерение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Общая площадь";
            // 
            // checkBoxMain
            // 
            this.checkBoxMain.AutoSize = true;
            this.checkBoxMain.Location = new System.Drawing.Point(12, 49);
            this.checkBoxMain.Name = "checkBoxMain";
            this.checkBoxMain.Size = new System.Drawing.Size(108, 17);
            this.checkBoxMain.TabIndex = 18;
            this.checkBoxMain.Text = "Основная сетка";
            this.checkBoxMain.UseVisualStyleBackColor = true;
            this.checkBoxMain.CheckedChanged += new System.EventHandler(this.checkBoxMain_CheckedChanged);
            // 
            // checkBoxAdd
            // 
            this.checkBoxAdd.AutoSize = true;
            this.checkBoxAdd.Checked = true;
            this.checkBoxAdd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAdd.Location = new System.Drawing.Point(12, 72);
            this.checkBoxAdd.Name = "checkBoxAdd";
            this.checkBoxAdd.Size = new System.Drawing.Size(139, 17);
            this.checkBoxAdd.TabIndex = 19;
            this.checkBoxAdd.Text = "Промежуточная сетка";
            this.checkBoxAdd.UseVisualStyleBackColor = true;
            this.checkBoxAdd.CheckedChanged += new System.EventHandler(this.checkBoxAdd_CheckedChanged);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(149, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 40);
            this.button4.TabIndex = 20;
            this.button4.Text = "Сохранить изображение";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // plotterBox
            // 
            this.plotterBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plotterBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plotterBox.BackColor = System.Drawing.Color.Transparent;
            this.plotterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plotterBox.Data = null;
            this.plotterBox.DrawBoldLines = false;
            this.plotterBox.DrawThinLines = true;
            this.plotterBox.Gap = 60;
            this.plotterBox.Grades = 4;
            this.plotterBox.Location = new System.Drawing.Point(2, 101);
            this.plotterBox.MarkerGap = 10;
            this.plotterBox.MarkerStart = 0;
            this.plotterBox.Maximum = 10;
            this.plotterBox.Minimum = 0;
            this.plotterBox.Name = "plotterBox";
            this.plotterBox.Notes = null;
            this.plotterBox.SecondData = null;
            this.plotterBox.Size = new System.Drawing.Size(443, 420);
            this.plotterBox.TabIndex = 0;
            this.plotterBox.TextDist = 1.1000000238418579;
            this.plotterBox.XFontCorrection = 5;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FormCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 523);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkBoxAdd);
            this.Controls.Add(this.checkBoxMain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelCompared);
            this.Controls.Add(this.labelBase);
            this.Controls.Add(this.pictureBoxSum);
            this.Controls.Add(this.pictureBoxCompared);
            this.Controls.Add(this.pictureBoxBase);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RTB);
            this.Controls.Add(this.plotterBox);
            this.Controls.Add(this.BoldItalic);
            this.Controls.Add(this.Normal);
            this.Controls.Add(this.Italic);
            this.Controls.Add(this.Bold);
            this.MinimumSize = new System.Drawing.Size(839, 554);
            this.Name = "FormCompare";
            this.ShowIcon = false;
            this.Text = "Cравнение измерений";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompared)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Plotters.PlotterBox plotterBox;
        public System.Windows.Forms.RichTextBox RTB;
        public System.Windows.Forms.Label BoldItalic;
        public System.Windows.Forms.Label Normal;
        public System.Windows.Forms.Label Italic;
        public System.Windows.Forms.Label Bold;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBoxBase;
        private System.Windows.Forms.PictureBox pictureBoxCompared;
        private System.Windows.Forms.PictureBox pictureBoxSum;
        private System.Windows.Forms.Label labelBase;
        private System.Windows.Forms.Label labelCompared;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxMain;
        private System.Windows.Forms.CheckBox checkBoxAdd;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Timer timer;



    }
}