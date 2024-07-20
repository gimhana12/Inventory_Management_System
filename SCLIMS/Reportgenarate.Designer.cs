namespace SCLIMS
{
    partial class Reportgenarate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reportgenarate));
            this.printDocument4 = new System.Drawing.Printing.PrintDocument();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIssued = new System.Windows.Forms.ComboBox();
            this.usersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sclimsDataSet8 = new SCLIMS.sclimsDataSet8();
            this.printDocument3 = new System.Drawing.Printing.PrintDocument();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sclimsDataSet7 = new SCLIMS.sclimsDataSet7();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbPLace = new System.Windows.Forms.ComboBox();
            this.locationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sclimsDataSet1 = new SCLIMS.sclimsDataSet1();
            this.label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel5 = new System.Windows.Forms.Panel();
            this.locationsTableAdapter = new SCLIMS.sclimsDataSet1TableAdapters.locationsTableAdapter();
            this.usersTableAdapter = new SCLIMS.sclimsDataSet7TableAdapters.usersTableAdapter();
            this.usersTableAdapter1 = new SCLIMS.sclimsDataSet8TableAdapters.usersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet8)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet1)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDocument4
            // 
            this.printDocument4.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument4_PrintPage);
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(974, 46);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(200, 22);
            this.date.TabIndex = 33;
            this.date.ValueChanged += new System.EventHandler(this.date_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(807, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(807, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 29;
            this.label3.Text = "Issued";
            // 
            // cmbIssued
            // 
            this.cmbIssued.DataSource = this.usersBindingSource1;
            this.cmbIssued.DisplayMember = "username";
            this.cmbIssued.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIssued.FormattingEnabled = true;
            this.cmbIssued.Location = new System.Drawing.Point(970, 111);
            this.cmbIssued.Margin = new System.Windows.Forms.Padding(4);
            this.cmbIssued.Name = "cmbIssued";
            this.cmbIssued.Size = new System.Drawing.Size(223, 32);
            this.cmbIssued.TabIndex = 28;
            this.cmbIssued.SelectedIndexChanged += new System.EventHandler(this.cmbIssued_SelectedIndexChanged);
            this.cmbIssued.Click += new System.EventHandler(this.cmbIssued_Click);
            // 
            // usersBindingSource1
            // 
            this.usersBindingSource1.DataMember = "users";
            this.usersBindingSource1.DataSource = this.sclimsDataSet8;
            // 
            // sclimsDataSet8
            // 
            this.sclimsDataSet8.DataSetName = "sclimsDataSet8";
            this.sclimsDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // printDocument3
            // 
            this.printDocument3.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument3_PrintPage);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.date);
            this.panel6.Controls.Add(this.btnGenerateReport);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.cmbIssued);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.cmbUsers);
            this.panel6.Controls.Add(this.dataGridView1);
            this.panel6.Controls.Add(this.cmbPLace);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Location = new System.Drawing.Point(580, 186);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1326, 714);
            this.panel6.TabIndex = 33;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.DarkCyan;
            this.btnGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(1052, 691);
            this.btnGenerateReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(168, 43);
            this.btnGenerateReport.TabIndex = 20;
            this.btnGenerateReport.Text = "Report Generate";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(201, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "User";
            // 
            // cmbUsers
            // 
            this.cmbUsers.DataSource = this.usersBindingSource;
            this.cmbUsers.DisplayMember = "username";
            this.cmbUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(368, 113);
            this.cmbUsers.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(223, 32);
            this.cmbUsers.TabIndex = 26;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            this.cmbUsers.Click += new System.EventHandler(this.cmbUsers_Click);
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "users";
            this.usersBindingSource.DataSource = this.sclimsDataSet7;
            // 
            // sclimsDataSet7
            // 
            this.sclimsDataSet7.DataSetName = "sclimsDataSet7";
            this.sclimsDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(82, 197);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1588, 492);
            this.dataGridView1.TabIndex = 25;
            // 
            // cmbPLace
            // 
            this.cmbPLace.DataSource = this.locationsBindingSource;
            this.cmbPLace.DisplayMember = "location_name";
            this.cmbPLace.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPLace.FormattingEnabled = true;
            this.cmbPLace.Location = new System.Drawing.Point(368, 46);
            this.cmbPLace.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPLace.Name = "cmbPLace";
            this.cmbPLace.Size = new System.Drawing.Size(223, 32);
            this.cmbPLace.TabIndex = 19;
            this.cmbPLace.SelectedIndexChanged += new System.EventHandler(this.cmbPLace_SelectedIndexChanged);
            this.cmbPLace.Click += new System.EventHandler(this.cmbPLace_Click);
            // 
            // locationsBindingSource
            // 
            this.locationsBindingSource.DataMember = "locations";
            this.locationsBindingSource.DataSource = this.sclimsDataSet1;
            // 
            // sclimsDataSet1
            // 
            this.sclimsDataSet1.DataSetName = "sclimsDataSet1";
            this.sclimsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Place";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.DarkCyan;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(-564, -173);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2487, 1084);
            this.panel5.TabIndex = 43;
            // 
            // locationsTableAdapter
            // 
            this.locationsTableAdapter.ClearBeforeFill = true;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // usersTableAdapter1
            // 
            this.usersTableAdapter1.ClearBeforeFill = true;
            // 
            // Reportgenarate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 738);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reportgenarate";
            this.Text = "Reportgenarate";
            this.Load += new System.EventHandler(this.Reportgenarate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet8)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument4;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbIssued;
        private System.Drawing.Printing.PrintDocument printDocument3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbPLace;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel panel5;
        private sclimsDataSet1 sclimsDataSet1;
        private System.Windows.Forms.BindingSource locationsBindingSource;
        private sclimsDataSet1TableAdapters.locationsTableAdapter locationsTableAdapter;
        private sclimsDataSet7 sclimsDataSet7;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private sclimsDataSet7TableAdapters.usersTableAdapter usersTableAdapter;
        private sclimsDataSet8 sclimsDataSet8;
        private System.Windows.Forms.BindingSource usersBindingSource1;
        private sclimsDataSet8TableAdapters.usersTableAdapter usersTableAdapter1;
    }
}