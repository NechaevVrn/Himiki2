namespace QuadroSoft.Enose
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новоеИзмерениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеСущностямиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистическаяОбработкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.созданиеМасокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеСенсоровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеПрофилейИзмеренийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортЭкспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьИзXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузитьВXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортВCSVutf8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортВCSVcp1251ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelProfile = new System.Windows.Forms.Label();
            this.comboBoxProfiles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.measureTree = new QuadroSoft.Enose.Graph.MeasureTree();
            this.multiGraph = new QuadroSoft.Enose.Graph.MultiGraph();
            this.menuStrip.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.управлениеСущностямиToolStripMenuItem,
            this.импортЭкспортToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1230, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новоеИзмерениеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.файлToolStripMenuItem.Text = "Измерение";
            // 
            // новоеИзмерениеToolStripMenuItem
            // 
            this.новоеИзмерениеToolStripMenuItem.Name = "новоеИзмерениеToolStripMenuItem";
            this.новоеИзмерениеToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.новоеИзмерениеToolStripMenuItem.Text = "Новое измерение";
            this.новоеИзмерениеToolStripMenuItem.Click += new System.EventHandler(this.новоеИзмерениеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // управлениеСущностямиToolStripMenuItem
            // 
            this.управлениеСущностямиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.статистическаяОбработкаToolStripMenuItem,
            this.созданиеМасокToolStripMenuItem,
            this.редактированиеСенсоровToolStripMenuItem,
            this.редактированиеПрофилейИзмеренийToolStripMenuItem});
            this.управлениеСущностямиToolStripMenuItem.Name = "управлениеСущностямиToolStripMenuItem";
            this.управлениеСущностямиToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.управлениеСущностямиToolStripMenuItem.Text = "Сервис";
            // 
            // статистическаяОбработкаToolStripMenuItem
            // 
            this.статистическаяОбработкаToolStripMenuItem.Name = "статистическаяОбработкаToolStripMenuItem";
            this.статистическаяОбработкаToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.статистическаяОбработкаToolStripMenuItem.Text = "Статистическая обработка";
            this.статистическаяОбработкаToolStripMenuItem.Click += new System.EventHandler(this.статистическаяОбработкаToolStripMenuItem_Click);
            // 
            // созданиеМасокToolStripMenuItem
            // 
            this.созданиеМасокToolStripMenuItem.Name = "созданиеМасокToolStripMenuItem";
            this.созданиеМасокToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.созданиеМасокToolStripMenuItem.Text = "Редактирование масок";
            this.созданиеМасокToolStripMenuItem.Click += new System.EventHandler(this.созданиеМасокToolStripMenuItem_Click);
            // 
            // редактированиеСенсоровToolStripMenuItem
            // 
            this.редактированиеСенсоровToolStripMenuItem.Name = "редактированиеСенсоровToolStripMenuItem";
            this.редактированиеСенсоровToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.редактированиеСенсоровToolStripMenuItem.Text = "Редактирование сенсоров";
            this.редактированиеСенсоровToolStripMenuItem.Click += new System.EventHandler(this.редактированиеСенсоровToolStripMenuItem_Click);
            // 
            // редактированиеПрофилейИзмеренийToolStripMenuItem
            // 
            this.редактированиеПрофилейИзмеренийToolStripMenuItem.Name = "редактированиеПрофилейИзмеренийToolStripMenuItem";
            this.редактированиеПрофилейИзмеренийToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.редактированиеПрофилейИзмеренийToolStripMenuItem.Text = "Настройка профилей измерений";
            this.редактированиеПрофилейИзмеренийToolStripMenuItem.Click += new System.EventHandler(this.редактированиеПрофилейИзмеренийToolStripMenuItem_Click);
            // 
            // импортЭкспортToolStripMenuItem
            // 
            this.импортЭкспортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьИзXMLToolStripMenuItem,
            this.выгрузитьВXMLToolStripMenuItem,
            this.экспортВCSVutf8ToolStripMenuItem,
            this.экспортВCSVcp1251ToolStripMenuItem});
            this.импортЭкспортToolStripMenuItem.Name = "импортЭкспортToolStripMenuItem";
            this.импортЭкспортToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.импортЭкспортToolStripMenuItem.Text = "Импорт/Экспорт";
            // 
            // загрузитьИзXMLToolStripMenuItem
            // 
            this.загрузитьИзXMLToolStripMenuItem.Name = "загрузитьИзXMLToolStripMenuItem";
            this.загрузитьИзXMLToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.загрузитьИзXMLToolStripMenuItem.Text = "Импорт из XML";
            this.загрузитьИзXMLToolStripMenuItem.Click += new System.EventHandler(this.загрузитьИзXMLToolStripMenuItem_Click);
            // 
            // выгрузитьВXMLToolStripMenuItem
            // 
            this.выгрузитьВXMLToolStripMenuItem.Name = "выгрузитьВXMLToolStripMenuItem";
            this.выгрузитьВXMLToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.выгрузитьВXMLToolStripMenuItem.Text = "Экспорт в XML (utf-8)";
            this.выгрузитьВXMLToolStripMenuItem.Click += new System.EventHandler(this.выгрузитьВXMLToolStripMenuItem_Click);
            // 
            // экспортВCSVutf8ToolStripMenuItem
            // 
            this.экспортВCSVutf8ToolStripMenuItem.Name = "экспортВCSVutf8ToolStripMenuItem";
            this.экспортВCSVutf8ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.экспортВCSVutf8ToolStripMenuItem.Text = "Экспорт в CSV (utf-8)";
            this.экспортВCSVutf8ToolStripMenuItem.Click += new System.EventHandler(this.экспортВCSVutf8ToolStripMenuItem_Click);
            // 
            // экспортВCSVcp1251ToolStripMenuItem
            // 
            this.экспортВCSVcp1251ToolStripMenuItem.Name = "экспортВCSVcp1251ToolStripMenuItem";
            this.экспортВCSVcp1251ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.экспортВCSVcp1251ToolStripMenuItem.Text = "Экспорт в CSV (cp-1251)";
            this.экспортВCSVcp1251ToolStripMenuItem.Click += new System.EventHandler(this.экспортВCSVcp1251ToolStripMenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Location = new System.Drawing.Point(0, 27);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.measureTree);
            this.splitContainer.Panel1MinSize = 312;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.labelProfile);
            this.splitContainer.Panel2.Controls.Add(this.comboBoxProfiles);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Size = new System.Drawing.Size(1230, 674);
            this.splitContainer.SplitterDistance = 312;
            this.splitContainer.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.multiGraph);
            this.panel1.Location = new System.Drawing.Point(1, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 610);
            this.panel1.TabIndex = 5;
            // 
            // labelProfile
            // 
            this.labelProfile.AutoSize = true;
            this.labelProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProfile.Location = new System.Drawing.Point(8, 36);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(149, 16);
            this.labelProfile.TabIndex = 4;
            this.labelProfile.Text = "Профиль измерения :";
            // 
            // comboBoxProfiles
            // 
            this.comboBoxProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxProfiles.FormattingEnabled = true;
            this.comboBoxProfiles.Location = new System.Drawing.Point(163, 33);
            this.comboBoxProfiles.Name = "comboBoxProfiles";
            this.comboBoxProfiles.Size = new System.Drawing.Size(275, 24);
            this.comboBoxProfiles.TabIndex = 3;
            this.comboBoxProfiles.SelectedIndexChanged += new System.EventHandler(this.comboBoxProfiles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Состояние сенсоров";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // measureTree
            // 
            this.measureTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.measureTree.Location = new System.Drawing.Point(0, 0);
            this.measureTree.MinimumSize = new System.Drawing.Size(310, 300);
            this.measureTree.Name = "measureTree";
            this.measureTree.Size = new System.Drawing.Size(312, 673);
            this.measureTree.TabIndex = 0;
            // 
            // multiGraph
            // 
            this.multiGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.multiGraph.BackColor = System.Drawing.SystemColors.Control;
            this.multiGraph.Location = new System.Drawing.Point(3, 3);
            this.multiGraph.Name = "multiGraph";
            this.multiGraph.Plotters = ((System.Collections.Generic.Dictionary<object, System.Windows.Forms.UserControl>)(resources.GetObject("multiGraph.Plotters")));
            this.multiGraph.Size = new System.Drawing.Size(902, 69);
            this.multiGraph.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 701);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "МАГ-8";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.Activated += new System.EventHandler(this.MainWindow_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QuadroSoft.Enose.Graph.MultiGraph multiGraph;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новоеИзмерениеToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem управлениеСущностямиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem созданиеМасокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private QuadroSoft.Enose.Graph.MeasureTree measureTree;
        private System.Windows.Forms.ToolStripMenuItem статистическаяОбработкаToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem импортЭкспортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзXMLToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьВXMLToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem экспортВCSVutf8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеСенсоровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортВCSVcp1251ToolStripMenuItem;
        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem редактированиеПрофилейИзмеренийToolStripMenuItem;
        public System.Windows.Forms.ComboBox comboBoxProfiles;


    }
}

