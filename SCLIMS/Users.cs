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
    public partial class Users : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");
        //public SqlCommand cmd;

        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                using (SqlCommand cmd_Add = new SqlCommand("INSERT INTO users (id_no, fullname, username, email, mobile_no) VALUES (@id_no, @fullname, @username, @email, @mobile_no)", con))
                {
                    cmd_Add.Parameters.AddWithValue("@id_no", txtID.Text);
                    cmd_Add.Parameters.AddWithValue("@fullname", txtFname.Text);
                    cmd_Add.Parameters.AddWithValue("@username", txtUname.Text);
                    cmd_Add.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd_Add.Parameters.AddWithValue("@mobile_no", txtMno.Text);

                    cmd_Add.ExecuteNonQuery();
                }

                MessageBox.Show("User added successfully");

                txtEmail.Clear();
                txtID.Text = "";
                txtFname.Clear();
                txtUname.Clear();
                txtMno.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred: ID number is already used");
            }
            finally
            {
                con.Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE id_no=@id_no", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@id_no", txtID.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Location deleted successfully.");

                txtEmail.Clear();
                txtID.Text="";
                txtFname.Clear();
                txtUname.Clear();
                txtMno.Clear();

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
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE users SET username = @username, fullname = @fullname, email = @email, mobile_no = @mobile_no WHERE id_no = @id_no", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@id_no", txtID.Text);
                    cmd.Parameters.AddWithValue("@username", txtUname.Text); 
                    cmd.Parameters.AddWithValue("@fullname", txtFname.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@mobile_no", txtMno.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("User information updated successfully");
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

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtID.Text = "";
            txtFname.Clear();
            txtUname.Clear();
            txtMno.Clear();
        }

        private void txtID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
