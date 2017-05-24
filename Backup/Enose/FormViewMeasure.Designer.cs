namespace QuadroSoft.Enose
{
    partial class FormViewMeasure
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageRose = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpMax = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSet = new System.Windows.Forms.Button();
            this.минимум = new System.Windows.Forms.Label();
            this.numericMin = new System.Windows.Forms.NumericUpDown();
            this.buttonSaveTime = new System.Windows.Forms.Button();
            this.labelnobld = new System.Windows.Forms.Label();
            this.labelbld = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonMore = new System.Windows.Forms.Button();
            this.buttonLess = new System.Windows.Forms.Button();
            this.checkBoxThin = new System.Windows.Forms.CheckBox();
            this.checkBoxBold = new System.Windows.Forms.CheckBox();
            this.plotterBox = new Plotters.PlotterBox();
            this.tabPageLines = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonAutoPlotter = new System.Windows.Forms.Button();
            this.checkBoxAdjust = new System.Windows.Forms.CheckBox();
            this.plotter = new GUI.Plotter();
            this.tabPageMax = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericMaxMin = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numericMaxMax = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.btnFit = new System.Windows.Forms.Button();
            this.buttonMaxMore = new System.Windows.Forms.Button();
            this.buttonMaxLess = new System.Windows.Forms.Button();
            this.checkBoxMaxThin = new System.Windows.Forms.CheckBox();
            this.plotterBoxMax = new Plotters.PlotterBox();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.checkedListBoxSensors = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMask = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.textBoxArea = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonCSV = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonXML = new System.Windows.Forms.Button();
            this.dataColors = new System.Windows.Forms.DataGridView();
            this.Colors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl.SuspendLayout();
            this.tabPageRose.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMin)).BeginInit();
            this.tabPageLines.SuspendLayout();
            this.tabPageMax.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxMax)).BeginInit();
            this.tabInfo.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataColors)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageRose);
            this.tabControl.Controls.Add(this.tabPageLines);
            this.tabControl.Controls.Add(this.tabPageMax);
            this.tabControl.Controls.Add(this.tabInfo);
            this.tabControl.Location = new System.Drawing.Point(1, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(588, 574);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageRose
            // 
            this.tabPageRose.Controls.Add(this.button6);
            this.tabPageRose.Controls.Add(this.groupBox1);
            this.tabPageRose.Controls.Add(this.buttonSaveTime);
            this.tabPageRose.Controls.Add(this.labelnobld);
            this.tabPageRose.Controls.Add(this.labelbld);
            this.tabPageRose.Controls.Add(this.button1);
            this.tabPageRose.Controls.Add(this.buttonMore);
            this.tabPageRose.Controls.Add(this.buttonLess);
            this.tabPageRose.Controls.Add(this.checkBoxThin);
            this.tabPageRose.Controls.Add(this.checkBoxBold);
            this.tabPageRose.Controls.Add(this.plotterBox);
            this.tabPageRose.Location = new System.Drawing.Point(4, 22);
            this.tabPageRose.Name = "tabPageRose";
            this.tabPageRose.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRose.Size = new System.Drawing.Size(580, 548);
            this.tabPageRose.TabIndex = 0;
            this.tabPageRose.Text = "Временная";
            this.tabPageRose.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(559, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(18, 18);
            this.button6.TabIndex = 19;
            this.button6.Text = "+";
            this.button6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numericUpMax);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonSet);
            this.groupBox1.Controls.Add(this.минимум);
            this.groupBox1.Controls.Add(this.numericMin);
            this.groupBox1.Location = new System.Drawing.Point(458, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(116, 155);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Принудительный масштаб";
            // 
            // numericUpMax
            // 
            this.numericUpMax.Location = new System.Drawing.Point(7, 91);
            this.numericUpMax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpMax.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpMax.Name = "numericUpMax";
            this.numericUpMax.Size = new System.Drawing.Size(103, 20);
            this.numericUpMax.TabIndex = 13;
            this.numericUpMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpMax.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "максимум";
            // 
            // buttonSet
            // 
            this.buttonSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSet.Location = new System.Drawing.Point(7, 117);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(103, 32);
            this.buttonSet.TabIndex = 14;
            this.buttonSet.Text = "Установить";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // минимум
            // 
            this.минимум.AutoSize = true;
            this.минимум.Location = new System.Drawing.Point(8, 36);
            this.минимум.Name = "минимум";
            this.минимум.Size = new System.Drawing.Size(54, 13);
            this.минимум.TabIndex = 15;
            this.минимум.Text = "минимум";
            // 
            // numericMin
            // 
            this.numericMin.Location = new System.Drawing.Point(5, 52);
            this.numericMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericMin.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericMin.Name = "numericMin";
            this.numericMin.Size = new System.Drawing.Size(105, 20);
            this.numericMin.TabIndex = 12;
            this.numericMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonSaveTime
            // 
            this.buttonSaveTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveTime.Location = new System.Drawing.Point(458, 393);
            this.buttonSaveTime.Name = "buttonSaveTime";
            this.buttonSaveTime.Size = new System.Drawing.Size(116, 37);
            this.buttonSaveTime.TabIndex = 17;
            this.buttonSaveTime.Text = "Сохранить изображение";
            this.buttonSaveTime.UseVisualStyleBackColor = true;
            this.buttonSaveTime.Click += new System.EventHandler(this.buttonSaveTime_Click);
            // 
            // labelnobld
            // 
            this.labelnobld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelnobld.AutoSize = true;
            this.labelnobld.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelnobld.Location = new System.Drawing.Point(543, 8);
            this.labelnobld.Name = "labelnobld";
            this.labelnobld.Size = new System.Drawing.Size(0, 16);
            this.labelnobld.TabIndex = 11;
            this.labelnobld.Visible = false;
            // 
            // labelbld
            // 
            this.labelbld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelbld.AutoSize = true;
            this.labelbld.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelbld.Location = new System.Drawing.Point(565, 3);
            this.labelbld.Name = "labelbld";
            this.labelbld.Size = new System.Drawing.Size(0, 16);
            this.labelbld.TabIndex = 10;
            this.labelbld.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(458, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "Автомасштаб";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonMore
            // 
            this.buttonMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMore.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonMore.ForeColor = System.Drawing.Color.Black;
            this.buttonMore.Location = new System.Drawing.Point(525, 259);
            this.buttonMore.Name = "buttonMore";
            this.buttonMore.Size = new System.Drawing.Size(49, 40);
            this.buttonMore.TabIndex = 5;
            this.buttonMore.Text = "+";
            this.buttonMore.UseVisualStyleBackColor = true;
            this.buttonMore.Click += new System.EventHandler(this.buttonMore_Click);
            // 
            // buttonLess
            // 
            this.buttonLess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLess.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLess.Location = new System.Drawing.Point(458, 259);
            this.buttonLess.Name = "buttonLess";
            this.buttonLess.Size = new System.Drawing.Size(49, 40);
            this.buttonLess.TabIndex = 4;
            this.buttonLess.Text = "-";
            this.buttonLess.UseVisualStyleBackColor = true;
            this.buttonLess.Click += new System.EventHandler(this.buttonLess_Click);
            // 
            // checkBoxThin
            // 
            this.checkBoxThin.AutoSize = true;
            this.checkBoxThin.Location = new System.Drawing.Point(7, 27);
            this.checkBoxThin.Name = "checkBoxThin";
            this.checkBoxThin.Size = new System.Drawing.Size(157, 17);
            this.checkBoxThin.TabIndex = 3;
            this.checkBoxThin.Text = "Рисовать промежуточную";
            this.checkBoxThin.UseVisualStyleBackColor = true;
            this.checkBoxThin.CheckedChanged += new System.EventHandler(this.checkBoxThik_CheckedChanged);
            // 
            // checkBoxBold
            // 
            this.checkBoxBold.AutoSize = true;
            this.checkBoxBold.Checked = true;
            this.checkBoxBold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBold.Location = new System.Drawing.Point(7, 6);
            this.checkBoxBold.Name = "checkBoxBold";
            this.checkBoxBold.Size = new System.Drawing.Size(157, 17);
            this.checkBoxBold.TabIndex = 2;
            this.checkBoxBold.Text = "Рисовать основную сетку";
            this.checkBoxBold.UseVisualStyleBackColor = true;
            this.checkBoxBold.CheckedChanged += new System.EventHandler(this.checkBoxBold_CheckedChanged);
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
            this.plotterBox.DrawBoldLines = true;
            this.plotterBox.DrawThinLines = false;
            this.plotterBox.Gap = 60;
            this.plotterBox.Grades = 4;
            this.plotterBox.Location = new System.Drawing.Point(3, 50);
            this.plotterBox.MarkerGap = 10;
            this.plotterBox.MarkerStart = 0;
            this.plotterBox.Maximum = 10;
            this.plotterBox.Minimum = 0;
            this.plotterBox.Name = "plotterBox";
            this.plotterBox.Notes = null;
            this.plotterBox.SecondData = null;
            this.plotterBox.Size = new System.Drawing.Size(449, 491);
            this.plotterBox.TabIndex = 1;
            this.plotterBox.TextDist = 1.1;
            this.plotterBox.XFontCorrection = 5;
            // 
            // tabPageLines
            // 
            this.tabPageLines.Controls.Add(this.button3);
            this.tabPageLines.Controls.Add(this.buttonAutoPlotter);
            this.tabPageLines.Controls.Add(this.checkBoxAdjust);
            this.tabPageLines.Controls.Add(this.plotter);
            this.tabPageLines.Location = new System.Drawing.Point(4, 22);
            this.tabPageLines.Name = "tabPageLines";
            this.tabPageLines.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLines.Size = new System.Drawing.Size(580, 548);
            this.tabPageLines.TabIndex = 1;
            this.tabPageLines.Text = "График";
            this.tabPageLines.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(398, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 33);
            this.button3.TabIndex = 3;
            this.button3.Text = "Сохранить изображение";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonAutoPlotter
            // 
            this.buttonAutoPlotter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAutoPlotter.Location = new System.Drawing.Point(163, 7);
            this.buttonAutoPlotter.Name = "buttonAutoPlotter";
            this.buttonAutoPlotter.Size = new System.Drawing.Size(100, 33);
            this.buttonAutoPlotter.TabIndex = 2;
            this.buttonAutoPlotter.Text = "Автомасштаб";
            this.buttonAutoPlotter.UseVisualStyleBackColor = true;
            this.buttonAutoPlotter.Click += new System.EventHandler(this.buttonAutoPlotter_Click);
            // 
            // checkBoxAdjust
            // 
            this.checkBoxAdjust.AutoSize = true;
            this.checkBoxAdjust.Checked = true;
            this.checkBoxAdjust.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAdjust.Location = new System.Drawing.Point(7, 16);
            this.checkBoxAdjust.Name = "checkBoxAdjust";
            this.checkBoxAdjust.Size = new System.Drawing.Size(150, 17);
            this.checkBoxAdjust.TabIndex = 1;
            this.checkBoxAdjust.Text = "Автомасштаб по высоте";
            this.checkBoxAdjust.UseVisualStyleBackColor = true;
            this.checkBoxAdjust.CheckedChanged += new System.EventHandler(this.checkBoxAdjust_CheckedChanged);
            // 
            // plotter
            // 
            this.plotter.Adjusting = true;
            this.plotter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plotter.AxesColor = System.Drawing.Color.Black;
            this.plotter.BaseValue = 0;
            this.plotter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plotter.CornerLabel = "";
            this.plotter.CtrlPressed = false;
            this.plotter.CurveColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Orange,
        System.Drawing.Color.Lime,
        System.Drawing.Color.DarkGreen,
        System.Drawing.Color.LightBlue,
        System.Drawing.Color.Purple,
        System.Drawing.Color.DeepPink,
        System.Drawing.Color.Black,
        System.Drawing.Color.Aquamarine};
            this.plotter.Data = null;
            this.plotter.DotColor = System.Drawing.Color.OrangeRed;
            this.plotter.DownLabel = "";
            this.plotter.DrawBaseLine = false;
            this.plotter.DrawExtremum = true;
            this.plotter.DrawPoints = false;
            this.plotter.DrawVertical = true;
            this.plotter.DrawVerticalBold = true;
            this.plotter.ExtremumColor = System.Drawing.Color.Coral;
            this.plotter.Indicator = System.Drawing.Color.White;
            this.plotter.Label = "";
            this.plotter.LevelsColor = System.Drawing.Color.Gray;
            this.plotter.Location = new System.Drawing.Point(3, 55);
            this.plotter.MinimumSize = new System.Drawing.Size(110, 140);
            this.plotter.Name = "plotter";
            this.plotter.PenWidth = 2;
            this.plotter.SelectingColor = System.Drawing.Color.Gray;
            this.plotter.ShiftPressed = false;
            this.plotter.Size = new System.Drawing.Size(572, 484);
            this.plotter.SubLevelsColor = System.Drawing.Color.LightGray;
            this.plotter.TabIndex = 0;
            this.plotter.Xtext = "с";
            this.plotter.Ytext = "Гц";
            // 
            // tabPageMax
            // 
            this.tabPageMax.Controls.Add(this.groupBox2);
            this.tabPageMax.Controls.Add(this.button4);
            this.tabPageMax.Controls.Add(this.btnFit);
            this.tabPageMax.Controls.Add(this.buttonMaxMore);
            this.tabPageMax.Controls.Add(this.buttonMaxLess);
            this.tabPageMax.Controls.Add(this.checkBoxMaxThin);
            this.tabPageMax.Controls.Add(this.plotterBoxMax);
            this.tabPageMax.Location = new System.Drawing.Point(4, 22);
            this.tabPageMax.Name = "tabPageMax";
            this.tabPageMax.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMax.Size = new System.Drawing.Size(580, 548);
            this.tabPageMax.TabIndex = 2;
            this.tabPageMax.Text = "Диаграмма максимумов";
            this.tabPageMax.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericMaxMin);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericMaxMax);
            this.groupBox2.Location = new System.Drawing.Point(458, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(116, 155);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Принудительный масштаб";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "минимум";
            // 
            // numericMaxMin
            // 
            this.numericMaxMin.Location = new System.Drawing.Point(9, 57);
            this.numericMaxMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericMaxMin.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericMaxMin.Name = "numericMaxMin";
            this.numericMaxMin.Size = new System.Drawing.Size(101, 20);
            this.numericMaxMin.TabIndex = 17;
            this.numericMaxMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(9, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 27);
            this.button2.TabIndex = 19;
            this.button2.Text = "Установить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "максимум";
            // 
            // numericMaxMax
            // 
            this.numericMaxMax.Location = new System.Drawing.Point(9, 96);
            this.numericMaxMax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericMaxMax.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericMaxMax.Name = "numericMaxMax";
            this.numericMaxMax.Size = new System.Drawing.Size(101, 20);
            this.numericMaxMax.TabIndex = 18;
            this.numericMaxMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericMaxMax.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(467, 342);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 45);
            this.button4.TabIndex = 22;
            this.button4.Text = "Сохранить изображение";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnFit
            // 
            this.btnFit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFit.Location = new System.Drawing.Point(467, 269);
            this.btnFit.Name = "btnFit";
            this.btnFit.Size = new System.Drawing.Size(99, 27);
            this.btnFit.TabIndex = 8;
            this.btnFit.Text = "Автомасштаб";
            this.btnFit.UseVisualStyleBackColor = true;
            this.btnFit.Click += new System.EventHandler(this.btnFit_Click);
            // 
            // buttonMaxMore
            // 
            this.buttonMaxMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMaxMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxMore.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonMaxMore.ForeColor = System.Drawing.Color.Black;
            this.buttonMaxMore.Location = new System.Drawing.Point(524, 229);
            this.buttonMaxMore.Name = "buttonMaxMore";
            this.buttonMaxMore.Size = new System.Drawing.Size(42, 34);
            this.buttonMaxMore.TabIndex = 7;
            this.buttonMaxMore.Text = "+";
            this.buttonMaxMore.UseVisualStyleBackColor = true;
            this.buttonMaxMore.Click += new System.EventHandler(this.buttonMaxMore_Click);
            // 
            // buttonMaxLess
            // 
            this.buttonMaxLess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMaxLess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxLess.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMaxLess.Location = new System.Drawing.Point(467, 229);
            this.buttonMaxLess.Name = "buttonMaxLess";
            this.buttonMaxLess.Size = new System.Drawing.Size(42, 34);
            this.buttonMaxLess.TabIndex = 6;
            this.buttonMaxLess.Text = "-";
            this.buttonMaxLess.UseVisualStyleBackColor = true;
            this.buttonMaxLess.Click += new System.EventHandler(this.buttonMaxLess_Click);
            // 
            // checkBoxMaxThin
            // 
            this.checkBoxMaxThin.AutoSize = true;
            this.checkBoxMaxThin.Location = new System.Drawing.Point(7, 10);
            this.checkBoxMaxThin.Name = "checkBoxMaxThin";
            this.checkBoxMaxThin.Size = new System.Drawing.Size(105, 17);
            this.checkBoxMaxThin.TabIndex = 2;
            this.checkBoxMaxThin.Text = "Рисовать сетку";
            this.checkBoxMaxThin.UseVisualStyleBackColor = true;
            this.checkBoxMaxThin.CheckedChanged += new System.EventHandler(this.checkBoxMaxThin_CheckedChanged);
            // 
            // plotterBoxMax
            // 
            this.plotterBoxMax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plotterBoxMax.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plotterBoxMax.BackColor = System.Drawing.Color.Transparent;
            this.plotterBoxMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plotterBoxMax.Data = null;
            this.plotterBoxMax.DrawBoldLines = false;
            this.plotterBoxMax.DrawThinLines = true;
            this.plotterBoxMax.Gap = 60;
            this.plotterBoxMax.Grades = 4;
            this.plotterBoxMax.Location = new System.Drawing.Point(6, 33);
            this.plotterBoxMax.MarkerGap = 10;
            this.plotterBoxMax.MarkerStart = 0;
            this.plotterBoxMax.Maximum = 10;
            this.plotterBoxMax.Minimum = 0;
            this.plotterBoxMax.Name = "plotterBoxMax";
            this.plotterBoxMax.Notes = null;
            this.plotterBoxMax.SecondData = null;
            this.plotterBoxMax.Size = new System.Drawing.Size(446, 508);
            this.plotterBoxMax.TabIndex = 0;
            this.plotterBoxMax.TextDist = 1.1;
            this.plotterBoxMax.XFontCorrection = 5;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.richTextBox);
            this.tabInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(580, 548);
            this.tabInfo.TabIndex = 3;
            this.tabInfo.Text = "Сводная информация";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox.Location = new System.Drawing.Point(6, 6);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(569, 535);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // checkedListBoxSensors
            // 
            this.checkedListBoxSensors.CheckOnClick = true;
            this.checkedListBoxSensors.FormattingEnabled = true;
            this.checkedListBoxSensors.Location = new System.Drawing.Point(29, 120);
            this.checkedListBoxSensors.Name = "checkedListBoxSensors";
            this.checkedListBoxSensors.Size = new System.Drawing.Size(147, 274);
            this.checkedListBoxSensors.TabIndex = 1;
            this.checkedListBoxSensors.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxSensors_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Отображаемые сенсоры";
            // 
            // comboBoxMask
            // 
            this.comboBoxMask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMask.FormattingEnabled = true;
            this.comboBoxMask.Location = new System.Drawing.Point(6, 27);
            this.comboBoxMask.Name = "comboBoxMask";
            this.comboBoxMask.Size = new System.Drawing.Size(168, 21);
            this.comboBoxMask.TabIndex = 3;
            this.comboBoxMask.SelectedIndexChanged += new System.EventHandler(this.comboBoxMask_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Временная маска";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.button5);
            this.panel.Controls.Add(this.textBoxArea);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.buttonCSV);
            this.panel.Controls.Add(this.buttonSave);
            this.panel.Controls.Add(this.buttonXML);
            this.panel.Controls.Add(this.dataColors);
            this.panel.Controls.Add(this.comboBoxMask);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.checkedListBoxSensors);
            this.panel.Controls.Add(this.label2);
            this.panel.Location = new System.Drawing.Point(591, 34);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(179, 548);
            this.panel.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(7, 472);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(169, 30);
            this.button5.TabIndex = 11;
            this.button5.Text = "Выгрузить в CSV (cp-1251)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBoxArea
            // 
            this.textBoxArea.Location = new System.Drawing.Point(7, 71);
            this.textBoxArea.Name = "textBoxArea";
            this.textBoxArea.ReadOnly = true;
            this.textBoxArea.Size = new System.Drawing.Size(167, 20);
            this.textBoxArea.TabIndex = 10;
            this.textBoxArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Площадь отпечатка";
            // 
            // buttonCSV
            // 
            this.buttonCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCSV.Location = new System.Drawing.Point(7, 436);
            this.buttonCSV.Name = "buttonCSV";
            this.buttonCSV.Size = new System.Drawing.Size(169, 30);
            this.buttonCSV.TabIndex = 8;
            this.buttonCSV.Text = "Выгрузить в CSV (utf-8)";
            this.buttonCSV.UseVisualStyleBackColor = true;
            this.buttonCSV.Click += new System.EventHandler(this.buttonCSV_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(7, 508);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(169, 30);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonXML
            // 
            this.buttonXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonXML.Location = new System.Drawing.Point(6, 400);
            this.buttonXML.Name = "buttonXML";
            this.buttonXML.Size = new System.Drawing.Size(170, 30);
            this.buttonXML.TabIndex = 6;
            this.buttonXML.Text = "Выгрузить в XML (utf-8)";
            this.buttonXML.UseVisualStyleBackColor = true;
            this.buttonXML.Click += new System.EventHandler(this.buttonXML_Click);
            // 
            // dataColors
            // 
            this.dataColors.AllowUserToAddRows = false;
            this.dataColors.AllowUserToDeleteRows = false;
            this.dataColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataColors.ColumnHeadersVisible = false;
            this.dataColors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Colors});
            this.dataColors.Enabled = false;
            this.dataColors.Location = new System.Drawing.Point(6, 120);
            this.dataColors.MultiSelect = false;
            this.dataColors.Name = "dataColors";
            this.dataColors.ReadOnly = true;
            this.dataColors.RowHeadersVisible = false;
            this.dataColors.RowTemplate.Height = 15;
            this.dataColors.Size = new System.Drawing.Size(24, 274);
            this.dataColors.TabIndex = 5;
            // 
            // Colors
            // 
            this.Colors.HeaderText = "colors";
            this.Colors.Name = "Colors";
            this.Colors.ReadOnly = true;
            this.Colors.Width = 20;
            // 
            // FormViewMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 587);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(729, 558);
            this.Name = "FormViewMeasure";
            this.ShowIcon = false;
            this.Text = "Просмотр измерения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormViewMeasure_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPageRose.ResumeLayout(false);
            this.tabPageRose.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMin)).EndInit();
            this.tabPageLines.ResumeLayout(false);
            this.tabPageLines.PerformLayout();
            this.tabPageMax.ResumeLayout(false);
            this.tabPageMax.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxMax)).EndInit();
            this.tabInfo.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataColors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageRose;
        private System.Windows.Forms.TabPage tabPageLines;
        private System.Windows.Forms.CheckedListBox checkedListBoxSensors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel;
        private Plotters.PlotterBox plotterBox;
        private GUI.Plotter plotter;
        private System.Windows.Forms.DataGridView dataColors;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colors;
        private System.Windows.Forms.CheckBox checkBoxBold;
        private System.Windows.Forms.CheckBox checkBoxThin;
        private System.Windows.Forms.CheckBox checkBoxAdjust;
        private System.Windows.Forms.TabPage tabPageMax;
        private Plotters.PlotterBox plotterBoxMax;
        private System.Windows.Forms.CheckBox checkBoxMaxThin;
        private System.Windows.Forms.Button buttonMore;
        private System.Windows.Forms.Button buttonLess;
        private System.Windows.Forms.Button buttonMaxMore;
        private System.Windows.Forms.Button buttonMaxLess;
        private System.Windows.Forms.Button buttonXML;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFit;
        private System.Windows.Forms.Button buttonAutoPlotter;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Label labelbld;
        private System.Windows.Forms.Label labelnobld;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCSV;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.NumericUpDown numericUpMax;
        private System.Windows.Forms.NumericUpDown numericMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label минимум;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericMaxMax;
        private System.Windows.Forms.NumericUpDown numericMaxMin;
        private System.Windows.Forms.Button buttonSaveTime;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBoxArea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}