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
    public partial class Password_manage : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");

        public Password_manage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE username=@username", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("user & password");

                // Clear text boxes
                txtUsername.Clear();
                txtPass.Clear();
                txtCpass.Clear();
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
                using (SqlCommand cmd = new SqlCommand("UPDATE pws SET password = @password, Cpassword = @Cpassword WHERE username= @username", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPass.Text);
                    cmd.Parameters.AddWithValue("@Cpassword", txtCpass.Text);
                    

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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                
                    using (SqlCommand cmd_Add = new SqlCommand("INSERT INTO pws (Susername,password,Cpassword) VALUES (@Susername,@password,@Cpassword)", con))
                    {
                        con.Open();
                        cmd_Add.Parameters.AddWithValue("@Susername", txtUsername.Text);
                        cmd_Add.Parameters.AddWithValue("@password", txtPass.Text);
                        cmd_Add.Parameters.AddWithValue("@Cpassword", txtCpass.Text);
                        cmd_Add.ExecuteNonQuery();
                    }
                

                MessageBox.Show("password create successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE pws SET password = @password, Cpassword = @Cpassword WHERE Susername = @Susername", con))
                {
                    cmd.Parameters.AddWithValue("@Susername", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPass.Text);
                    cmd.Parameters.AddWithValue("@Cpassword", txtCpass.Text);

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

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM pws WHERE Susername=@Susername", con))
                {
                   
                    cmd.Parameters.AddWithValue("@Susername", txtUsername.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Location deleted successfully.");

               txtUsername.Clear();
                txtPass.Clear();
               txtCpass.Clear();
               

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
            txtUsername.Clear();
            txtPass.Clear();
            txtCpass.Clear();
        }
    }
}
