using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SCLIMS
{
    public partial class Dashboard : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("h:mm tt");

            // Count mice
            CountItems("Main lab", "mouse", mlMo);
            CountItems("Main lab", "CPU", mlCpu);
            CountItems("Main lab", "Monitor", mlMon);
            CountItems("Main lab", "Keyboard", mlKey);

            // Count items for lab1
            CountItems("lab1", "Keyboard", lb1Key);
            CountItems("lab1", "Monitor", lb1Moni);
            CountItems("lab1", "CPU", lb1Cpu);
            CountItems("lab1", "mouse", lb1Mo);

            // Count items for lab2
            CountItems("Lab2", "Keyboard", lb2Key);
            CountItems("Lab2", "Monitor", lb2Moni);
            CountItems("Lab2", "CPU", lb2CPU);
            CountItems("Lab2", "mouse", lb2Mo);

            // Count items for lab3
            CountItems("Lab3", "Keyboard", lb3Key);
            CountItems("Lab3", "Monitor", lb3Moni);
            CountItems("Lab3", "CPU", lb3Cpu);
            CountItems("Lab3", "mouse", lb3Mo);

            // Count items for lab4
            CountItems("Lab4", "Keyboard", lb4Key);
            CountItems("Lab4", "Monitor", lb4Moni);
            CountItems("Lab4", "CPU", lb4CPU);
            CountItems("Lab4", "mouse", lb4Mo);

            // Count items for hardware lab
            CountItems("Hardware lab", "Keyboard", lblhlKey);
            CountItems("Hardware lab", "Monitor", lblhlMoni);
            CountItems("Hardware lab", "CPU", lblhlCPU);
            CountItems("Hardware lab", "mouse", lblhlMo);

            // Count not work items
            CountNotWorkItems("CPU", lblNwcpu);
            CountNotWorkItems("Monitor", lblNwmoni);
            CountNotWorkItems("Keyboard", lblNwkey);
            CountNotWorkItems("Mouse", lblNwmo);
        }

        private void CountItems(string location, string itemName, Label label)
        {
            using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM items WHERE current_location = @location AND item_name = @itemName", con))
            {
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                con.Open();
                var count = (int)cmd.ExecuteScalar();
                label.Text = count.ToString();
                con.Close();
            }
        }

        private void CountNotWorkItems(string itemName, Label label)
        {
            using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM items_not_work WHERE item_name = @itemName", con))
            {
                cmd.Parameters.AddWithValue("@itemName", itemName);
                con.Open();
                var count = (int)cmd.ExecuteScalar();
                label.Text = count.ToString();
                con.Close();
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
