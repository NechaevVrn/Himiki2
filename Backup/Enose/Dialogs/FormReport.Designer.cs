namespace QuadroSoft.Enose.Dialogs
{
    partial class FormReport
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
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.Bold = new System.Windows.Forms.Label();
            this.Italic = new System.Windows.Forms.Label();
            this.Normal = new System.Windows.Forms.Label();
            this.BoldItalic = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RTB
            // 
            this.RTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB.Location = new System.Drawing.Point(2, 1);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(765, 552);
            this.RTB.TabIndex = 0;
            this.RTB.Text = "";
            // 
            // Bold
            // 
            this.Bold.AutoSize = true;
            this.Bold.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bold.Location = new System.Drawing.Point(379, 138);
            this.Bold.Name = "Bold";
            this.Bold.Size = new System.Drawing.Size(56, 16);
            this.Bold.TabIndex = 1;
            this.Bold.Text = "label1";
            // 
            // Italic
            // 
            this.Italic.AutoSize = true;
            this.Italic.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Italic.Location = new System.Drawing.Point(379, 165);
            this.Italic.Name = "Italic";
            this.Italic.Size = new System.Drawing.Size(56, 17);
            this.Italic.TabIndex = 2;
            this.Italic.Text = "label1";
            // 
            // Normal
            // 
            this.Normal.AutoSize = true;
            this.Normal.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Normal.Location = new System.Drawing.Point(379, 194);
            this.Normal.Name = "Normal";
            this.Normal.Size = new System.Drawing.Size(56, 16);
            this.Normal.TabIndex = 3;
            this.Normal.Text = "label1";
            // 
            // BoldItalic
            // 
            this.BoldItalic.AutoSize = true;
            this.BoldItalic.Font = new System.Drawing.Font("Courier New", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BoldItalic.Location = new System.Drawing.Point(379, 221);
            this.BoldItalic.Name = "BoldItalic";
            this.BoldItalic.Size = new System.Drawing.Size(56, 16);
            this.BoldItalic.TabIndex = 4;
            this.BoldItalic.Text = "label2";
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 555);
            this.Controls.Add(this.RTB);
            this.Controls.Add(this.BoldItalic);
            this.Controls.Add(this.Normal);
            this.Controls.Add(this.Italic);
            this.Controls.Add(this.Bold);
            this.Name = "FormReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox RTB;
        public System.Windows.Forms.Label Bold;
        public System.Windows.Forms.Label Italic;
        public System.Windows.Forms.Label Normal;
        public System.Windows.Forms.Label BoldItalic;

    }
}