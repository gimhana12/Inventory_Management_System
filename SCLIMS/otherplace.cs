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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SCLIMS
{
    public partial class otherplace : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");
        public SqlCommand cmd;

        public otherplace()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM items WHERE item_code = @item_code", con))
                {
                    cmd.Parameters.AddWithValue("@item_code", txti_code.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0 && dt.Rows[0]["status"].ToString().ToLower() == "issue")
                    {
                        MessageBox.Show("Item is already in 'issue' status and cannot be issue again.", "Invalid issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string item_code = txti_code.Text;
                    string location = txtpname.Text;
                    string position = txtposition.Text;
                    string item_name = txtiname.Text;
                    string name = txtname.Text;
                    string id_no = txtidno.Text;
                    string mobile_no = txtmno.Text;
                 
                  
                    string issude_by = comboBox1.Text;

                    


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

                    if (string.IsNullOrWhiteSpace(item_name) || string.IsNullOrWhiteSpace(item_code) || string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(position) || string.IsNullOrWhiteSpace(item_name) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(id_no) || string.IsNullOrWhiteSpace(mobile_no) || string.IsNullOrWhiteSpace(issude_by))
                    {
                        MessageBox.Show("Please fill in all fields.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (itemExists)
                    {
                        MessageBox.Show("Item code already exists in the grid.", "Duplicate Item Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtidno.Clear();
                        txti_code.Text="";
                        txtiname.Clear();
                        comboBox1.Text="";
                        txtposition.Clear();
                        txtmno.Clear(); 
                        txtname.Clear();
                       

                    }
                    else
                    {
                        // Add new row
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.CreateCells(dataGridView1);
                        newRow.Cells[0].Value = System.DateTime.Now.ToString("MM/dd/yyyy");
                        newRow.Cells[1].Value = item_code;
                        newRow.Cells[2].Value = item_name;
                        newRow.Cells[3].Value = position;
                        newRow.Cells[4].Value = location;
                        newRow.Cells[5].Value = name;
                        newRow.Cells[6].Value = id_no;
                        newRow.Cells[7].Value = mobile_no;
                        newRow.Cells[8].Value = issude_by;
                        newRow.Cells[9].Value = "issued";


                        newRow.Cells[10].Value = true; // Assuming the 7th column represents a boolean value

                        dataGridView1.Rows.Add(newRow);

                        // Clear input fields
                        txtiname.Clear();
                        txti_code.Text="";
                        txtpname.Clear();
                        txtidno.Clear() ;
                        txtiname.Clear();
                        comboBox1.Text="";
                        txtposition.Clear();
                        txtmno .Clear();
                        txtname .Clear();



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
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txti_code.Text="";
            txtiname.Clear();
            txtposition.Clear();
            comboBox1.Text="";
            txtname.Clear();
            txtidno.Clear();
            txtmno.Clear();
            dataGridView1.Rows.Clear();

        }

        private void btnIssue_Click(object sender, EventArgs e)
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
                            cmd = new SqlCommand(@"INSERT INTO items_transfer_external (item_code, item_name, position, location, id_no, mobile_no, name, issude_by,status,date,time) 
                                       VALUES (@item_code, @item_name, @position, @location, @id_no, @mobile_no, @name, @issude_by,@status,@date,@time)", con, transaction);

                            cmd.Parameters.AddWithValue("@item_code", dataGridView1.Rows[j].Cells[1].Value.ToString());
                            cmd.Parameters.AddWithValue("@item_name", dataGridView1.Rows[j].Cells[2].Value.ToString());
                            cmd.Parameters.AddWithValue("@position", dataGridView1.Rows[j].Cells[3].Value.ToString());
                            cmd.Parameters.AddWithValue("@location", dataGridView1.Rows[j].Cells[4].Value.ToString());
                            cmd.Parameters.AddWithValue("@name", dataGridView1.Rows[j].Cells[5].Value.ToString());
                            cmd.Parameters.AddWithValue("@id_no", dataGridView1.Rows[j].Cells[6].Value.ToString());
                            cmd.Parameters.AddWithValue("@mobile_no", dataGridView1.Rows[j].Cells[7].Value.ToString());
                            cmd.Parameters.AddWithValue("@issude_by", dataGridView1.Rows[j].Cells[8].Value.ToString());
                            cmd.Parameters.AddWithValue("@status", dataGridView1.Rows[j].Cells[9].Value="Issued");
                            cmd.Parameters.AddWithValue("@time", System.DateTime.Now.ToString("h:mm tt"));
                            cmd.Parameters.AddWithValue("@date", System.DateTime.Now.ToString("MM/dd/yyyy"));

                            cmd.ExecuteNonQuery();



                        }

                        for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                        {
                            SqlCommand cmd = new SqlCommand(@"UPDATE items SET current_location = @current_location,status=@status WHERE item_code = @item_code", con, transaction);
                            cmd.Parameters.AddWithValue("@current_location", dataGridView1.Rows[j].Cells[4].Value.ToString());
                            cmd.Parameters.AddWithValue("@item_code", dataGridView1.Rows[j].Cells[1].Value.ToString());
                            cmd.Parameters.AddWithValue("@status", dataGridView1.Rows[j].Cells[9].Value.ToString());


                            cmd.ExecuteNonQuery();
                        }


                        transaction.Commit();
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
            int yCoordinate = 100;



            // Title
            e.Graphics.DrawString("SLIATE Kurunegala", new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, new Point(350, yCoordinate));
            yCoordinate += 60;

            

            e.Graphics.DrawString("This will confirm following item/s will effectively issue  ", new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
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

                        if (dataGridView1.Rows[j].Cells["location"].Value != null)
                        {
                            string location = dataGridView1.Rows[j].Cells["location"].Value.ToString();
                            e.Graphics.DrawString("Issued Location: " + location, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        if (dataGridView1.Rows[j].Cells["position"].Value != null)
                        {
                            string position = dataGridView1.Rows[j].Cells["position"].Value.ToString();
                            e.Graphics.DrawString("Position: " + position, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        if (dataGridView1.Rows[j].Cells["name"].Value != null)
                        {
                            string name = dataGridView1.Rows[j].Cells["name"].Value.ToString();
                            e.Graphics.DrawString("Name: " + name, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        if (dataGridView1.Rows[j].Cells["id_no"].Value != null)
                        {
                            string id_no = dataGridView1.Rows[j].Cells["id_no"].Value.ToString();
                            e.Graphics.DrawString("ID No: " + id_no, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }

                        if (dataGridView1.Rows[j].Cells["mobile_no"].Value != null)
                        {
                            string mobile_no = dataGridView1.Rows[j].Cells["mobile_no"].Value.ToString();
                            e.Graphics.DrawString("Mobile No: " + mobile_no, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
                            yCoordinate += 20;
                        }



                        if (dataGridView1.Rows[j].Cells["issude_by"].Value != null)
                        {
                            string issude_by = dataGridView1.Rows[j].Cells["issude_by"].Value.ToString();
                            e.Graphics.DrawString("Issued By: " + issude_by, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, yCoordinate));
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
            e.Graphics.DrawString("Issued By: ....................", new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(450, 1050));
            //yCoordinate += 30;

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void otherplace_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sclimsDataSet5.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.sclimsDataSet5.users);
            // TODO: This line of code loads data into the 'sclimsDataSet3.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.sclimsDataSet3.items);
            // TODO: This line of code loads data into the 'sclimsDataSet2.items' table. You can move, or remove it, as needed.
            
         
            txti_code.SelectedIndex = -1;

            


        }

        private void txti_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM items WHERE item_code=@item_code";
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

                       
                        }
                        else
                        {
                            //MessageBox.Show("No item found with the provided item code.");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
