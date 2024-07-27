namespace SCLIMS
{
    partial class Inventorymange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventorymange));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtClocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.default_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtIcode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbNwork = new System.Windows.Forms.RadioButton();
            this.rbWork = new System.Windows.Forms.RadioButton();
            this.btnclear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPlace = new System.Windows.Forms.ComboBox();
            this.locationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sclimsDataSet1 = new SCLIMS.sclimsDataSet1();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.txtDlocation = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtIname = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.locationsTableAdapter = new SCLIMS.sclimsDataSet1TableAdapters.locationsTableAdapter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sclimsDataSet5 = new SCLIMS.sclimsDataSet5();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new SCLIMS.sclimsDataSet5TableAdapters.usersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1210, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(304, 223);
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // txtClocation
            // 
            this.txtClocation.BackColor = System.Drawing.Color.White;
            this.txtClocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClocation.Location = new System.Drawing.Point(859, 107);
            this.txtClocation.Name = "txtClocation";
            this.txtClocation.Size = new System.Drawing.Size(197, 34);
            this.txtClocation.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(627, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 29);
            this.label3.TabIndex = 86;
            this.label3.Text = "Current Location";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.item_name,
            this.item_code,
            this.default_location,
            this.to_location,
            this.from_location,
            this.user_name,
            this.condition,
            this.status,
            this.select});
            this.dataGridView1.Location = new System.Drawing.Point(34, 376);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1650, 303);
            this.dataGridView1.TabIndex = 85;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // date
            // 
            this.date.HeaderText = "Date";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 125;
            // 
            // item_name
            // 
            this.item_name.HeaderText = "Item Name";
            this.item_name.MinimumWidth = 6;
            this.item_name.Name = "item_name";
            this.item_name.ReadOnly = true;
            this.item_name.Width = 125;
            // 
            // item_code
            // 
            this.item_code.HeaderText = "Item Code";
            this.item_code.MinimumWidth = 6;
            this.item_code.Name = "item_code";
            this.item_code.Width = 125;
            // 
            // default_location
            // 
            this.default_location.HeaderText = "Default Location";
            this.default_location.MinimumWidth = 6;
            this.default_location.Name = "default_location";
            this.default_location.ReadOnly = true;
            this.default_location.Width = 150;
            // 
            // to_location
            // 
            this.to_location.HeaderText = "To Location";
            this.to_location.MinimumWidth = 6;
            this.to_location.Name = "to_location";
            this.to_location.ReadOnly = true;
            this.to_location.Width = 125;
            // 
            // from_location
            // 
            this.from_location.HeaderText = "Current Location";
            this.from_location.MinimumWidth = 6;
            this.from_location.Name = "from_location";
            this.from_location.ReadOnly = true;
            this.from_location.Width = 130;
            // 
            // user_name
            // 
            this.user_name.HeaderText = "System User name";
            this.user_name.MinimumWidth = 6;
            this.user_name.Name = "user_name";
            this.user_name.Width = 125;
            // 
            // condition
            // 
            this.condition.HeaderText = "Condition";
            this.condition.MinimumWidth = 6;
            this.condition.Name = "condition";
            this.condition.Width = 125;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.Width = 120;
            // 
            // select
            // 
            this.select.HeaderText = "Select";
            this.select.MinimumWidth = 6;
            this.select.Name = "select";
            this.select.Width = 80;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1254, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(206, 24);
            this.comboBox1.TabIndex = 84;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.DarkCyan;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEnter.Location = new System.Drawing.Point(1258, 297);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(199, 44);
            this.btnEnter.TabIndex = 83;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(619, 272);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(203, 44);
            this.btnAdd.TabIndex = 80;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.DarkCyan;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(-21, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1395, 830);
            this.panel5.TabIndex = 39;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.cmbUsers);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.btnRemove);
            this.panel6.Controls.Add(this.txtIcode);
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Controls.Add(this.txtClocation);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.dataGridView1);
            this.panel6.Controls.Add(this.comboBox1);
            this.panel6.Controls.Add(this.btnEnter);
            this.panel6.Controls.Add(this.btnAdd);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.rbNwork);
            this.panel6.Controls.Add(this.rbWork);
            this.panel6.Controls.Add(this.btnclear);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.cmbPlace);
            this.panel6.Controls.Add(this.btnPrint);
            this.panel6.Controls.Add(this.btnTransfer);
            this.panel6.Controls.Add(this.txtDlocation);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.txtIname);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Location = new System.Drawing.Point(39, 14);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1339, 754);
            this.panel6.TabIndex = 33;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // cmbUsers
            // 
            this.cmbUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUsers.BackColor = System.Drawing.Color.White;
            this.cmbUsers.DataSource = this.usersBindingSource;
            this.cmbUsers.DisplayMember = "username";
            this.cmbUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(327, 223);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(197, 37);
            this.cmbUsers.TabIndex = 93;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(99, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 29);
            this.label4.TabIndex = 92;
            this.label4.Text = "User name";
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.DarkCyan;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemove.Location = new System.Drawing.Point(934, 719);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(203, 44);
            this.btnRemove.TabIndex = 90;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtIcode
            // 
            this.txtIcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtIcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtIcode.BackColor = System.Drawing.Color.White;
            this.txtIcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIcode.FormattingEnabled = true;
            this.txtIcode.Location = new System.Drawing.Point(327, 107);
            this.txtIcode.Name = "txtIcode";
            this.txtIcode.Size = new System.Drawing.Size(197, 37);
            this.txtIcode.TabIndex = 89;
            this.txtIcode.SelectedIndexChanged += new System.EventHandler(this.txtIcode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 29);
            this.label1.TabIndex = 74;
            this.label1.Text = "Item Code";
            // 
            // rbNwork
            // 
            this.rbNwork.AutoSize = true;
            this.rbNwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNwork.Location = new System.Drawing.Point(944, 169);
            this.rbNwork.Name = "rbNwork";
            this.rbNwork.Size = new System.Drawing.Size(123, 29);
            this.rbNwork.TabIndex = 70;
            this.rbNwork.TabStop = true;
            this.rbNwork.Text = "Not  work";
            this.rbNwork.UseVisualStyleBackColor = true;
            this.rbNwork.CheckedChanged += new System.EventHandler(this.rbNwork_CheckedChanged);
            // 
            // rbWork
            // 
            this.rbWork.AutoSize = true;
            this.rbWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWork.Location = new System.Drawing.Point(858, 169);
            this.rbWork.Name = "rbWork";
            this.rbWork.Size = new System.Drawing.Size(84, 29);
            this.rbWork.TabIndex = 69;
            this.rbWork.TabStop = true;
            this.rbWork.Text = "Work";
            this.rbWork.UseVisualStyleBackColor = true;
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.DarkCyan;
            this.btnclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnclear.Location = new System.Drawing.Point(864, 271);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(203, 44);
            this.btnclear.TabIndex = 67;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(628, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 29);
            this.label2.TabIndex = 64;
            this.label2.Text = "Condition";
            // 
            // cmbPlace
            // 
            this.cmbPlace.BackColor = System.Drawing.Color.White;
            this.cmbPlace.DataSource = this.locationsBindingSource;
            this.cmbPlace.DisplayMember = "location_name";
            this.cmbPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlace.FormattingEnabled = true;
            this.cmbPlace.Location = new System.Drawing.Point(327, 47);
            this.cmbPlace.Name = "cmbPlace";
            this.cmbPlace.Size = new System.Drawing.Size(197, 37);
            this.cmbPlace.TabIndex = 63;
            this.cmbPlace.ValueMember = "location_name";
            this.cmbPlace.SelectedIndexChanged += new System.EventHandler(this.cmbPlace_SelectedIndexChanged);
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
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.Location = new System.Drawing.Point(678, 719);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(203, 44);
            this.btnPrint.TabIndex = 62;
            this.btnPrint.Text = "Genarate letter";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.DarkCyan;
            this.btnTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTransfer.Location = new System.Drawing.Point(414, 719);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(203, 44);
            this.btnTransfer.TabIndex = 46;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // txtDlocation
            // 
            this.txtDlocation.BackColor = System.Drawing.Color.White;
            this.txtDlocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDlocation.Location = new System.Drawing.Point(859, 45);
            this.txtDlocation.Name = "txtDlocation";
            this.txtDlocation.Size = new System.Drawing.Size(197, 34);
            this.txtDlocation.TabIndex = 52;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(628, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(194, 29);
            this.label14.TabIndex = 51;
            this.label14.Text = "Default location";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(100, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 29);
            this.label15.TabIndex = 49;
            this.label15.Text = "To location";
            // 
            // txtIname
            // 
            this.txtIname.BackColor = System.Drawing.Color.White;
            this.txtIname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIname.Location = new System.Drawing.Point(327, 167);
            this.txtIname.Name = "txtIname";
            this.txtIname.Size = new System.Drawing.Size(197, 34);
            this.txtIname.TabIndex = 48;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(101, 172);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(134, 29);
            this.label16.TabIndex = 47;
            this.label16.Text = "Item name";
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
            // locationsTableAdapter
            // 
            this.locationsTableAdapter.ClearBeforeFill = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sclimsDataSet5
            // 
            this.sclimsDataSet5.DataSetName = "sclimsDataSet5";
            this.sclimsDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "users";
            this.usersBindingSource.DataSource = this.sclimsDataSet5;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // Inventorymange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 783);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inventorymange";
            this.Text = "Inventorymange";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inventorymange_FormClosing);
            this.Load += new System.EventHandler(this.Inventorymange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sclimsDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtClocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbNwork;
        private System.Windows.Forms.RadioButton rbWork;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPlace;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox txtDlocation;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtIname;
        private System.Windows.Forms.Label label16;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ComboBox txtIcode;
        private sclimsDataSet1 sclimsDataSet1;
        private System.Windows.Forms.BindingSource locationsBindingSource;
        private sclimsDataSet1TableAdapters.locationsTableAdapter locationsTableAdapter;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn default_location;
        private System.Windows.Forms.DataGridViewTextBoxColumn to_location;
        private System.Windows.Forms.DataGridViewTextBoxColumn from_location;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn condition;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private sclimsDataSet5 sclimsDataSet5;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private sclimsDataSet5TableAdapters.usersTableAdapter usersTableAdapter;
    }
}