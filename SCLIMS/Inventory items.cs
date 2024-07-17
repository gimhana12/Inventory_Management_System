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
using System.Drawing.Imaging;
using MessagingToolkit.Barcode;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SCLIMS
{
    

    public partial class Inventory_items : Form
    {

        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");
        public SqlCommand cmd;


        public Inventory_items()
        {
            InitializeComponent();
            txtIcode.TextChanged += new EventHandler(txtIcode_TextChanged);
        }

        private void txtIcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIcode.Text))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT item_name, category, default_location, brand, model, serial_number, date, time,company_name,mobile_no, address, bar_code FROM items WHERE item_code = @item_code", con))
                    {
                        cmd.Parameters.AddWithValue("@item_code", txtIcode.Text);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtIname.Text = reader["item_name"].ToString();
                                cmbCategory.Text = reader["category"].ToString();
                                cmbPlace.Text = reader["default_location"].ToString();
                                cmbBrand.Text = reader["brand"].ToString();
                                cmbModel.Text = reader["model"].ToString();
                                txtSnumber.Text = reader["serial_number"].ToString(); 
                                txtCname.Text = reader["company_name"].ToString();
                                txtTel.Text = reader["mobile_no"].ToString();
                                txtAddress.Text = reader["address"].ToString();
                                txt_Barcode.Text = reader["bar_code"].ToString();
                            }
                            else
                            {
                                // Do not clear fields if item is not found; just keep them as is for new entry
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void Inventory_items_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sclimsDataSet6.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.sclimsDataSet6.category);
            // TODO: This line of code loads data into the 'sclimsDataSet6.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.sclimsDataSet6.category);
            // TODO: This line of code loads data into the 'sclimsDataSet1.locations' table. You can move, or remove it, as needed.
            this.locationsTableAdapter.Fill(this.sclimsDataSet1.locations);
            // TODO: This line of code loads data into the 'sclimsDataSet4.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.sclimsDataSet4.items);
            // TODO: This line of code loads data into the 'sclimsDataSet3.items' table. You can move, or remove it, as needed.

            cmbPlace.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            cmbModel.SelectedIndex = -1;
            cmbBrand.SelectedIndex = -1;

            dataGridView1.ClearSelection();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Barcode.Text))
            {
                try
                {
                    // Initialize the barcode generator
                    MessagingToolkit.Barcode.BarcodeEncoder generator = new MessagingToolkit.Barcode.BarcodeEncoder();
                    generator.BackColor = Color.White;
                    generator.LabelFont = new Font("Arial", 12, FontStyle.Regular);
                    generator.IncludeLabel = true;
                    generator.CustomLabel = txt_Barcode.Text;

                    // Generate the barcode image
                    Image barcodeImage = generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.Code93, txt_Barcode.Text);

                    // Create a new bitmap to hold the place name and barcode
                    Bitmap finalImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 30); // Adding extra space for the place name
                    using (Graphics graphics = Graphics.FromImage(finalImage))
                    {
                        // Set the background color
                        graphics.Clear(Color.White);

                        // Draw the place name above the barcode
                        string placeName = cmbPlace.Text;
                        Font placeNameFont = new Font("Arial", 14, FontStyle.Bold);
                        SizeF placeNameSize = graphics.MeasureString(placeName, placeNameFont);
                        float placeNameX = (finalImage.Width - placeNameSize.Width) / 2;
                        graphics.DrawString(placeName, placeNameFont, Brushes.Black, placeNameX, 5); // 5 pixels from the top

                        // Draw the barcode below the place name
                        graphics.DrawImage(barcodeImage, 0, 30); // 30 pixels from the top
                    }

                    // Set the final image to the PictureBox
                    Pic_barcode.Image = finalImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while generating the barcode: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a value for the barcode.");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog SD = new SaveFileDialog();
            SD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SD.FileName = txt_Barcode.Text;
            SD.SupportMultiDottedExtensions = true;
            SD.AddExtension = true;
            SD.Filter = "PNG File|*.png";

            if (SD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Pic_barcode.Image.Save(SD.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Barcode saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the barcode: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;

            try
            {
                con.Open();
                if (!string.IsNullOrEmpty(txtIcode.Text) && !string.IsNullOrEmpty(txtIname.Text))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO items (item_name,category,default_location,current_location,brand,model,serial_number,date,time,company_name,mobile_no,address,bar_code,item_code) VALUES (@item_name, @category, @default_location,@current_location, @brand, @model, @serial_number, @date, @time, @company_name, @mobile_no, @address, @bar_code, @item_code)", con))
                    {
                        cmd.Parameters.AddWithValue("@item_name", txtIname.Text);
                        cmd.Parameters.AddWithValue("@category", cmbCategory.Text);
                        cmd.Parameters.AddWithValue("@default_location", cmbPlace.Text);
                        cmd.Parameters.AddWithValue("@current_location", cmbPlace.Text);

                        cmd.Parameters.AddWithValue("@brand", cmbBrand.Text);
                        cmd.Parameters.AddWithValue("@model", cmbModel.Text);
                        cmd.Parameters.AddWithValue("@serial_number", txtSnumber.Text);
                       
                        
                        cmd.Parameters.AddWithValue("@company_name", txtCname.Text);
                        cmd.Parameters.AddWithValue("@mobile_no", txtTel.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@bar_code", txt_Barcode.Text);
                        cmd.Parameters.AddWithValue("@item_code", txtIcode.Text);
                        cmd.Parameters.AddWithValue("@time", System.DateTime.Now.ToString("h:mm tt"));
                        cmd.Parameters.AddWithValue("@date", System.DateTime.Now.ToShortDateString());


                        cmd.ExecuteNonQuery();
                        isSuccess = true;
                    }

                    MessageBox.Show("Data inserted successfully.");

                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show("Please provide values for item code and item name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            if (isSuccess)
            {


                // Set the text of txtTime to the current time formatted as "hh:mm:ss tt" (hours in 12-hour format, minutes, seconds, and AM/PM)
                //this.txtTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
                System.DateTime.Now.ToString("h:mm tt");

                // Set the text of txtDate to the current date formatted as a long date string (e.g., "Monday, May 24, 2024")
                // this.txtDate.Text = DateTime.Now.ToLongDateString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (!string.IsNullOrEmpty(txtIcode.Text) && !string.IsNullOrEmpty(txtIname.Text))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE items SET item_name = @item_name, category = @category, default_location = @default_location, current_location = @current_location , brand = @brand, model = @model, serial_number = @serial_number, company_name = @company_name, mobile_no= @mobile_no, address = @address, bar_code = @bar_code WHERE item_code = @item_code", con))
                    {
                        cmd.Parameters.AddWithValue("@item_name", txtIname.Text);
                        cmd.Parameters.AddWithValue("@category", cmbCategory.Text);
                        cmd.Parameters.AddWithValue("@default_location", cmbPlace.Text);
                        cmd.Parameters.AddWithValue("@current_location", cmbPlace.Text);
                        cmd.Parameters.AddWithValue("@brand", cmbBrand.Text);
                        cmd.Parameters.AddWithValue("@model", cmbModel.Text);
                        cmd.Parameters.AddWithValue("@serial_number", txtSnumber.Text);
                        cmd.Parameters.AddWithValue("@company_name", txtCname.Text);
                        cmd.Parameters.AddWithValue("@mobile_no", txtTel.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@bar_code", txt_Barcode.Text);
                        cmd.Parameters.AddWithValue("@item_code", txtIcode.Text);  // This is the condition to find the specific record to update
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Item code not found.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please provide values for item code and item name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            // Clear the input fields
            txtIname.Text = "";
            cmbCategory.Text = "";
            cmbPlace.Text = "";
            cmbBrand.Text = "";
            cmbModel.Text = "";
            txtSnumber.Text = "";
            txtCname.Text = "";
            txtTel.Text = "";
            txtAddress.Text = "";
            txt_Barcode.Text = "";
            txtIcode.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIname.Text = "";
            cmbCategory.Text = "";
            cmbPlace.Text = "";
            cmbBrand.Text = "";
            cmbModel.Text = "";
            txtSnumber.Text = "";
            txtCname.Text = "";
            txtTel.Text = "";
            txtAddress.Text = "";
            txt_Barcode.Text = "";
            txtIcode.Text = "";


            Pic_barcode.Image = null;
            // Clear the text in the barcode text box
            //txt_Barcode.Clear();
            // Set the focus back to the barcode text box
            txt_Barcode.Focus();

           // dataGridView1.Refresh();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_Barcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
           // cmbPlace.Hide
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
