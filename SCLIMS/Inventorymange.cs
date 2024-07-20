using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using NPoco;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ZXing;

namespace SCLIMS
{
    public partial class Inventorymange : Form
    {

        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");
        public SqlCommand cmd;
        // SqlDataReader dr;

        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice captureDevice;

        public Inventorymange()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                // if (con.State == ConnectionState.Closed)
                //     con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM items WHERE item_code = @item_code", con))
                {
                    cmd.Parameters.AddWithValue("@item_code", txtIcode.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    
                    if (dt.Rows.Count > 0 && dt.Rows[0]["status"].ToString().ToLower() == "issued")
                    {
                        MessageBox.Show("This items is 'Issued' please check return  again.", "Invalid Transfer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtIname.Clear();
                        txtIcode.Text = "";
                        txtDlocation.Clear();
                        cmbPlace.Text = "";
                        rbNwork.Checked = false;
                        rbWork.Checked = false;
                        cmbUsers.Text = "";
                        txtClocation.Clear();
                        cmbUsers.Text = "";
                        return;
                    }
                    

                    string item_code = txtIcode.Text;
                    string to_location = cmbPlace.Text;
                    string default_location = txtDlocation.Text;
                    string item_name = txtIname.Text;
                    bool rbworkChecked = rbWork.Checked;
                    bool rbnworkChecked = rbNwork.Checked;
                    string from_location = txtClocation.Text;
                    string user_name = cmbUsers.Text;

                    bool itemExists = false;

                    // Check for duplicates in the DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == item_code)
                        {
                            itemExists = true;
                            break;
                        }
                    }

                    if (string.IsNullOrWhiteSpace(item_name) || string.IsNullOrWhiteSpace(item_code) || string.IsNullOrWhiteSpace(default_location) || /*string.IsNullOrWhiteSpace(to_location) || */ string.IsNullOrWhiteSpace(from_location) || string.IsNullOrWhiteSpace(user_name))
                    {
                        MessageBox.Show("Please fill in all fields.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (itemExists)
                    {
                        MessageBox.Show("Item code already exists in the grid.", "Duplicate Item Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIname.Clear();
                        txtIcode.Text = "";
                        txtDlocation.Clear();
                        cmbPlace.Text = "";
                        rbNwork.Checked = false;
                        rbWork.Checked = false;
                        cmbUsers.Text = "";
                        txtClocation.Clear();
                        cmbUsers.Text = "";
                    }
                    else
                    {
                        // Add new row
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.CreateCells(dataGridView1);
                        newRow.Cells[0].Value = DateTime.Now;
                        newRow.Cells[1].Value = item_name;
                        newRow.Cells[2].Value = item_code;
                        newRow.Cells[3].Value = default_location;
                        newRow.Cells[4].Value = to_location;
                        newRow.Cells[5].Value = from_location;

                        if (rbworkChecked)
                        {
                            newRow.Cells[7].Value = "Work";
                        }
                        else if (rbnworkChecked)
                        {
                            newRow.Cells[7].Value = "Not Work";
                        }

                        newRow.Cells[6].Value = user_name;
                        newRow.Cells[9].Value = true; // Assuming the 7th column represents a boolean value
                        newRow.Cells[8].Value = "transfer";

                        dataGridView1.Rows.Add(newRow);

                        // Clear input fields
                        txtIname.Clear();
                        txtIcode.Text = "";
                        txtDlocation.Clear();
                        cmbPlace.Text = "";
                        cmbUsers.Text = "";
                        txtClocation.Clear();
                        rbNwork.Checked = false;
                        rbWork.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }





            /*

        
            try
            {
               // if (con.State == ConnectionState.Closed)
                 //   con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM items WHERE item_code = @item_code", con))
                {
                    cmd.Parameters.AddWithValue("@item_code", txtIcode.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    string item_code = txtIcode.Text;
                    string to_location = cmbPlace.Text;
                    string default_location = txtDlocation.Text;
                    string item_name = txtIname.Text;
                    bool rbworkChecked = rbWork.Checked;
                    bool rbnworkChecked = rbNwork.Checked;
                    string from_location = txtClocation.Text;
                    string user_name= cmbUsers.Text;

                    bool itemExists = false;

                    // Check for duplicates in the DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == item_code)
                        {
                            itemExists = true;
                            break;
                        }
                    }

                    if (string.IsNullOrWhiteSpace(item_name) || string.IsNullOrWhiteSpace(item_code) || string.IsNullOrWhiteSpace(default_location) || string.IsNullOrWhiteSpace(to_location) || string.IsNullOrWhiteSpace(from_location) || string.IsNullOrWhiteSpace(user_name))
                    {
                        MessageBox.Show("Please fill in all fields.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (itemExists)
                    {
                        MessageBox.Show("Item code already exists in the grid.", "Duplicate Item Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIname.Clear();
                        txtIcode.Text = "";
                        txtDlocation.Clear();
                        cmbPlace.Text = "";
                        rbNwork.Checked = false;
                        rbWork.Checked = false;
                        cmbUsers.Text = "";
                        txtClocation.Clear();
                        cmbUsers.Text = "";
                    }
                    else
                    {
                        // Add new row
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.CreateCells(dataGridView1);
                        newRow.Cells[0].Value = System.DateTime.Now;
                        newRow.Cells[1].Value = item_name;
                        newRow.Cells[2].Value = item_code;
                        newRow.Cells[3].Value = default_location;
                        newRow.Cells[4].Value = to_location;
                        newRow.Cells[5].Value = from_location;


                        if (rbworkChecked)
                        {
                            newRow.Cells[7].Value = "Work";
                        }
                        else if (rbnworkChecked)
                        {
                            newRow.Cells[7].Value = "Not Work";


                        }
                        newRow.Cells[6].Value = user_name;
                        newRow.Cells[9].Value = true; // Assuming the 7th column represents a boolean value
                        newRow.Cells[8].Value = "transfer";

                        dataGridView1.Rows.Add(newRow);

                        // Clear input fields
                        txtIname.Clear();
                        txtIcode.Text="";
                        txtDlocation.Clear();
                        cmbPlace.Text = "";
                        cmbUsers.Text = "";
                        txtClocation.Clear();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            */

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtIcode.Text = "";
            txtIname.Text = "";
            txtDlocation.Text = "";
            cmbPlace.Text = "";
            rbWork.Checked = false;
            rbNwork.Checked = false;
            dataGridView1.Rows.Clear();
            txtClocation.Clear();
            pictureBox1.Image = null;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                int total = dataGridView1.Rows.Cast<DataGridViewRow>().Count(p => Convert.ToBoolean(p.Cells["Select"].Value) == true);
                if (total > 0)
                {
                    string message = $"Are you sure you want to transfer these items? {total} {(total > 1 ? "rows" : "row")}";
                    DialogResult result = MessageBox.Show(message, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                        {
                            SqlCommand cmd = new SqlCommand(@"INSERT INTO items_transfer_internal (date, item_code, item_name, default_location, to_location, from_location, condition, time, user_name, status) 
                                                VALUES (@date, @item_code, @item_name, @default_location, @to_location, @from_location, @condition, @time, @user_name, @status)", con, transaction);

                            cmd.Parameters.Add("@time", SqlDbType.DateTime).Value = dataGridView1.Rows[j].Cells[0].Value.ToString();
                            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = dataGridView1.Rows[j].Cells[0].Value.ToString();
                            cmd.Parameters.Add("@item_name", SqlDbType.VarChar).Value = dataGridView1.Rows[j].Cells[1].Value.ToString();
                            cmd.Parameters.Add("@item_code", SqlDbType.VarChar).Value = dataGridView1.Rows[j].Cells[2].Value.ToString();
                            cmd.Parameters.Add("@default_location", SqlDbType.VarChar).Value = dataGridView1.Rows[j].Cells[3].Value.ToString();
                            cmd.Parameters.Add("@to_location", SqlDbType.VarChar).Value = dataGridView1.Rows[j].Cells[4].Value.ToString();
                            cmd.Parameters.Add("@from_location", SqlDbType.VarChar).Value = dataGridView1.Rows[j].Cells[4].Value.ToString();

                            object cellValue = dataGridView1.Rows[j].Cells[7].Value;
                            cmd.Parameters.Add("@condition", SqlDbType.VarChar).Value = dataGridView1.Rows[j].Cells[7].Value.ToString();

                            cmd.Parameters.Add("@user_name", SqlDbType.VarChar).Value = dataGridView1.Rows[j].Cells[6].Value.ToString();
                            cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = dataGridView1.Rows[j].Cells[8].Value.ToString();

                            cmd.ExecuteNonQuery();

                            // Update current location for each item
                            SqlCommand updateCmd = new SqlCommand(@"UPDATE items SET current_location = @current_location, status = @status WHERE item_code = @item_code", con, transaction);
                            updateCmd.Parameters.Add("@current_location", SqlDbType.VarChar).Value = dataGridView1.Rows[j].Cells[4].Value.ToString();
                            updateCmd.Parameters.Add("@item_code", SqlDbType.VarChar).Value = dataGridView1.Rows[j].Cells[2].Value.ToString();
                            updateCmd.Parameters.Add("@status", SqlDbType.VarChar).Value = dataGridView1.Rows[j].Cells[8].Value.ToString();
                            updateCmd.Parameters.Add("@condition", SqlDbType.VarChar).Value = dataGridView1.Rows[j].Cells[7].Value.ToString();

                            updateCmd.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Commit the transaction after successful execution
                    }
                    else
                    {
                        // User opted not to transfer items
                        transaction.Rollback();
                    }
                }
                else
                {
                    MessageBox.Show("No items selected for transfer.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Consider logging the exception for better debugging
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            // Clearing DataGridView after operations
            dataGridView1.Rows.Clear();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int yCoordinate = 250;

            e.Graphics.DrawString("SRI LANKA INSTITUTE OF ADVANCED TECHNOLOGICAL", new System.Drawing.Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new Point(60, 100));
            e.Graphics.DrawString("EDUCATION", new System.Drawing.Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new Point(320,150));
            e.Graphics.DrawString("KURUNEGALA", new System.Drawing.Font("Times New Roman", 16), Brushes.Black, new Point(320, 200));


            e.Graphics.DrawString("This will confirm following item/s will effectively Transfer  ", new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
            yCoordinate += 20;

            try
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1.Rows[j].Cells["select"].Value != null && (bool)dataGridView1.Rows[j].Cells["select"].Value)
                    {
                        if (dataGridView1.Rows[j].Cells["item_name"].Value != null)
                        {
                            string itemName = dataGridView1.Rows[j].Cells["item_name"].Value.ToString();
                            e.Graphics.DrawString("Item Name: " + itemName, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        if (dataGridView1.Rows[j].Cells["item_code"].Value != null)
                        {
                            string itemCode = dataGridView1.Rows[j].Cells["item_code"].Value.ToString();
                            e.Graphics.DrawString("Item Code: " + itemCode, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        if (dataGridView1.Rows[j].Cells["default_location"].Value != null)
                        {
                            string default_location = dataGridView1.Rows[j].Cells["default_location"].Value.ToString();
                            e.Graphics.DrawString("Default Location: " + default_location, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        if (dataGridView1.Rows[j].Cells["to_location"].Value != null)
                        {
                            string to_location = dataGridView1.Rows[j].Cells["to_location"].Value.ToString();
                            e.Graphics.DrawString("To Location: " + to_location, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        if (dataGridView1.Rows[j].Cells["condition"].Value != null)
                        {
                            string condition = dataGridView1.Rows[j].Cells["condition"].Value.ToString(); // Corrected variable name
                            e.Graphics.DrawString("Condition: " + condition, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }


                        if (dataGridView1.Rows[j].Cells["user_name"].Value != null)
                        {
                            string user_name = dataGridView1.Rows[j].Cells["user_name"].Value.ToString();
                            e.Graphics.DrawString("Transfer By: " + user_name, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        e.Graphics.DrawString("________________________", new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                        yCoordinate += 30;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            // Date
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            e.Graphics.DrawString("Date: " + currentDate, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
            yCoordinate += 30;

            // Signature
            e.Graphics.DrawString("Transfer By:...................", new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(450, 1050));
            //yCoordinate += 30;


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void rbNwork_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNwork.Checked)
            {
                //  rbwork.Enabled = false;
                //  rbnwork.Enabled = false;
                // new frmOtherplace().Show();
                // rbnwork.Checked = true; // Select rbwork RadioButton
                
            }
        }

        private void Inventorymange_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sclimsDataSet5.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.sclimsDataSet5.users);
            // TODO: This line of code loads data into the 'sclimsDataSet5.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.sclimsDataSet5.users);
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                comboBox1.Items.Add(filterInfo.Name);
            }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            // TODO: This line of code loads data into the 'sclimsDataSet1.locations' table. You can move, or remove it, as needed.
            this.locationsTableAdapter.Fill(this.sclimsDataSet1.locations);
            
          
            string sql = "SELECT * FROM items";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            txtIcode.Items.Add(dr["item_code"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while retrieving data: " + ex.Message);
            }
            finally
            {
                con.Close(); // Always close the connection after using it
            }


            cmbPlace.SelectedIndex = -1;
            cmbUsers.SelectedIndex = -1;


           
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int yCoordinate = 250;

            e.Graphics.DrawString("SRI LANKA INSTITUTE OF ADVANCED TECHNOLOGICAL", new System.Drawing.Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new Point(60, 100));
            e.Graphics.DrawString("EDUCATION", new System.Drawing.Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new Point(320, 150));
            e.Graphics.DrawString("KURUNEGALA", new System.Drawing.Font("Times New Roman", 16), Brushes.Black, new Point(320, 200));



            e.Graphics.DrawString("This will confirm following item/s will effectively Remove not work items  ", new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
            yCoordinate += 20;
            try
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1.Rows[j].Cells["select"].Value != null && (bool)dataGridView1.Rows[j].Cells["select"].Value)
                    {
                        if (dataGridView1.Rows[j].Cells["item_name"].Value != null)
                        {
                            string itemName = dataGridView1.Rows[j].Cells["item_name"].Value.ToString();
                            e.Graphics.DrawString("Item Name: " + itemName, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        if (dataGridView1.Rows[j].Cells["item_code"].Value != null)
                        {
                            string itemCode = dataGridView1.Rows[j].Cells["item_code"].Value.ToString();
                            e.Graphics.DrawString("Item Code: " + itemCode, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        if (dataGridView1.Rows[j].Cells["default_location"].Value != null)
                        {
                            string default_location = dataGridView1.Rows[j].Cells["default_location"].Value.ToString();
                            e.Graphics.DrawString("Default Location: " + default_location, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }


                        if (dataGridView1.Rows[j].Cells["condition"].Value != null)
                        {
                            string condition = dataGridView1.Rows[j].Cells["condition"].Value.ToString(); // Corrected variable name
                            e.Graphics.DrawString("Condition: " + condition, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        if (dataGridView1.Rows[j].Cells["user_name"].Value != null)
                        {
                            string user_name = dataGridView1.Rows[j].Cells["user_name"].Value.ToString();
                            e.Graphics.DrawString("Transfer By: " + user_name, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        e.Graphics.DrawString("________________________", new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                        yCoordinate += 30;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            // Date
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            e.Graphics.DrawString("Date: " + currentDate, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
            yCoordinate += 30;

            // Signature
            e.Graphics.DrawString("Remove By:.....................", new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(450, 1050));
            //yCoordinate += 30;

        }

        private void txtIcode_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            try
            {
                string sql = "SELECT * FROM items WHERE item_code=@item_code";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@item_code", txtIcode.Text);
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string item_name = dr["item_name"].ToString();
                            txtIname.Text = item_name;

                            string default_location = dr["default_location"].ToString();
                            txtDlocation.Text = default_location;

                            string current_location= dr["current_location"].ToString();
                            txtClocation.Text = current_location;



                        }
                        else
                        {
                            MessageBox.Show("No item found with the provided item code.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while retrieving data: " + ex.Message);
            }
            finally
            {
                con.Close(); // Always close the connection after using it
            }

            
        }

        private void cmbPlace_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbPlace.Text == "Other")
            {
                /*
                otherplace otherForm = new otherplace(); // Instantiate the otherplace form
                otherForm.Show(); // Show the otherplace form
                //this.Hide(); // Hide the current form
                */

              //  Other Other = new Other(); // Instantiate the otherplace form
               // Other.Show(); // Show the otherplace form
                
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                int total = dataGridView1.Rows.Cast<DataGridViewRow>().Count(p => Convert.ToBoolean(p.Cells["Select"].Value) == true);

                if (total > 0)
                {
                    string message = $"Are you sure you want to remove these items from the system? {total} {(total > 1 ? "rows" : "row")}";
                    DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            if (Convert.ToBoolean(dataGridView1.Rows[j].Cells["Select"].Value))
                            {
                                string deleteMessage = $"Are you sure you want to remove this item {dataGridView1.Rows[j].Cells[1].Value.ToString()}?";
                                DialogResult deleteResult = MessageBox.Show(deleteMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (deleteResult == DialogResult.Yes)
                                {
                                    SqlCommand cmdInsert = new SqlCommand(@"INSERT INTO items_not_work (date, item_code, item_name, default_location, condition, time, name) 
                                                                 VALUES (@date, @item_code, @item_name, @default_location, @condition, @time, @name)", con, transaction);

                                    cmdInsert.Parameters.AddWithValue("@date", DateTime.Now); // Example: Use proper date value
                                    cmdInsert.Parameters.AddWithValue("@item_name", dataGridView1.Rows[j].Cells[1].Value.ToString());
                                    cmdInsert.Parameters.AddWithValue("@item_code", dataGridView1.Rows[j].Cells[2].Value.ToString());
                                    cmdInsert.Parameters.AddWithValue("@default_location", dataGridView1.Rows[j].Cells[3].Value.ToString());
                                    cmdInsert.Parameters.AddWithValue("@condition", dataGridView1.Rows[j].Cells[7].Value ?? DBNull.Value);
                                    cmdInsert.Parameters.AddWithValue("@time", dataGridView1.Rows[j].Cells[0].Value.ToString()); // Assuming this is the time parameter
                                    cmdInsert.Parameters.AddWithValue("@name", dataGridView1.Rows[j].Cells[6].Value.ToString()); // Assuming this is the name parameter

                                    cmdInsert.ExecuteNonQuery();

                                    SqlCommand cmdDelete = new SqlCommand(@"DELETE FROM items WHERE item_code = @item_code", con, transaction);
                                    cmdDelete.Parameters.AddWithValue("@item_code", dataGridView1.Rows[j].Cells[2].Value.ToString());


                                    cmdDelete.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit(); // Commit transaction if all operations succeed
                        MessageBox.Show("Items removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No items selected to remove.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Rollback transaction on error
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            // Optionally clear the DataGridView after operations
            // dataGridView1.Rows.Clear();

            // Display print preview dialog and print document
            printPreviewDialog1.Document = printDocument2;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }




        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                captureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                timer1.Start();
            }
            else
            {
                MessageBox.Show("No video capture device selected.");
            }
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader { AutoRotate = true, TryInverted = true }; // Enable auto rotation and try inverted decoding
                Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                    txtIcode.Text= result.Text;
                    timer1.Stop();
                    if (captureDevice != null && captureDevice.IsRunning)
                        captureDevice.Stop();
                }
            }
        }

        private void Inventorymange_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice != null && captureDevice.IsRunning)
                captureDevice.Stop();
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel6.Controls.Clear();
            this.Refresh();
            Inventory(new Other());
        }

        private void  Inventory(object Form)
        {
            if (this.panel6.Controls.Count > 0)
                this.panel6.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(f);
            this.panel6.Tag = f;
            f.Show();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
