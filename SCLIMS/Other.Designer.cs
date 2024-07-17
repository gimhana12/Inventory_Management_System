namespace SCLIMS
{
    partial class Other
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
            this.otherPnl = new System.Windows.Forms.Panel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // otherPnl
            // 
            this.otherPnl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.otherPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.otherPnl.Location = new System.Drawing.Point(12, 102);
            this.otherPnl.Name = "otherPnl";
            this.otherPnl.Size = new System.Drawing.Size(1395, 760);
            this.otherPnl.TabIndex = 0;
            this.otherPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.otherPnl_Paint);
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.DarkCyan;
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnIssue.Location = new System.Drawing.Point(62, 29);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(119, 44);
            this.btnIssue.TabIndex = 0;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.DarkCyan;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReturn.Location = new System.Drawing.Point(200, 29);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(119, 44);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // Other
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 879);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.otherPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Other";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Other_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel otherPnl;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnReturn;
    }
}