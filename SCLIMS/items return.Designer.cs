namespace SCLIMS
{
    partial class items_return
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(items_return));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbPlace = new System.Windows.Forms.ComboBox();
            this.locationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sclimsDataSet1 = new SCLIMS.sclimsDataSet1();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDlocation = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txti_code = new System.Windows.Forms.ComboBox();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sclimsDataSet4 = new SCLIMS.sclimsDataSet4();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtiname = new System.Windows.Forms.TextBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.locationsTableAdapter = new SCLIMS.sclimsDataSet1TableAdapters.locationsTableAdapter();
            this.itemsTableAdapter = new SCLIMS.sclimsDataSet4TableAdapters.itemsTableAdapter();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.default_ocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retrun = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1389, 691);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.cmbPlace);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txtDlocation);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txti_code);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtiname);
            this.panel2.Controls.Add(this.btnclear);
            this.panel2.Controls.Add(this.btnReturn);
            this.panel2.Location = new System.Drawing.Point(21, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1347, 656);
            this.panel2.TabIndex = 9;
            // 
            // cmbPlace
            // 
            this.cmbPlace.BackColor = System.Drawing.Color.White;
            this.cmbPlace.DataSource = this.locationsBindingSource;
            this.cmbPlace.DisplayMember = "location_name";
            this.cmbPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlace.FormattingEnabled = true;
            this.cmbPlace.Location = new System.Drawing.Point(423, 84);
            this.cmbPlace.Name = "cmbPlace";
            this.cmbPlace.Size = new System.Drawing.Size(197, 37);
            this.cmbPlace.TabIndex = 92;
            this.cmbPlace.ValueMember = "location_name";
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(200, 87);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 29);
            this.label15.TabIndex = 91;
            this.label15.Text = "To location";
            // 
            // txtDlocation
            // 
            this.txtDlocation.BackColor = System.Drawing.Color.White;
            this.txtDlocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDlocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDlocation.Location = new System.Drawing.Point(912, 90);
            this.txtDlocation.Name = "txtDlocation";
            this.txtDlocation.Size = new System.Drawing.Size(197, 34);
            this.txtDlocation.TabIndex = 90;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(682, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(194, 29);
            this.label14.TabIndex = 89;
            this.label14.Text = "Default location";
            // 
            // txti_code
            // 
            this.txti_code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txti_code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txti_code.BackColor = System.Drawing.Color.White;
            this.txti_code.DataSource = this.itemsBindingSource;
            this.txti_code.DisplayMember = "item_code";
            this.txti_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txti_code.FormattingEnabled = true;
            this.txti_code.Location = new System.Drawing.Point(423, 24);
            this.txti_code.Name = "txti_code";
            this.txti_code.Size = new System.Drawing.Size(197, 37);
            this.txti_code.TabIndex = 88;
            this.txti_code.ValueMember = "location_name";
            this.txti_code.SelectedIndexChanged += new System.EventHandler(this.txti_code_SelectedIndexChanged);
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "items";
            this.itemsBindingSource.DataSource = this.sclimsDataSet4;
            // 
            // sclimsDataSet4
            // 
            this.sclimsDataSet4.DataSetName = "sclimsDataSet4";
            this.sclimsDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd.Location = new System.Drawing.Point(416, 204);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(203, 44);
            this.btnAdd.TabIndex = 87;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.item_code,
            this.item_name,
            this.default_ocation,
            this.current_location,
            this.to_location,
            this.status,
            this.retrun});
            this.dataGridView1.Location = new System.Drawing.Point(132, 276);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1082, 258);
            this.dataGridView1.TabIndex = 86;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(202, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 29);
            this.label5.TabIndex = 52;
            this.label5.Text = "Item code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(686, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 29);
            this.label6.TabIndex = 50;
            this.label6.Text = "Item name";
            // 
            // txtiname
            // 
            this.txtiname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtiname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtiname.Location = new System.Drawing.Point(912, 24);
            this.txtiname.Name = "txtiname";
            this.txtiname.Size = new System.Drawing.Size(197, 34);
            this.txtiname.TabIndex = 49;
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.DarkCyan;
            this.btnclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnclear.Location = new System.Drawing.Point(691, 204);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(203, 44);
            this.btnclear.TabIndex = 48;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.DarkCyan;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReturn.Location = new System.Drawing.Point(661, 560);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(203, 44);
            this.btnReturn.TabIndex = 47;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // locationsTableAdapter
            // 
            this.locationsTableAdapter.ClearBeforeFill = true;
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
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
            // date
            // 
            this.date.HeaderText = "Date";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.Width = 80;
            // 
            // item_code
            // 
            this.item_code.HeaderText = "Item code";
            this.item_code.MinimumWidth = 6;
            this.item_code.Name = "item_code";
            this.item_code.Width = 125;
            // 
            // item_name
            // 
            this.item_name.HeaderText = "Item Name";
            this.item_name.MinimumWidth = 6;
            this.item_name.Name = "item_name";
            this.item_name.Width = 125;
            // 
            // default_ocation
            // 
            this.default_ocation.HeaderText = "Default_location";
            this.default_ocation.MinimumWidth = 6;
            this.default_ocation.Name = "default_ocation";
            this.default_ocation.Width = 125;
            // 
            // current_location
            // 
            this.current_location.HeaderText = "Current Location";
            this.current_location.MinimumWidth = 6;
            this.current_location.Name = "current_location";
            this.current_location.Width = 125;
            // 
            // to_location
            // 
            this.to_location.HeaderText = "To_location";
            this.to_location.MinimumWidth = 6;
            this.to_location.Name = "to_location";
            this.to_location.Width = 125;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.Width = 125;
            // 
            // retrun
            // 
            this.retrun.HeaderText = "Return";
            this.retrun.MinimumWidth = 6;
            this.retrun.Name = "retrun";
            this.retrun.Width = 125;
            // 
            // items_return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 713);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "items_return";
            this.Text = "items_return";
            this.Load += new System.EventHandler(this.items_return_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbPlace;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDlocation;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox txti_code;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtiname;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnReturn;
        private sclimsDataSet1 sclimsDataSet1;
        private System.Windows.Forms.BindingSource locationsBindingSource;
        private sclimsDataSet1TableAdapters.locationsTableAdapter locationsTableAdapter;
        private sclimsDataSet4 sclimsDataSet4;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private sclimsDataSet4TableAdapters.itemsTableAdapter itemsTableAdapter;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn default_ocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn current_location;
        private System.Windows.Forms.DataGridViewTextBoxColumn to_location;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn retrun;
    }
}