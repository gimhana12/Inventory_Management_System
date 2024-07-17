using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing;
using System.Data.Common;
using System.Drawing.Drawing2D;


namespace SCLIMS
{
    public partial class Form1 : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");

        public Form1()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Interval = 1000; // 1 second
            timer1.Tick += timer1_Tick;
            timer1.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            dataGridView1.ColumnCount = 8;

            // Set specific header text for each column
            dataGridView1.Columns[0].HeaderText = "Item Name";
            dataGridView1.Columns[1].HeaderText = "Main Lab";
            dataGridView1.Columns[2].HeaderText = "Lab1";
            dataGridView1.Columns[3].HeaderText = "Lab2";
            dataGridView1.Columns[4].HeaderText = "Lab3";
            dataGridView1.Columns[5].HeaderText = "Lab4";
            dataGridView1.Columns[6].HeaderText = "Lab5";
            dataGridView1.Columns[7].HeaderText = "Hardware Lab";

           // dataGridView1.ColumnHeadersHeight = 50; // Set header height
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders; // Auto size row headers

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Arial", 16, FontStyle.Bold); // Set font style
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Align header text to center
                column.HeaderCell.Style.WrapMode = DataGridViewTriState.True;
                column.Width = 150; // Set column width
             
            }
            /*
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.Columns[0].HeaderCell.Style.ForeColor = Color.Red;
            dataGridView1.Columns[1].HeaderCell.Style.ForeColor = Color.Green;
            dataGridView1.Columns[2].HeaderCell.Style.ForeColor = Color.Blue;
            dataGridView1.Columns[3].HeaderCell.Style.ForeColor = Color.Orange;
            dataGridView1.Columns[4].HeaderCell.Style.ForeColor = Color.Purple;
            dataGridView1.Columns[5].HeaderCell.Style.ForeColor = Color.Brown;
            dataGridView1.Columns[6].HeaderCell.Style.ForeColor = Color.Cyan;
            dataGridView1.Columns[7].HeaderCell.Style.ForeColor = Color.Magenta;

            */

            // Disable default header styles to allow custom styles
            dataGridView1.EnableHeadersVisualStyles = false;

            // Apply custom header cell background colors
            dataGridView1.Columns[0].HeaderCell.Style.BackColor = Color.DeepSkyBlue;
            dataGridView1.Columns[1].HeaderCell.Style.BackColor = Color.DeepSkyBlue;
            dataGridView1.Columns[2].HeaderCell.Style.BackColor = Color.DeepSkyBlue;
            dataGridView1.Columns[3].HeaderCell.Style.BackColor = Color.DeepSkyBlue;
            dataGridView1.Columns[4].HeaderCell.Style.BackColor = Color.DeepSkyBlue;
            dataGridView1.Columns[5].HeaderCell.Style.BackColor = Color.DeepSkyBlue;
            dataGridView1.Columns[6].HeaderCell.Style.BackColor = Color.DeepSkyBlue;
            dataGridView1.Columns[7].HeaderCell.Style.BackColor = Color.DeepSkyBlue;


            List<string> itemNames = new List<string>();

            // Retrieve distinct item names from the database
            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT item_name FROM items", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    itemNames.Add(reader["item_name"].ToString());
                }
                reader.Close();
            }

            // Add rows to dataGridView1 for each item name
            foreach (string itemName in itemNames)
            {
                dataGridView1.Rows.Add(itemName);
            }

            // Populate the DataGridView with counts
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string itemName = row.Cells[0].Value.ToString();
                    row.Cells[1].Value = GetItemCount("Main lab", itemName);
                    row.Cells[2].Value = GetItemCount("Lab1", itemName);
                    row.Cells[3].Value = GetItemCount("Lab2", itemName);
                    row.Cells[4].Value = GetItemCount("Lab3", itemName);
                    row.Cells[5].Value = GetItemCount("Lab4", itemName);
                    row.Cells[6].Value = GetItemCount("Lab5", itemName);
                    row.Cells[7].Value = GetItemCount("Hardware lab", itemName);
                }
            }

            /////////remove auto select
            // Clear any existing selection
            dataGridView1.ClearSelection();

            // Set the DataGridView selection mode
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Handle the SelectionChanged event to clear any selections
            dataGridView1.SelectionChanged += (src, evtArgs) => dataGridView1.ClearSelection();



            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                // Set cell font style
                column.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change FontStyle to Regular or Bold as needed
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Align cell text to center
                
            }

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Accessing the cell in the first column of each row
                    DataGridViewCell cell = row.Cells[0];

                    // Setting font and alignment for the cell
                    cell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                  
                }
            }
            catch (Exception ex)
            {
                // Handle specific exceptions here if needed
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            label9.Text = DateTime.Now.ToString("h:mm tt");
            date.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Format: 2024-07-11
                                                             


            ///////////////////////////count
            try
            {
            
                con.Open();
                SqlCommand user_cmd = new SqlCommand();
                string user_stat;
                int usertotalcount;

                user_stat = "SELECT COUNT(*) FROM users";
                user_cmd = new SqlCommand(user_stat, con);

                // Execute the command and get the total count
                usertotalcount = Convert.ToInt32(user_cmd.ExecuteScalar());

                // Display the total count in the label (assuming you have a label named usertotalshowdata)
                label2.Text = "Users: " + usertotalcount.ToString();
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }


            //////////////Labs

            try
            {

                con.Open();
                SqlCommand labs_cmd = new SqlCommand();
                string labs;
                int labcount;

                labs = "SELECT COUNT(*) FROM locations";
                labs_cmd = new SqlCommand(labs, con);

                // Execute the command and get the total count
                labcount = Convert.ToInt32(labs_cmd.ExecuteScalar());

                // Display the total count in the label (assuming you have a label named usertotalshowdata)
                label3.Text = "No Labs: " + labcount.ToString();
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }

            //////////// items
            ///
            try
            {
                con.Open();

                SqlCommand items_cmd = new SqlCommand();
                string labs;
                int itemstotalcount;

                labs = "SELECT COUNT(*) FROM items"; 
                items_cmd = new SqlCommand(labs, con);

                // Execute the command and get the total count
                itemstotalcount = Convert.ToInt32(items_cmd.ExecuteScalar());

                // Display the total count in the label (assuming you have a label named label5)
                label5.Text = "No of ".ToString();
                label6.Text = "Items:" + itemstotalcount.ToString();
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }


            ///////////////////////// not work items
            ///

            try
            {

                con.Open();
                SqlCommand notw_cmd = new SqlCommand();
                string notwork;
                int notworks;

                notwork = "SELECT COUNT(*) FROM items_not_work";
                notw_cmd = new SqlCommand(notwork, con);

                // Execute the command and get the total count
                notworks = Convert.ToInt32(notw_cmd.ExecuteScalar());

                // Display the total count in the label (assuming you have a label named usertotalshowdata)
                label1.Text = "Not work" .ToString();
                label4.Text = "Items:" + notworks.ToString();
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }


        }

        private int GetItemCount(string location, string itemName)
        {
            using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM items WHERE current_location = @location AND item_name = @itemName", con))
            {
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();
                return count;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 50; // Adjust this value to control the roundness of corners
                Rectangle rect = new Rectangle(0, 0, panel1.Width, panel1.Height);
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                panel1.Region = new Region(path);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            //
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToString("h:mm:ss tt");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 50; // Adjust this value to control the roundness of corners
                Rectangle rect = new Rectangle(0, 0, panel1.Width, panel2.Height);
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                panel2.Region = new Region(path);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 50; // Adjust this value to control the roundness of corners
                Rectangle rect = new Rectangle(0, 0, panel1.Width, panel3.Height);
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                panel3.Region = new Region(path);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 50; // Adjust this value to control the roundness of corners
                Rectangle rect = new Rectangle(0, 0, panel1.Width, panel4.Height);
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                panel4.Region = new Region(path);
            }
        }
    }
}
