namespace QuadroSoft.Enose
{
    partial class FormExperiment
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
            this.checkBoxNA = new System.Windows.Forms.CheckBox();
            this.checkBoxDA = new System.Windows.Forms.CheckBox();
            this.labelVal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.extendedPlotterBoxD = new Plotters.ExtendedPlotterBox();
            this.extendedPlotterBoxN = new Plotters.ExtendedPlotterBox();
            this.SuspendLayout();
            // 
            // checkBoxNA
            // 
            this.checkBoxNA.AutoSize = true;
            this.checkBoxNA.Location = new System.Drawing.Point(12, 12);
            this.checkBoxNA.Name = "checkBoxNA";
            this.checkBoxNA.Size = new System.Drawing.Size(56, 17);
            this.checkBoxNA.TabIndex = 3;
            this.checkBoxNA.Text = "Сетка";
            this.checkBoxNA.UseVisualStyleBackColor = true;
            this.checkBoxNA.CheckedChanged += new System.EventHandler(this.checkBoxNA_CheckedChanged);
            // 
            // checkBoxDA
            // 
            this.checkBoxDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDA.AutoSize = true;
            this.checkBoxDA.Location = new System.Drawing.Point(583, 12);
            this.checkBoxDA.Name = "checkBoxDA";
            this.checkBoxDA.Size = new System.Drawing.Size(56, 17);
            this.checkBoxDA.TabIndex = 5;
            this.checkBoxDA.Text = "Сетка";
            this.checkBoxDA.UseVisualStyleBackColor = true;
            this.checkBoxDA.CheckedChanged += new System.EventHandler(this.checkBoxDA_CheckedChanged);
            // 
            // labelVal
            // 
            this.labelVal.AutoSize = true;
            this.labelVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVal.Location = new System.Drawing.Point(202, 11);
            this.labelVal.Name = "labelVal";
            this.labelVal.Size = new System.Drawing.Size(186, 16);
            this.labelVal.TabIndex = 6;
            this.labelVal.Text = "Интенсивность сигнала";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(745, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Производная интенсивности сигнала";
            // 
            // extendedPlotterBoxD
            // 
            this.extendedPlotterBoxD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.extendedPlotterBoxD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendedPlotterBoxD.BackColor = System.Drawing.Color.Transparent;
            this.extendedPlotterBoxD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extendedPlotterBoxD.Data = null;
            this.extendedPlotterBoxD.DrawBoldLines = false;
            this.extendedPlotterBoxD.DrawThinLines = false;
            this.extendedPlotterBoxD.Gap = 60;
            this.extendedPlotterBoxD.Grades = 4;
            this.extendedPlotterBoxD.Location = new System.Drawing.Point(583, 35);
            this.extendedPlotterBoxD.MarkerGap = 10;
            this.extendedPlotterBoxD.MarkerStart = 0;
            this.extendedPlotterBoxD.Maximum = 10;
            this.extendedPlotterBoxD.Minimum = 0;
            this.extendedPlotterBoxD.Name = "extendedPlotterBoxD";
            this.extendedPlotterBoxD.Notes = null;
            this.extendedPlotterBoxD.Size = new System.Drawing.Size(586, 599);
            this.extendedPlotterBoxD.TabIndex = 1;
            this.extendedPlotterBoxD.TextDist = 1.1;
            this.extendedPlotterBoxD.XFontCorrection = 5;
            // 
            // extendedPlotterBoxN
            // 
            this.extendedPlotterBoxN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.extendedPlotterBoxN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendedPlotterBoxN.BackColor = System.Drawing.Color.Transparent;
            this.extendedPlotterBoxN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extendedPlotterBoxN.Data = null;
            this.extendedPlotterBoxN.DrawBoldLines = false;
            this.extendedPlotterBoxN.DrawThinLines = false;
            this.extendedPlotterBoxN.Gap = 60;
            this.extendedPlotterBoxN.Grades = 4;
            this.extendedPlotterBoxN.Location = new System.Drawing.Point(12, 35);
            this.extendedPlotterBoxN.MarkerGap = 10;
            this.extendedPlotterBoxN.MarkerStart = 0;
            this.extendedPlotterBoxN.Maximum = 10;
            this.extendedPlotterBoxN.Minimum = 0;
            this.extendedPlotterBoxN.Name = "extendedPlotterBoxN";
            this.extendedPlotterBoxN.Notes = null;
            this.extendedPlotterBoxN.Size = new System.Drawing.Size(565, 599);
            this.extendedPlotterBoxN.TabIndex = 0;
            this.extendedPlotterBoxN.TextDist = 1.1;
            this.extendedPlotterBoxN.XFontCorrection = 5;
            // 
            // FormExperiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 646);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelVal);
            this.Controls.Add(this.checkBoxDA);
            this.Controls.Add(this.checkBoxNA);
            this.Controls.Add(this.extendedPlotterBoxD);
            this.Controls.Add(this.extendedPlotterBoxN);
            this.Name = "FormExperiment";
            this.ShowIcon = false;
            this.Text = "Диаграмма направленности";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Plotters.ExtendedPlotterBox extendedPlotterBoxN;
        public Plotters.ExtendedPlotterBox extendedPlotterBoxD;
        private System.Windows.Forms.CheckBox checkBoxNA;
        private System.Windows.Forms.CheckBox checkBoxDA;
        private System.Windows.Forms.Label labelVal;
        private System.Windows.Forms.Label label2;

    }
}