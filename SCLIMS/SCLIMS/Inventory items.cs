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

namespace SCLIMS
{
    

    public partial class Inventory_items : Form
    {

        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CPNQ41C\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");
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

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Ensure the text box has a value before proceeding
            if (!string.IsNullOrEmpty(txt_Barcode.Text))
            {
                try
                {
                    MessagingToolkit.Barcode.BarcodeEncoder generator = new MessagingToolkit.Barcode.BarcodeEncoder();
                    generator.BackColor = Color.White;
                    generator.LabelFont = new Font("Arial", 7, FontStyle.Regular);
                    generator.IncludeLabel = true;
                    generator.CustomLabel = txt_Barcode.Text;

                    // Generate the barcode
                    Pic_barcode.Image = generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.Code93, txt_Barcode.Text);
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
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO items (item_name,category,default_place,brand,model,serial_number,date,time,company_name,mobile_no,address,bar_code,item_code) VALUES (@item_name, @category, @default_place, @brand, @model, @serial_number, @date, @time, @company_name, @telephone, @address, @bar_code, @item_code)", con))
                    {
                        cmd.Parameters.AddWithValue("@item_name", txtIname.Text);
                        cmd.Parameters.AddWithValue("@category", cmbCategory.Text);
                        cmd.Parameters.AddWithValue("@default_place", cmbPlace.Text);
                        cmd.Parameters.AddWithValue("@brand", cmbBrand.Text);
                        cmd.Parameters.AddWithValue("@model", cmbModel.Text);
                        cmd.Parameters.AddWithValue("@serial_number", txtSnumber.Text);
                       
                        
                        cmd.Parameters.AddWithValue("@company_name", txtCname.Text);
                        cmd.Parameters.AddWithValue("@mobile_no", txtTel.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@bar_code", txt_Barcode.Text);
                        cmd.Parameters.AddWithValue("@item_code", txtIcode.Text);
                        cmd.ExecuteNonQuery();
                        isSuccess = true;
                    }

                    MessageBox.Show("Data inserted successfully.");
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
                    using (SqlCommand cmd = new SqlCommand("UPDATE items SET item_name = @item_name, category = @category, default_location = @default_location, brand = @brand, model = @model, serial_number = @serial_number, company_name = @company_name, mobile_no= @mobile_no, address = @address, bar_code = @bar_code WHERE item_code = @item_code", con))
                    {
                        cmd.Parameters.AddWithValue("@item_name", txtIname.Text);
                        cmd.Parameters.AddWithValue("@category", cmbCategory.Text);
                        cmd.Parameters.AddWithValue("@default_location", cmbPlace.Text);
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
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_Barcode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
