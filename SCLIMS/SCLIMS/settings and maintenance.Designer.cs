namespace SCLIMS
{
    partial class settings_and_maintenance
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
            this.btnLoc = new System.Windows.Forms.Button();
            this.settingPnl = new System.Windows.Forms.Panel();
            this.btnPchange = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.DarkCyan;
            this.btnLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(205, 14);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(188, 38);
            this.btnLoc.TabIndex = 7;
            this.btnLoc.Text = "Locations";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // settingPnl
            // 
            this.settingPnl.Location = new System.Drawing.Point(12, 86);
            this.settingPnl.Name = "settingPnl";
            this.settingPnl.Size = new System.Drawing.Size(776, 547);
            this.settingPnl.TabIndex = 6;
            this.settingPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.settingPnl_Paint);
            // 
            // btnPchange
            // 
            this.btnPchange.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPchange.ForeColor = System.Drawing.Color.White;
            this.btnPchange.Location = new System.Drawing.Point(400, 14);
            this.btnPchange.Name = "btnPchange";
            this.btnPchange.Size = new System.Drawing.Size(188, 38);
            this.btnPchange.TabIndex = 5;
            this.btnPchange.Text = "Password change";
            this.btnPchange.UseVisualStyleBackColor = false;
            this.btnPchange.Click += new System.EventHandler(this.btnPchange_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.DarkCyan;
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Location = new System.Drawing.Point(13, 14);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(188, 38);
            this.btnUsers.TabIndex = 4;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkCyan;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(595, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "Category";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // settings_and_maintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 645);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.settingPnl);
            this.Controls.Add(this.btnPchange);
            this.Controls.Add(this.btnUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "settings_and_maintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.settings_and_maintenance_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Panel settingPnl;
        private System.Windows.Forms.Button btnPchange;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button button1;
    }
}