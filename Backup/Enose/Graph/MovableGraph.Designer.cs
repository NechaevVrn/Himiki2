namespace QuadroSoft.Enose.Graph
{
    partial class MovableGraph
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericCorrecture = new System.Windows.Forms.NumericUpDown();
            this.labelCorr = new System.Windows.Forms.Label();
            this.buttonCan = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.plotter = new GUI.Plotter();
            ((System.ComponentModel.ISupportInitialize)(this.numericCorrecture)).BeginInit();
            this.SuspendLayout();
            // 
            // numericCorrecture
            // 
            this.numericCorrecture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericCorrecture.DecimalPlaces = 2;
            this.numericCorrecture.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericCorrecture.Location = new System.Drawing.Point(15, 225);
            this.numericCorrecture.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericCorrecture.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.numericCorrecture.Name = "numericCorrecture";
            this.numericCorrecture.Size = new System.Drawing.Size(155, 20);
            this.numericCorrecture.TabIndex = 1;
            this.numericCorrecture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericCorrecture.ThousandsSeparator = true;
            this.numericCorrecture.ValueChanged += new System.EventHandler(this.numericCorrecture_ValueChanged);
            // 
            // labelCorr
            // 
            this.labelCorr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCorr.AutoSize = true;
            this.labelCorr.Location = new System.Drawing.Point(12, 209);
            this.labelCorr.Name = "labelCorr";
            this.labelCorr.Size = new System.Drawing.Size(147, 13);
            this.labelCorr.TabIndex = 2;
            this.labelCorr.Text = "Смещение измерения (сек)";
            // 
            // buttonCan
            // 
            this.buttonCan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCan.Location = new System.Drawing.Point(215, 209);
            this.buttonCan.Name = "buttonCan";
            this.buttonCan.Size = new System.Drawing.Size(126, 36);
            this.buttonCan.TabIndex = 3;
            this.buttonCan.Text = "Автомасштаб";
            this.buttonCan.UseVisualStyleBackColor = true;
            this.buttonCan.Click += new System.EventHandler(this.buttonCan_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpen.Location = new System.Drawing.Point(347, 209);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(126, 36);
            this.buttonOpen.TabIndex = 4;
            this.buttonOpen.Text = "Просмотр";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // plotter
            // 
            this.plotter.Adjusting = true;
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
            this.plotter.Location = new System.Drawing.Point(3, 3);
            this.plotter.MinimumSize = new System.Drawing.Size(110, 140);
            this.plotter.Name = "plotter";
            this.plotter.PenWidth = 1;
            this.plotter.SelectingColor = System.Drawing.Color.Gray;
            this.plotter.ShiftPressed = false;
            this.plotter.Size = new System.Drawing.Size(733, 193);
            this.plotter.SubLevelsColor = System.Drawing.Color.LightGray;
            this.plotter.TabIndex = 0;
            this.plotter.Xtext = "с";
            this.plotter.Ytext = "Гц";
            // 
            // MovableGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonCan);
            this.Controls.Add(this.labelCorr);
            this.Controls.Add(this.numericCorrecture);
            this.Controls.Add(this.plotter);
            this.MinimumSize = new System.Drawing.Size(739, 259);
            this.Name = "MovableGraph";
            this.Size = new System.Drawing.Size(739, 259);
            ((System.ComponentModel.ISupportInitialize)(this.numericCorrecture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GUI.Plotter plotter;
        private System.Windows.Forms.NumericUpDown numericCorrecture;
        private System.Windows.Forms.Label labelCorr;
        private System.Windows.Forms.Button buttonCan;
        private System.Windows.Forms.Button buttonOpen;
    }
}
