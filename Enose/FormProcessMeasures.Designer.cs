namespace QuadroSoft.Enose
{
    partial class FormProcessMeasures
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProcessMeasures));
            this.listBoxMeasures = new System.Windows.Forms.ListBox();
            this.groupBoxMeasures = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBoxSensors = new System.Windows.Forms.CheckedListBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.multiGraph = new QuadroSoft.Enose.Graph.MultiGraph();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.movableGraphMedian = new QuadroSoft.Enose.Graph.MovableGraph();
            this.labelSen = new System.Windows.Forms.Label();
            this.comboBoxMasks = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxAlgs = new System.Windows.Forms.GroupBox();
            this.buttonMiddle = new System.Windows.Forms.Button();
            this.buttonStat = new System.Windows.Forms.Button();
            this.groupBoxMeasures.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxAlgs.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxMeasures
            // 
            this.listBoxMeasures.FormattingEnabled = true;
            this.listBoxMeasures.ItemHeight = 14;
            this.listBoxMeasures.Location = new System.Drawing.Point(6, 20);
            this.listBoxMeasures.Name = "listBoxMeasures";
            this.listBoxMeasures.Size = new System.Drawing.Size(181, 172);
            this.listBoxMeasures.TabIndex = 1;
            // 
            // groupBoxMeasures
            // 
            this.groupBoxMeasures.Controls.Add(this.buttonClear);
            this.groupBoxMeasures.Controls.Add(this.buttonDel);
            this.groupBoxMeasures.Controls.Add(this.button1);
            this.groupBoxMeasures.Controls.Add(this.listBoxMeasures);
            this.groupBoxMeasures.Location = new System.Drawing.Point(3, 3);
            this.groupBoxMeasures.Name = "groupBoxMeasures";
            this.groupBoxMeasures.Size = new System.Drawing.Size(196, 355);
            this.groupBoxMeasures.TabIndex = 2;
            this.groupBoxMeasures.TabStop = false;
            this.groupBoxMeasures.Text = "Используемые измерения";
            // 
            // buttonClear
            // 
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(6, 303);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(181, 45);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Очистить список";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDel.Location = new System.Drawing.Point(6, 251);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(181, 47);
            this.buttonDel.TabIndex = 3;
            this.buttonDel.Text = "Убрать выделенное";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(6, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Добавить измерение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBoxSensors
            // 
            this.checkedListBoxSensors.CheckOnClick = true;
            this.checkedListBoxSensors.FormattingEnabled = true;
            this.checkedListBoxSensors.Location = new System.Drawing.Point(9, 437);
            this.checkedListBoxSensors.Name = "checkedListBoxSensors";
            this.checkedListBoxSensors.Size = new System.Drawing.Size(181, 157);
            this.checkedListBoxSensors.TabIndex = 3;
            this.checkedListBoxSensors.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxSensors_MouseUp);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Location = new System.Drawing.Point(205, 3);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            this.splitContainer.Panel1MinSize = 250;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2.Controls.Add(this.textBoxName);
            this.splitContainer.Panel2.Controls.Add(this.label3);
            this.splitContainer.Panel2.Controls.Add(this.label);
            this.splitContainer.Panel2.Controls.Add(this.movableGraphMedian);
            this.splitContainer.Panel2Collapsed = true;
            this.splitContainer.Size = new System.Drawing.Size(829, 737);
            this.splitContainer.SplitterDistance = 430;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.multiGraph);
            this.panel1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 728);
            this.panel1.TabIndex = 1;
            // 
            // multiGraph
            // 
            this.multiGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.multiGraph.Location = new System.Drawing.Point(3, 3);
            this.multiGraph.Name = "multiGraph";
            this.multiGraph.Plotters = ((System.Collections.Generic.Dictionary<object, System.Windows.Forms.UserControl>)(resources.GetObject("multiGraph.Plotters")));
            this.multiGraph.Size = new System.Drawing.Size(746, 69);
            this.multiGraph.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Данное измерение не является статистически надёжным\r\nи не содержит статистических" +
                " данных";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(424, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(133, 22);
            this.textBoxName.TabIndex = 3;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Название:";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(200, 18);
            this.label.TabIndex = 1;
            this.label.Text = "Усреднённое измерение";
            // 
            // movableGraphMedian
            // 
            this.movableGraphMedian.BackColor = System.Drawing.Color.MediumTurquoise;
            this.movableGraphMedian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.movableGraphMedian.Correcture = 0;
            this.movableGraphMedian.Location = new System.Drawing.Point(3, 61);
            this.movableGraphMedian.Mask = null;
            this.movableGraphMedian.MinimumSize = new System.Drawing.Size(555, 202);
            this.movableGraphMedian.Name = "movableGraphMedian";
            this.movableGraphMedian.Size = new System.Drawing.Size(700, 215);
            this.movableGraphMedian.TabIndex = 0;
            // 
            // labelSen
            // 
            this.labelSen.AutoSize = true;
            this.labelSen.Location = new System.Drawing.Point(12, 420);
            this.labelSen.Name = "labelSen";
            this.labelSen.Size = new System.Drawing.Size(74, 14);
            this.labelSen.TabIndex = 5;
            this.labelSen.Text = "Все сенсоры";
            // 
            // comboBoxMasks
            // 
            this.comboBoxMasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMasks.FormattingEnabled = true;
            this.comboBoxMasks.Location = new System.Drawing.Point(9, 391);
            this.comboBoxMasks.Name = "comboBoxMasks";
            this.comboBoxMasks.Size = new System.Drawing.Size(181, 22);
            this.comboBoxMasks.TabIndex = 6;
            this.comboBoxMasks.SelectedIndexChanged += new System.EventHandler(this.comboBoxMasks_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Применяемая временная маска";
            // 
            // groupBoxAlgs
            // 
            this.groupBoxAlgs.Controls.Add(this.buttonMiddle);
            this.groupBoxAlgs.Controls.Add(this.buttonStat);
            this.groupBoxAlgs.Location = new System.Drawing.Point(3, 600);
            this.groupBoxAlgs.Name = "groupBoxAlgs";
            this.groupBoxAlgs.Size = new System.Drawing.Size(196, 121);
            this.groupBoxAlgs.TabIndex = 1;
            this.groupBoxAlgs.TabStop = false;
            this.groupBoxAlgs.Text = "Статистические алгоритмы";
            // 
            // buttonMiddle
            // 
            this.buttonMiddle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMiddle.Location = new System.Drawing.Point(6, 20);
            this.buttonMiddle.Name = "buttonMiddle";
            this.buttonMiddle.Size = new System.Drawing.Size(181, 44);
            this.buttonMiddle.TabIndex = 1;
            this.buttonMiddle.Text = "Расчёт статистически надёжного среднего";
            this.buttonMiddle.UseVisualStyleBackColor = true;
            this.buttonMiddle.Click += new System.EventHandler(this.buttonMiddle_Click);
            // 
            // buttonStat
            // 
            this.buttonStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStat.Location = new System.Drawing.Point(6, 71);
            this.buttonStat.Name = "buttonStat";
            this.buttonStat.Size = new System.Drawing.Size(181, 44);
            this.buttonStat.TabIndex = 1;
            this.buttonStat.Text = "Сравнение измерений";
            this.buttonStat.UseVisualStyleBackColor = true;
            this.buttonStat.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // FormProcessMeasures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 743);
            this.Controls.Add(this.groupBoxAlgs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxMasks);
            this.Controls.Add(this.labelSen);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.checkedListBoxSensors);
            this.Controls.Add(this.groupBoxMeasures);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(949, 361);
            this.Name = "FormProcessMeasures";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Обработка";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBoxMeasures.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBoxAlgs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QuadroSoft.Enose.Graph.MultiGraph multiGraph;
        private System.Windows.Forms.ListBox listBoxMeasures;
        private System.Windows.Forms.GroupBox groupBoxMeasures;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.CheckedListBox checkedListBoxSensors;
        private System.Windows.Forms.SplitContainer splitContainer;
        private QuadroSoft.Enose.Graph.MovableGraph movableGraphMedian;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelSen;
        private System.Windows.Forms.ComboBox comboBoxMasks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxAlgs;
        private System.Windows.Forms.Button buttonStat;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMiddle;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label2;
    }
}