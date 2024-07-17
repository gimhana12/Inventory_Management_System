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

namespace SCLIMS
{
   
    public partial class items_return : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");
        public SqlCommand cmd;

        public items_return()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Open connection if it's not already open
                if (con.State == ConnectionState.Closed)
                    con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM items WHERE item_code = @item_code", con))
                {
                    cmd.Parameters.AddWithValue("@item_code", txti_code.Text);



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                   


                    string item_code = txti_code.Text;
                    string to_location = cmbPlace.Text;
                    string default_location = txtDlocation.Text;
                    string item_name = txtiname.Text;
                    

                    bool itemExists = false;

                    

                    // Check for duplicates in the DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == item_code)
                        {
                            itemExists = true;
                            break;
                        }
                    }

                    if (string.IsNullOrWhiteSpace(item_name) || string.IsNullOrWhiteSpace(item_code) || string.IsNullOrWhiteSpace(default_location) || string.IsNullOrWhiteSpace(to_location))
                    {
                        MessageBox.Show("Please fill in all fields.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (itemExists)
                    {
                        MessageBox.Show("Item code already exists in the grid.", "Duplicate Item Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Add new row
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.CreateCells(dataGridView1);
                        newRow.Cells[0].Value = System.DateTime.Now;
                        newRow.Cells[1].Value = item_code; // Make sure to set the correct cell index
                        newRow.Cells[2].Value = item_name;
                        newRow.Cells[3].Value = default_location;
                        newRow.Cells[4].Value = to_location;
                        newRow.Cells[5].Value = "return";
                        newRow.Cells[6].Value = true;

                        dataGridView1.Rows.Add(newRow);
                    }

                    // Clear input fields
                    txtiname.Clear();
                    txti_code.Text=""; // Changed to Clear() method
                    txtDlocation.Clear();
                    cmbPlace.SelectedIndex = -1; // Clear selection

                   



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close connection
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
               // int total = dataGridView1.Rows.Cast<DataGridViewRow>().Count(p => Convert.ToBoolean(p.Cells["return"].Value) == true);
                
              
                    
                        for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                        {
                            SqlCommand cmd = new SqlCommand(@"INSERT INTO items_return(date,item_code,item_name,current_location,from_location,time,status) 
                            VALUES (@date,@item_code,@item_name,@current_location,@from_location,@time,@status)", con, transaction);

                            cmd.Parameters.AddWithValue("@time", System.DateTime.Now.ToString("h:mm tt"));
                            cmd.Parameters.AddWithValue("@date", System.DateTime.Now.ToShortDateString());

                            cmd.Parameters.AddWithValue("@item_code", dataGridView1.Rows[j].Cells[1].Value.ToString());
                            cmd.Parameters.AddWithValue("@item_name", dataGridView1.Rows[j].Cells[2].Value.ToString());
                            cmd.Parameters.AddWithValue("@current_location", dataGridView1.Rows[j].Cells[3].Value.ToString());
                            cmd.Parameters.AddWithValue("@from_location", dataGridView1.Rows[j].Cells[4].Value.ToString());
                            cmd.Parameters.AddWithValue("@status", dataGridView1.Rows[j].Cells[5].Value.ToString());
                            

                    cmd.ExecuteNonQuery();

                            // Update current location for each item
                            SqlCommand updateCmd = new SqlCommand(@"UPDATE items SET current_location = @current_location,status = @status WHERE item_code = @item_code", con, transaction);
                            updateCmd.Parameters.AddWithValue("@current_location", dataGridView1.Rows[j].Cells[4].Value.ToString());
                            updateCmd.Parameters.AddWithValue("@item_code", dataGridView1.Rows[j].Cells[1].Value.ToString());
                            updateCmd.Parameters.AddWithValue("@status", dataGridView1.Rows[j].Cells[5].Value.ToString());


                            updateCmd.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Commit transaction after successful operations
                    
                   
               
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();

            // Clearing DataGridView after operations
            dataGridView1.Rows.Clear();

        }

        private void items_return_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sclimsDataSet4.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.sclimsDataSet4.items);
            // TODO: This line of code loads data into the 'sclimsDataSet1.locations' table. You can move, or remove it, as needed.
            this.locationsTableAdapter.Fill(this.sclimsDataSet1.locations);
            txti_code.SelectedIndex = -1;
            cmbPlace.SelectedIndex = -1;
        }

        private void txti_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM items WHERE item_code=@item_code ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@item_code", txti_code.Text);
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string item_name = dr["item_name"].ToString();
                            txtiname.Text = item_name;

                            string default_location = dr["default_location"].ToString();
                            txtDlocation.Text = default_location;


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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int yCoordinate = 100;



            // Title
            e.Graphics.DrawString("SLIATE Kurunegala", new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, new Point(350, yCoordinate));
            yCoordinate += 60;

            // Introduction
           

            e.Graphics.DrawString("This will confirm following item/s will effectively Return  ", new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
            yCoordinate += 20;

            

            try
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                   // if (dataGridView1.Rows[j].Cells["select"].Value != null && (bool)dataGridView1.Rows[j].Cells["select"].Value)
                   // {
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

                        if (dataGridView1.Rows[j].Cells["default_ocation"].Value != null)
                        {
                        string default_ocation = dataGridView1.Rows[j].Cells["default_ocation"].Value.ToString();
                        e.Graphics.DrawString("Default Location: " + default_ocation, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                        yCoordinate += 20;
                        }

                    if (dataGridView1.Rows[j].Cells["to_location"].Value != null)
                    {
                        string to_location = dataGridView1.Rows[j].Cells["to_location"].Value.ToString();
                        e.Graphics.DrawString("To Location: " + to_location, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                        yCoordinate += 20;
                    }

                    /*
                    if (dataGridView1.Rows[j].Cells["from_location"].Value != null)
                    {
                        string to_location = dataGridView1.Rows[j].Cells["from_location"].Value.ToString();
                        e.Graphics.DrawString("To Location: " + to_location, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                        yCoordinate += 20;
                    }
                    */






                    e.Graphics.DrawString("________________________", new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                        yCoordinate += 30;
                    
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
            e.Graphics.DrawString("Return by:...................", new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(450, 1050));
            //yCoordinate += 30;

        }
    }
}
