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
    public partial class Inventorysearch : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");
        public SqlCommand cmd;

        public Inventorysearch()
        {
            InitializeComponent();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtitemcode.Text = "";
           //dataGridView1.Rows.Clear();
           
        }

        private void btncheck2_Click(object sender, EventArgs e)
        {
            /*
           
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM items WHERE item_code = @item_code", con))
                {
                    cmd.Parameters.AddWithValue("@item_code", txtitemcode.Text);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0) // Check if any rows are returned
                        {
                            txtIname.Text = dt.Rows[0]["item_name"].ToString();
                            txtplace.Text = dt.Rows[0]["current_location"].ToString();
                            txtcondition.Text = dt.Rows[0]["condition"].ToString();
                            txtdate.Text = dt.Rows[0]["date"].ToString();
                          //  txtsuname.Text = dt.Rows[0]["suname"].ToString();
                            txttime.Text = dt.Rows[0]["time"].ToString();

                            MessageBox.Show("Item is found.");
                        }
                        else
                        {
                            txtIname.Text = "";
                            txtplace.Text = "";
                            txtcondition.Text = "";
                            txtdate.Text = ""; // Clear text for date field
                            txtsuname.Text = ""; // Clear text for suname field
                            txttime.Text = ""; // Clear text for time field

                            MessageBox.Show("Item is not found. Please check item code.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            */
            /*

           con.Open();
            cmd = new SqlCommand("SELECT items_transfer_external,items_transfer_internal.location,items.item_name FROM items join items_transfer_external on items.item_code = items_transfer_external.item_code", con);
            cmd.Parameters.AddWithValue("@item_code", txtitemcode.Text);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader["item_name"]));
             
                 //   txtIname.Text = reader["item_name"].ToString();
                }
            }

            con.Close();
            */

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void searchData(string valueToFind)
        {
            con.Open();
            try
            {
                string searchQuery = "SELECT date,item_code,item_name,default_location,current_location,status,brand,model,category_id FROM items  WHERE items.item_code LIKE @valueToFind OR items.item_name LIKE @valueToFind";

                using (SqlCommand command = new SqlCommand(searchQuery, con))
                {
                    command.Parameters.AddWithValue("@valueToFind", "%" + valueToFind + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            con.Close() ;
        }



        private void txtitemcode_TextChanged(object sender, EventArgs e)
        {
            searchData(txtitemcode.Text);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
