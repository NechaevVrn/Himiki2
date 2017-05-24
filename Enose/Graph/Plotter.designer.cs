namespace GUI
{
    partial class Plotter
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.axes = new System.Windows.Forms.PictureBox();
            this.indicator = new System.Windows.Forms.PictureBox();
            this.LabelNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicator)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.Location = new System.Drawing.Point(113, 35);
            this.canvas.MinimumSize = new System.Drawing.Size(10, 10);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(291, 127);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.Click += new System.EventHandler(this.canvas_Click);
            this.canvas.DragDrop += new System.Windows.Forms.DragEventHandler(this.canvas_DragDrop);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // axes
            // 
            this.axes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axes.Location = new System.Drawing.Point(3, 3);
            this.axes.Name = "axes";
            this.axes.Size = new System.Drawing.Size(434, 194);
            this.axes.TabIndex = 1;
            this.axes.TabStop = false;
            // 
            // indicator
            // 
            this.indicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.indicator.Location = new System.Drawing.Point(410, 3);
            this.indicator.Name = "indicator";
            this.indicator.Size = new System.Drawing.Size(27, 27);
            this.indicator.TabIndex = 2;
            this.indicator.TabStop = false;
            // 
            // LabelNum
            // 
            this.LabelNum.AutoSize = true;
            this.LabelNum.BackColor = System.Drawing.Color.Gainsboro;
            this.LabelNum.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelNum.Location = new System.Drawing.Point(3, 3);
            this.LabelNum.Name = "LabelNum";
            this.LabelNum.Size = new System.Drawing.Size(26, 27);
            this.LabelNum.TabIndex = 3;
            this.LabelNum.Text = "1";
            // 
            // Plotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LabelNum);
            this.Controls.Add(this.indicator);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.axes);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "Plotter";
            this.Size = new System.Drawing.Size(440, 200);
            this.VisibleChanged += new System.EventHandler(this.Plotter_Resize);
            this.Resize += new System.EventHandler(this.Plotter_Resize);
            this.MouseEnter += new System.EventHandler(this.Plotter_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.PictureBox axes;
        private System.Windows.Forms.PictureBox indicator;
        private System.Windows.Forms.Label LabelNum;
    }
}
