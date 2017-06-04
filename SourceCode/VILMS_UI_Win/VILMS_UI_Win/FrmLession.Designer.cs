namespace VILMS_UI_Win
{
    partial class frmLessions
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
            this.grpLessions = new System.Windows.Forms.GroupBox();
            this.lstLessions = new System.Windows.Forms.ListBox();
            this.grpLessions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLessions
            // 
            this.grpLessions.Controls.Add(this.lstLessions);
            this.grpLessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLessions.Location = new System.Drawing.Point(77, 61);
            this.grpLessions.Name = "grpLessions";
            this.grpLessions.Size = new System.Drawing.Size(432, 336);
            this.grpLessions.TabIndex = 1;
            this.grpLessions.TabStop = false;
            this.grpLessions.Text = "Lessions";
            // 
            // lstLessions
            // 
            this.lstLessions.FormattingEnabled = true;
            this.lstLessions.ItemHeight = 24;
            this.lstLessions.Location = new System.Drawing.Point(6, 28);
            this.lstLessions.Name = "lstLessions";
            this.lstLessions.Size = new System.Drawing.Size(420, 292);
            this.lstLessions.TabIndex = 0;
            this.lstLessions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstLessions_KeyDown);
            // 
            // frmLessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 462);
            this.Controls.Add(this.grpLessions);
            this.Name = "frmLessions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lessions";
            this.Load += new System.EventHandler(this.Lessions_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLessions_KeyDown);
            this.grpLessions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLessions;
        private System.Windows.Forms.ListBox lstLessions;
    }
}