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
    public partial class Category : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");

        public Category()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                using (SqlCommand cmd_Add = new SqlCommand("INSERT INTO category (category_id,name,model_name,brand) VALUES (@category_id,@name,@model_name,@brand)", con))
                {
                    cmd_Add.Parameters.AddWithValue("@category_id",txtCatid.Text);
                    cmd_Add.Parameters.AddWithValue("@name", txtCatname.Text);
                    cmd_Add.Parameters.AddWithValue("@model_name", txtMname.Text);
                    cmd_Add.Parameters.AddWithValue("@brand", txtBrand.Text);





                    cmd_Add.ExecuteNonQuery();
                }

                MessageBox.Show("User added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM category WHERE model_name=@model_name", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@model_name",txtMname.Text);
                    cmd.ExecuteNonQuery();
                }

               
                MessageBox.Show("Item model is remove successfully.");

                txtCatid.Clear();
                txtCatname.Clear();
                txtMname.Clear();
                txtBrand.Clear();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCatid.Clear();
            txtCatname.Clear();
            txtMname.Clear();
            txtBrand.Clear();
        }
    }
}
