namespace QuadroSoft.Enose
{
    partial class FormMeasure
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelState = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonRepeat = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.plotter = new GUI.Plotter();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.СName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.СBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.СNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDeltaMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Position,
            this.СName,
            this.СBase,
            this.СNow,
            this.CDeltaMax});
            this.dataGridView1.Location = new System.Drawing.Point(664, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(343, 316);
            this.dataGridView1.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(664, 480);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(342, 34);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelState.Location = new System.Drawing.Point(12, 15);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(0, 17);
            this.labelState.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(117, 15);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(505, 20);
            this.progressBar.TabIndex = 4;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpen.Location = new System.Drawing.Point(664, 520);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(342, 34);
            this.buttonOpen.TabIndex = 5;
            this.buttonOpen.Text = "Перейти к измерению";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonRepeat
            // 
            this.buttonRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRepeat.Location = new System.Drawing.Point(664, 440);
            this.buttonRepeat.Name = "buttonRepeat";
            this.buttonRepeat.Size = new System.Drawing.Size(342, 34);
            this.buttonRepeat.TabIndex = 6;
            this.buttonRepeat.Text = "Повторить измерение";
            this.buttonRepeat.UseVisualStyleBackColor = true;
            this.buttonRepeat.Click += new System.EventHandler(this.buttonRepeat_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(664, 560);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(342, 34);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(507, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Автомасштаб";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // plotter
            // 
            this.plotter.Adjusting = false;
            this.plotter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plotter.AxesColor = System.Drawing.Color.Black;
            this.plotter.CtrlPressed = false;
            this.plotter.Data = null;
            this.plotter.DotColor = System.Drawing.Color.OrangeRed;
            this.plotter.DownLabel = "";
            this.plotter.DrawExtremum = false;
            this.plotter.DrawPoints = false;
            this.plotter.DrawVertical = true;
            this.plotter.DrawVerticalBold = true;
            this.plotter.ExtremumColor = System.Drawing.Color.Coral;
            this.plotter.Indicator = System.Drawing.Color.White;
            this.plotter.Label = "";
            this.plotter.LevelsColor = System.Drawing.Color.Gray;
            this.plotter.Location = new System.Drawing.Point(22, 70);
            this.plotter.MinimumSize = new System.Drawing.Size(110, 140);
            this.plotter.Name = "plotter";
            this.plotter.PenWidth = 1;
            this.plotter.SelectingColor = System.Drawing.Color.Gray;
            this.plotter.ShiftPressed = false;
            this.plotter.Size = new System.Drawing.Size(636, 553);
            this.plotter.SubLevelsColor = System.Drawing.Color.LightGray;
            this.plotter.TabIndex = 0;
            this.plotter.Xtext = "с";
            this.plotter.Ytext = "Гц";
            // 
            // Position
            // 
            this.Position.HeaderText = "№";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            this.Position.Width = 30;
            // 
            // СName
            // 
            this.СName.HeaderText = "Название";
            this.СName.Name = "СName";
            this.СName.ReadOnly = true;
            this.СName.Width = 115;
            // 
            // СBase
            // 
            this.СBase.HeaderText = "Старт";
            this.СBase.Name = "СBase";
            this.СBase.ReadOnly = true;
            this.СBase.Width = 60;
            // 
            // СNow
            // 
            this.СNow.HeaderText = "Текущее";
            this.СNow.Name = "СNow";
            this.СNow.ReadOnly = true;
            this.СNow.Width = 60;
            // 
            // CDeltaMax
            // 
            this.CDeltaMax.HeaderText = "Экстремум";
            this.CDeltaMax.Name = "CDeltaMax";
            this.CDeltaMax.ReadOnly = true;
            this.CDeltaMax.Width = 68;
            // 
            // FormMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 635);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonRepeat);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.plotter);
            this.Name = "FormMeasure";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Измерение";
            this.Shown += new System.EventHandler(this.FormMeasure_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMeasure_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GUI.Plotter plotter;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonRepeat;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn СName;
        private System.Windows.Forms.DataGridViewTextBoxColumn СBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn СNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDeltaMax;
    }
}