namespace Pla.Win
{
    partial class PlaWindow
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
            this.plaControl1 = new Pla.Win.PlaControl();
            this.SuspendLayout();
            // 
            // plaControl1
            // 
            this.plaControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plaControl1.Location = new System.Drawing.Point(0, 0);
            this.plaControl1.Margin = new System.Windows.Forms.Padding(0);
            this.plaControl1.Name = "plaControl1";
            this.plaControl1.Size = new System.Drawing.Size(804, 454);
            this.plaControl1.TabIndex = 0;
            // 
            // PlaWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.plaControl1);
            this.Name = "PlaWindow";
            this.Text = "PlaWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private PlaControl plaControl1;
    }
}