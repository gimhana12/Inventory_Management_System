using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCLIMS
{
    public partial class Reportgenarate : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");

        public Reportgenarate()
        {
            InitializeComponent();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reportgenarate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sclimsDataSet8.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter1.Fill(this.sclimsDataSet8.users);
            // TODO: This line of code loads data into the 'sclimsDataSet7.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.sclimsDataSet7.users);
            // TODO: This line of code loads data into the 'sclimsDataSet1.locations' table. You can move, or remove it, as needed.
            this.locationsTableAdapter.Fill(this.sclimsDataSet1.locations);

            cmbPLace.SelectedIndex = -1;
            cmbUsers.SelectedIndex = -1;
            cmbIssued.SelectedIndex = -1;

        }

        private void cmbPLace_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchData(cmbPLace.Text);
        }
        public void searchData(string location)
        {
            con.Open();
            try
            {
                string searchQuery = "SELECT item_code, item_name, category, status,current_location , brand, date,condition, time,default_location  FROM items WHERE current_location = @location ORDER BY current_location";

                using (SqlCommand command = new SqlCommand(searchQuery, con))
                {
                    command.Parameters.AddWithValue("@location", location);

                    // Execute the command to fetch data
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(reader);

                    // Set the DataGridView's DataSource to the DataTable
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Make sure to close the connection
                con.Close();
            }

        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchUser(cmbUsers.Text);
        }

        public void searchUser(string users)
        {
            con.Open();
            try
            {
                string searchQuery = "SELECT date,item_code,item_name,default_location,from_location,condition,status,time,user_name FROM items_transfer_internal WHERE user_name = @user_name ORDER BY user_name";


                using (SqlCommand command = new SqlCommand(searchQuery, con))
                {
                    command.Parameters.AddWithValue("@user_name", users);

                    // Execute the command to fetch data
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(reader);

                    // Set the DataGridView's DataSource to the DataTable
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Make sure to close the connection
                con.Close();
            }


        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            string selectedDate = date.Value.ToShortDateString();

            // Call searchdate method with the selected date
            searchdate(selectedDate);
        }

         public void searchdate(string valueToFind)
        {
            try
            {
                con.Open();

                string searchQuery = "SELECT item_code, item_name,user_name,status, date, condition, time,from_location,default_location " +
                                     "FROM items_transfer_internal WHERE date = @date ORDER BY date";

                using (SqlCommand command = new SqlCommand(searchQuery, con))
                {
                    // Add the @date parameter
                    command.Parameters.AddWithValue("@date", valueToFind);

                    // Execute the command to fetch data
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(reader);

                    // Set the DataGridView's DataSource to the DataTable
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Make sure to close the connection
                con.Close();
            }
        }

        private void cmbIssued_SelectedIndexChanged(object sender, EventArgs e)
        {
            Issued(cmbIssued.Text);
        }

        public void Issued(string issude)
        {

            try
            {
                con.Open();

                string searchQuery = "SELECT item_code,item_name,time,position,location,id_no,mobile_no,name,status,date FROM items_transfer_external WHERE issude_by = @issude_by ORDER BY issude_by";

                using (SqlCommand command = new SqlCommand(searchQuery, con))
                {
                    command.Parameters.AddWithValue("@issude_by", issude);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);

                        dataGridView1.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void cmbPLace_Click(object sender, EventArgs e)
        {
            cmbUsers.SelectedIndex = -1;
            cmbIssued.SelectedIndex = -1;
        }

        private void cmbUsers_Click(object sender, EventArgs e)
        {
            cmbPLace.SelectedIndex = -1;
            cmbIssued.SelectedIndex = -1;
        }

        private void cmbIssued_Click(object sender, EventArgs e)
        {
            cmbPLace.SelectedIndex = -1;
            cmbUsers.SelectedIndex = -1;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (cmbPLace.SelectedItem != null)
            {
                string selectedText = cmbPLace.SelectedItem.ToString();
                printPreviewDialog1.Document = printDocument1;
            }
            else if (cmbUsers.SelectedItem != null)
            {
                string selectedText = cmbUsers.SelectedItem.ToString();
                printPreviewDialog1.Document = printDocument2;
            }
            else if (cmbIssued.SelectedItem != null)
            {
                string selectedText = cmbIssued.SelectedItem.ToString();
                printPreviewDialog1.Document = printDocument3;
            }
            else if (date.Value != null)
            {
                DateTime selectedDate = date.Value;
                // Now you can use selectedDate for your printing logic
                printPreviewDialog1.Document = printDocument4;
            }

            if (printPreviewDialog1.Document != null)
            {
                try
                {
                    if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                    {
                        printPreviewDialog1.Document.Print();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while trying to print: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No valid selection for printing.");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int yCoordinate = 100;
            int cellWidth = 100; // Adjust cell width as needed
            int cellHeight = 30;
            int dcellWidth = 120;

            try
            {
                // Load logo image
                Image image = Image.FromFile(@"F:\Project Individual\SCLIMS\SLIATE_LOGO2.jpg");
                Point imageLocation = new Point(350, 20); // Adjust the location as needed
                yCoordinate += 30;

                // Draw the image
                e.Graphics.DrawImage(image, new Rectangle(imageLocation, new Size(80, 120))); // Adjust size as needed
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }

            // Title and headers
            e.Graphics.DrawString("SRI LANKA INSTITUTE OF ADVANCED TECHNOLOGICAL", new System.Drawing.Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new Point(50, 200));
            e.Graphics.DrawString("EDUCATION", new System.Drawing.Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new Point(320, 230));
            e.Graphics.DrawString("KURUNEGALA", new System.Drawing.Font("Times New Roman", 16), Brushes.Black, new Point(320, 260));
            e.Graphics.DrawString("Report", new System.Drawing.Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(360, 300));

            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                if (dataGridView1.Rows[j].Cells["current_location"].Value != null)
                {
                    string itemName = dataGridView1.Rows[j].Cells["current_location"].Value.ToString();
                    e.Graphics.DrawString("Location: " + itemName, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(50, 350));
                    // yCoordinate += 20;
                }

            }


            // Table headers
            int tableHeaderX = 55;
            int tableY = 400;

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Date", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Item Code", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Item Name", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawString("Default Place", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Status", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawString("Time", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Condition", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            tableY += cellHeight;

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["date"].Value != null && row.Cells["time"].Value != null && row.Cells["item_code"].Value != null && row.Cells["item_name"].Value != null && row.Cells["default_location"].Value != null && row.Cells["condition"].Value != null && row.Cells["status"].Value != null)
                    {
                        string itemName = row.Cells["item_name"].Value.ToString();
                        string itemCode = row.Cells["item_code"].Value.ToString();
                        string Dlocation = row.Cells["default_location"].Value.ToString();
                        string Condition = row.Cells["condition"].Value.ToString();
                        string Status = row.Cells["status"].Value.ToString();
                        string time = row.Cells["time"].Value.ToString();


                        // Draw date
                        if (row.Cells["date"].Value != null && row.Cells["date"].Value is DateTime)
                        {
                            DateTime dateValue = (DateTime)row.Cells["date"].Value;
                            string formattedDate = dateValue.ToString("yyyy-MM-dd");

                            e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX, tableY, cellWidth, cellHeight));
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX, tableY, cellWidth, cellHeight));
                            e.Graphics.DrawString(formattedDate, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                        }
                        else
                        {
                            e.Graphics.DrawString("Invalid Date", new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Red, new PointF(tableHeaderX, tableY));
                        }

                        // Draw other columns similarly
                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(itemCode, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(itemName, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight));
                        e.Graphics.DrawString(Dlocation, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(Status, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
                        e.Graphics.DrawString(time, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(Condition, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        tableY += cellHeight;

                        // Check if there's enough space for the next row
                        if (tableY + cellHeight > e.MarginBounds.Bottom)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            // Date and signature
            string currentDate = DateTime.Today.ToString("yyyy-MM-dd");
            e.Graphics.DrawString("Date: " + currentDate, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(50, tableY));
            e.Graphics.DrawString("Signature: ........................", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, tableY));

            // Check if there's more content to print on subsequent pages
            if (tableY + cellHeight > e.MarginBounds.Bottom)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }

        }







        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int yCoordinate = 100;
            int cellWidth = 100; // Adjust cell width as needed
            int cellHeight = 30;
            int dcellWidth = 120;

            try
            {
                // Load logo image
                Image image = Image.FromFile(@"F:\Project Individual\SCLIMS\SLIATE_LOGO2.jpg");
                Point imageLocation = new Point(350, 20); // Adjust the location as needed
                yCoordinate += 30;

                // Draw the image
                e.Graphics.DrawImage(image, new Rectangle(imageLocation, new Size(80, 120))); // Adjust size as needed
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }

            // Title and headers
            e.Graphics.DrawString("SRI LANKA INSTITUTE OF ADVANCED TECHNOLOGICAL", new System.Drawing.Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new Point(50, 200));
            e.Graphics.DrawString("EDUCATION", new System.Drawing.Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new Point(320, 230));
            e.Graphics.DrawString("KURUNEGALA", new System.Drawing.Font("Times New Roman", 16), Brushes.Black, new Point(320, 260));
            e.Graphics.DrawString("Report", new System.Drawing.Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(360, 300));

            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                DataGridViewRow row = dataGridView1.Rows[j];

                // Check if the column exists
                if (dataGridView1.Columns.Contains("user_name") && row.Cells["user_name"].Value != null)
                {
                    string userName = row.Cells["user_name"].Value.ToString();
                    e.Graphics.DrawString("User Name: " + userName, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(60, 350));
                    // yCoordinate += 20;
                }
                else
                {
                    
                }

            }


            // Table headers
            int tableHeaderX = 55;
            int tableY = 400;

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Date", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Item Code", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Item Name", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawString("Default Place", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Status", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawString("Time", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Condition", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            tableY += cellHeight;

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["date"].Value != null && row.Cells["time"].Value != null && row.Cells["item_code"].Value != null && row.Cells["item_name"].Value != null && row.Cells["default_location"].Value != null && row.Cells["condition"].Value != null && row.Cells["status"].Value != null)
                    {
                        string itemName = row.Cells["item_name"].Value.ToString();
                        string itemCode = row.Cells["item_code"].Value.ToString();
                        string Dlocation = row.Cells["default_location"].Value.ToString();
                        string Condition = row.Cells["condition"].Value.ToString();
                        string Status = row.Cells["status"].Value.ToString();
                        //string time = row.Cells["time"].Value.ToString();

                        string timeString = row.Cells["time"].Value.ToString();

                        // Parse the time string to DateTime format
                        if (DateTime.TryParse(timeString, out DateTime timeValue))
                        {
                            string formattedTime = timeValue.ToString("hh:mm tt"); // Format as 12-hour with AM/PM

                            // Draw the formatted time
                            e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
                            e.Graphics.DrawString(formattedTime, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                        }

                        // Draw date
                        if (row.Cells["date"].Value != null && row.Cells["date"].Value is DateTime)
                        {
                            DateTime dateValue = (DateTime)row.Cells["date"].Value;
                            string formattedDate = dateValue.ToString("yyyy-MM-dd");

                            e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX, tableY, cellWidth, cellHeight));
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX, tableY, cellWidth, cellHeight));
                            e.Graphics.DrawString(formattedDate, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                        }
                        else
                        {
                            e.Graphics.DrawString("Invalid Date", new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Red, new PointF(tableHeaderX, tableY));
                        }



                        // Draw other columns similarly
                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(itemCode, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(itemName, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight));
                        e.Graphics.DrawString(Dlocation, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(Status, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        /*
                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
                        e.Graphics.DrawString(time, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                        */
                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(Condition, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        tableY += cellHeight;

                        // Check if there's enough space for the next row
                        if (tableY + cellHeight > e.MarginBounds.Bottom)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            // Date and signature
            string currentDate = DateTime.Today.ToString("yyyy-MM-dd");
            e.Graphics.DrawString("Date: " + currentDate, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(50, tableY));
            e.Graphics.DrawString("Signature: ........................", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, tableY));

            // Check if there's more content to print on subsequent pages
            if (tableY + cellHeight > e.MarginBounds.Bottom)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }


        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {




        }

        private void printDocument4_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int yCoordinate = 100;
            int cellWidth = 100; // Adjust cell width as needed
            int cellHeight = 30;
            int dcellWidth = 120;

            try
            {
                Image image = Image.FromFile(@"F:\Project Individual\SCLIMS\SLIATE_LOGO2.jpg");
                Point imageLocation = new Point(350, 20); // Adjust the location as needed
                yCoordinate += 30;

                // size of the image
                int imageWidth = 80;
                int imageHeight = 120;

                // Draw the image  location and size
                e.Graphics.DrawImage(image, new Rectangle(imageLocation, new Size(imageWidth, imageHeight)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }



            // Title
            e.Graphics.DrawString("SRI LANKA INSTITUTE OF ADVANCED TECHNOLOGICAL", new System.Drawing.Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new Point(50, 200));

            e.Graphics.DrawString("EDUCATION ", new System.Drawing.Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new Point(320, 230));
            //  yCoordinate += 100;
            e.Graphics.DrawString("KURUNEGALA ", new System.Drawing.Font("Times New Roman", 16), Brushes.Black, new Point(320, 260));
            //  yCoordinate += 100;

            e.Graphics.DrawString("Report", new System.Drawing.Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(360, 300));
            // yCoordinate += 70;

            // e.Graphics.DrawString("Name", new System.Drawing.Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(30, 350));
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                if (dataGridView1.Rows[j].Cells["date"].Value != null)
                {
                    DateTime dateValue;
                    if (DateTime.TryParse(dataGridView1.Rows[j].Cells["date"].Value.ToString(), out dateValue))
                    {
                        string dateOnly = dateValue.ToString("yyyy-MM-dd");
                        e.Graphics.DrawString("Date: " + dateOnly, new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(50, 350));
                        break; // Exit the loop after printing the first date
                    }
                }
            }


            // yCoordinate += 70;

            // Table headers
            int tableHeaderX = 55;
            int tableY = 400;

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Time", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Item Code", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Item Name", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawString("Default Place", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("Status", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
            e.Graphics.DrawString("    Condition", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawString("Current Place", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
            e.Graphics.DrawString("User Name", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new RectangleF(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });


            tableY += cellHeight;

            // Iterate through DataGridView rows
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["time"].Value != null && row.Cells["item_code"].Value != null && row.Cells["item_name"].Value != null && row.Cells["default_location"].Value != null && row.Cells["condition"].Value != null && row.Cells["status"].Value != null && row.Cells["from_location"].Value != null)
                    {
                        string itemName = row.Cells["item_name"].Value.ToString();
                        string itemCode = row.Cells["item_code"].Value.ToString();
                        string Dlocation = row.Cells["default_location"].Value.ToString();
                        // string time = Convert.ToDateTime(row.Cells["time"].Value).ToString("hh:mm:ss"); // Ensure Date is converted correctly
                        string time = Convert.ToDateTime(row.Cells["time"].Value).ToString("hh:mm:ss tt");

                        string Condition = row.Cells["condition"].Value.ToString();
                        string Status = row.Cells["status"].Value.ToString();
                        string Clocation = row.Cells["from_location"].Value.ToString();



                        // Draw cells with borders
                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(time, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(itemCode, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + cellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(itemName, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 2 * cellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight));
                        e.Graphics.DrawString(Dlocation, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 3 * cellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(Condition, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 5 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight));
                        e.Graphics.DrawString(Status, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 3 * cellWidth + dcellWidth, tableY, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight));
                        e.Graphics.DrawString(Clocation, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new RectangleF(tableHeaderX + 4 * cellWidth + dcellWidth, tableY, dcellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        tableY += cellHeight;

                        // Check if there's enough space for the next row
                        if (tableY + cellHeight > e.MarginBounds.Bottom)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            // Date
            string currentDate = DateTime.Today.ToString("yyyy-MM-dd");
            e.Graphics.DrawString("Date: " + currentDate, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(50, tableY));
            //tableY += 30;


            // Signature
            e.Graphics.DrawString("Signature: ........................", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, tableY));
            //tableY += 10;

            // Check if there's more content to print on subsequent pages
            if (tableY + cellHeight > e.MarginBounds.Bottom)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }

        }
    }
}
