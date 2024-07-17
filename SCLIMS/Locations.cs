using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SCLIMS
{
    public partial class Locations : Form
    {
        // Declare SqlConnection and SqlCommand objects
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");
        private SqlCommand cmd;

        public Locations()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Open a new SqlConnection using the declared connection string
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;"))
                {
                    // Open the connection
                    con.Open();
                    // Create a new SqlCommand object
                    using (SqlCommand cmd_Add = new SqlCommand("INSERT INTO locations (location_id, location_name) VALUES (@location_id, @location_name)", con))
                    {
                        // Add parameters
                        cmd_Add.Parameters.AddWithValue("@location_id", txtLocid.Text);
                        cmd_Add.Parameters.AddWithValue("@location_name", txtLoc.Text);

                        // Execute the command
                        cmd_Add.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Location added successfully");

                txtLoc.Clear();
                txtLocid.Clear();
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
                // Open the connection
                con.Open();
                // Create a new SqlCommand object
                using (SqlCommand cmd = new SqlCommand("DELETE FROM locations WHERE location_id=@location_id", con))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@location_id", txtLocid.Text);
                    // Execute the command
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Location deleted successfully.");

                // Clear text boxes
                txtLoc.Clear();
                txtLocid.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection in the finally block
                con.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear text boxes
            txtLoc.Clear();
            txtLocid.Clear();
        }
    }
}
