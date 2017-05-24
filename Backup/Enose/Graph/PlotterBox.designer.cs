namespace Plotters
{
    partial class PlotterBox
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
            this.components = new System.ComponentModel.Container();
            this.Canvas = new System.Windows.Forms.Panel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colorChanger = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьƒополнительный÷ветToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.AutoSize = true;
            this.Canvas.BackColor = System.Drawing.Color.Transparent;
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.ContextMenuStrip = this.contextMenuStrip;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.ForeColor = System.Drawing.Color.Transparent;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(2000, 2000);
            this.Canvas.TabIndex = 0;
            this.toolTip1.SetToolTip(this.Canvas, "Ќажмите правую кнопку мыши дл€ изменени€ цвета графика");
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
            this.Canvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorChanger,
            this.изменитьƒополнительный÷ветToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(251, 48);
            // 
            // colorChanger
            // 
            this.colorChanger.Name = "colorChanger";
            this.colorChanger.Size = new System.Drawing.Size(250, 22);
            this.colorChanger.Text = "»зменить основной цвет";
            this.colorChanger.Click += new System.EventHandler(this.colorChanger_Click);
            // 
            // изменитьƒополнительный÷ветToolStripMenuItem
            // 
            this.изменитьƒополнительный÷ветToolStripMenuItem.Name = "изменитьƒополнительный÷ветToolStripMenuItem";
            this.изменитьƒополнительный÷ветToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.изменитьƒополнительный÷ветToolStripMenuItem.Text = "»зменить дополнительный цвет";
            this.изменитьƒополнительный÷ветToolStripMenuItem.Click += new System.EventHandler(this.изменитьƒополнительный÷ветToolStripMenuItem_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipTitle = "»зменение цвета графика";
            // 
            // PlotterBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Canvas);
            this.Name = "PlotterBox";
            this.Size = new System.Drawing.Size(2000, 2000);
            this.Resize += new System.EventHandler(this.PlotterBox_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem colorChanger;
        private System.Windows.Forms.ToolStripMenuItem изменитьƒополнительный÷ветToolStripMenuItem;

    }
}
