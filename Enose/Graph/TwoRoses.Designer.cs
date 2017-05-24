namespace QuadroSoft.Enose.Graph
{
    partial class TwoRoses
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
            this.plotterBoxUp = new Plotters.PlotterBox();
            this.plotterBoxDown = new Plotters.PlotterBox();
            this.SuspendLayout();
            // 
            // plotterBoxUp
            // 
            this.plotterBoxUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plotterBoxUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plotterBoxUp.BackColor = System.Drawing.Color.Transparent;
            this.plotterBoxUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plotterBoxUp.Data = null;
            this.plotterBoxUp.DrawBoldLines = true;
            this.plotterBoxUp.DrawThinLines = true;
            this.plotterBoxUp.ForeColor = System.Drawing.Color.Transparent;
            this.plotterBoxUp.Gap = 60;
            this.plotterBoxUp.Grades = 4;
            this.plotterBoxUp.Location = new System.Drawing.Point(24, 3);
            this.plotterBoxUp.MarkerGap = 10;
            this.plotterBoxUp.MarkerStart = 0;
            this.plotterBoxUp.Maximum = 10;
            this.plotterBoxUp.Minimum = 0;
            this.plotterBoxUp.Name = "plotterBoxUp";
            this.plotterBoxUp.Notes = null;
            this.plotterBoxUp.Size = new System.Drawing.Size(511, 530);
            this.plotterBoxUp.TabIndex = 1;
            this.plotterBoxUp.TextDist = 1.1000000238418579;
            this.plotterBoxUp.XFontCorrection = 5;
            // 
            // plotterBoxDown
            // 
            this.plotterBoxDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plotterBoxDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plotterBoxDown.BackColor = System.Drawing.Color.Transparent;
            this.plotterBoxDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plotterBoxDown.Data = null;
            this.plotterBoxDown.DrawBoldLines = true;
            this.plotterBoxDown.DrawThinLines = true;
            this.plotterBoxDown.Gap = 60;
            this.plotterBoxDown.Grades = 4;
            this.plotterBoxDown.Location = new System.Drawing.Point(3, 50);
            this.plotterBoxDown.MarkerGap = 10;
            this.plotterBoxDown.MarkerStart = 0;
            this.plotterBoxDown.Maximum = 10;
            this.plotterBoxDown.Minimum = 0;
            this.plotterBoxDown.Name = "plotterBoxDown";
            this.plotterBoxDown.Notes = null;
            this.plotterBoxDown.Size = new System.Drawing.Size(627, 483);
            this.plotterBoxDown.TabIndex = 0;
            this.plotterBoxDown.TextDist = 1.1000000238418579;
            this.plotterBoxDown.XFontCorrection = 5;
            // 
            // TwoRoses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plotterBoxUp);
            this.Controls.Add(this.plotterBoxDown);
            this.Name = "TwoRoses";
            this.Size = new System.Drawing.Size(633, 533);
            this.ResumeLayout(false);

        }

        #endregion

        private Plotters.PlotterBox plotterBoxDown;
        private Plotters.PlotterBox plotterBoxUp;
    }
}
