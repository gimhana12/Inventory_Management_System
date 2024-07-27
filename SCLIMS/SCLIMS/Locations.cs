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
    public partial class Locations : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");
        public SqlCommand cmd;

        public Locations()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("YourConnectionStringHere"))
                {
                    using (SqlCommand cmd_Add = new SqlCommand("INSERT INTO locations (location_id, location_name) VALUES (@location_id, @location_name)", con))
                    {
                        con.Open();
                        cmd_Add.Parameters.AddWithValue("@location_id", txtLocid.Text);
                        cmd_Add.Parameters.AddWithValue("@location_name", txtLoc.Text);

                        cmd_Add.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Location added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM locations WHERE location_id=@location_id", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@location_id", txtLocid.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Location deleted successfully.");

                txtLoc.Clear();
                txtLocid.Clear();

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
            txtLoc.Clear();
            txtLocid.Clear();
        }
    }
}
