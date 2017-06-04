namespace VILMS_UI_Win
{
    partial class FrmTopic
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
            this.grpTopics = new System.Windows.Forms.GroupBox();
            this.lstTopics = new System.Windows.Forms.ListBox();
            this.grpTopics.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTopics
            // 
            this.grpTopics.Controls.Add(this.lstTopics);
            this.grpTopics.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTopics.Location = new System.Drawing.Point(77, 61);
            this.grpTopics.Name = "grpTopics";
            this.grpTopics.Size = new System.Drawing.Size(432, 336);
            this.grpTopics.TabIndex = 2;
            this.grpTopics.TabStop = false;
            this.grpTopics.Text = "Topics";
            // 
            // lstTopics
            // 
            this.lstTopics.FormattingEnabled = true;
            this.lstTopics.ItemHeight = 24;
            this.lstTopics.Location = new System.Drawing.Point(6, 28);
            this.lstTopics.Name = "lstTopics";
            this.lstTopics.Size = new System.Drawing.Size(420, 292);
            this.lstTopics.TabIndex = 0;
            this.lstTopics.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstTopics_KeyDown);
            // 
            // FrmTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 462);
            this.Controls.Add(this.grpTopics);
            this.Name = "FrmTopic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Topics";
            this.Load += new System.EventHandler(this.FrmTopic_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTopic_KeyDown);
            this.grpTopics.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTopics;
        private System.Windows.Forms.ListBox lstTopics;
    }
}