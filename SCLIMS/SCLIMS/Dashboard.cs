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
    public partial class Dashboard : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FTF2OSG\SQLEXPRESS;Initial Catalog=sclims;Integrated Security=True;");

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //lblTime.Text =System.DateTime
            // Count mice
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Main lab' AND item_name = 'mouse'", con);
            var count1 = (int)cmd.ExecuteScalar();
            mlMo.Text = count1.ToString();
            con.Close();

            // Count CPUs
            con.Open();
            SqlCommand cmdCpu = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Main lab' AND item_name = 'CPU'", con);
            var count2 = (int)cmdCpu.ExecuteScalar();
            mlCpu.Text = count2.ToString();
            con.Close();

            // Count Monitors
            con.Open();
            SqlCommand cmdMonitor = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Main lab' AND item_name = 'Monitor'", con);
            var count3 = (int)cmdMonitor.ExecuteScalar();
            mlMon.Text = count3.ToString();
            con.Close();

            // Count Keyboards
            con.Open();
            SqlCommand cmdKeyboard = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Main lab' AND item_name = 'Keyboard'", con);
            var count4 = (int)cmdKeyboard.ExecuteScalar();
            mlKey.Text = count4.ToString();
            con.Close();

            //lab1
            // Count Keyboards lab1
            con.Open();
            SqlCommand cmdKeyboardlb1 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'lab1' AND item_name = 'Keyboard'", con);
            var count5 = (int)cmdKeyboardlb1.ExecuteScalar();
            lb1Key.Text = count5.ToString();
            con.Close();

            // Count Monitors lab1
            con.Open();
            SqlCommand cmdMonitorlb1 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'lab1' AND item_name = 'Monitor'", con);
            var count6 = (int)cmdMonitorlb1.ExecuteScalar();
            lb1Moni.Text = count6.ToString();
            con.Close();

            // Count CPU lab1
            con.Open();
            SqlCommand cmdCPUlb1 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'lab1' AND item_name = 'CPU'", con);
            var count7 = (int)cmdCPUlb1.ExecuteScalar();
            lb1Cpu.Text = count7.ToString();
            con.Close();

            // Count mice lab1
            con.Open();
            SqlCommand cmdmouselb1 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'lab1' AND item_name = 'mouse'", con);
            var count14 = (int)cmdmouselb1.ExecuteScalar();
            lb1Mo.Text = count14.ToString();
            con.Close();



            //lab2
            // Count Keyboards lab2
            con.Open();
            SqlCommand cmdKeyboardlb2 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Lab2' AND item_name = 'Keyboard'", con);
            var count8 = (int)cmdKeyboardlb2.ExecuteScalar();
            lb2Key.Text = count8.ToString();
            con.Close();

            // Count Monitors lab2
            con.Open();
            SqlCommand cmdMonitorlb2 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Lab2' AND item_name = 'Monitor'", con);
            var count9 = (int)cmdMonitorlb2.ExecuteScalar();
            lb2Moni.Text = count9.ToString();
            con.Close();

            // Count CPU lab2
            con.Open();
            SqlCommand cmbCPUlb2 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Lab2' AND item_name = 'CPU'", con);
            var count15 = (int)cmbCPUlb2.ExecuteScalar();
            lb2CPU.Text = count15.ToString();
            con.Close();

            // Count mice lab2
            con.Open();
            SqlCommand cmdmicelb2 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Lab2' AND item_name = 'mouse'", con);
            var count17 = (int)cmdmicelb2.ExecuteScalar();
            lb2Mo.Text = count17.ToString();
            con.Close();



            //lab3
            // Count Keyboards lab3
            con.Open();
            SqlCommand cmdKeyboardlb3 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Lab3' AND item_name = 'Keyboard'", con);
            var count10 = (int)cmdKeyboardlb3.ExecuteScalar();
            lb3Key.Text = count10.ToString();
            con.Close();

            // Count Monitors lab3
            con.Open();
            SqlCommand cmdMonitorlb3 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Lab3' AND item_name = 'Monitor'", con);
            var count11 = (int)cmdMonitorlb3.ExecuteScalar();
            lb3Moni.Text = count11.ToString();
            con.Close();

            // Count CPU lab3
            con.Open();
            SqlCommand cmdCpUlb3 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Lab3' AND item_name = 'CPU'", con);
            var count18 = (int)cmdCpUlb3.ExecuteScalar();
            lb3Cpu.Text = count18.ToString();
            con.Close();

            // Count mice lab3
            con.Open();
            SqlCommand cmdmicelb3 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Lab3' AND item_name = 'mouse'", con);
            var count19 = (int)cmdmicelb3.ExecuteScalar();
            lb3Mo.Text = count19.ToString();
            con.Close();


            //lab4
            // Count Keyboards lab4
            con.Open();
            SqlCommand cmdKeyboardlb4 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Lab4' AND item_name = 'Keyboard'", con);
            var count12 = (int)cmdKeyboardlb4.ExecuteScalar();
            lb4Key.Text = count12.ToString();
            con.Close();

            // Count Monitors lab4
            con.Open();
            SqlCommand cmdMonitorlb4 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Lab4' AND item_name = 'Monitor'", con);
            var count13 = (int)cmdMonitorlb4.ExecuteScalar();
            lb4Moni.Text = count13.ToString();
            con.Close();

            //Count CPU lab5
             con.Open();
            SqlCommand cmdCPUlb4 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Lab4' AND item_name = 'Keyboard'", con);
            var count20 = (int)cmdCPUlb4.ExecuteScalar();
            lb4CPU.Text = count20.ToString();
            con.Close();

            // Count Mice lab4
            con.Open();
            SqlCommand cmdmouselb4 = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Lab4' AND item_name = 'Monitor'", con);
            var count21 = (int)cmdmouselb4.ExecuteScalar();
            lb4Mo.Text = count21.ToString();
            con.Close();


            //hardware lab
            // Count CPU hardware lab
            con.Open();
            SqlCommand cmdhlCPU = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Hardware lab' AND item_name = 'CPU'", con);
            var count22 = (int)cmdhlCPU.ExecuteScalar();
            lblhlCPU.Text = count22.ToString();
            con.Close();

            //hardware lab
            // Count Monitor hardware lab
            con.Open();
            SqlCommand cmdhlMoni = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Hardware lab' AND item_name = 'CPU'", con);
            var count23 = (int)cmdhlMoni.ExecuteScalar();
            lblhlMoni.Text = count23.ToString();
            con.Close();

            //hardware lab
            // Count CPU hardware lab
            con.Open();
            SqlCommand cmdhlkey = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Hardware lab' AND item_name = 'CPU'", con);
            var count24 = (int)cmdhlkey.ExecuteScalar();
            lblhlKey.Text = count24.ToString();
            con.Close();

            //hardware hardware lab
            // Count mice hardware lab
            con.Open();
            SqlCommand cmdhlMo = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Hardware lab' AND item_name = 'CPU'", con);
            var count25 = (int)cmdhlMo.ExecuteScalar();
            lblhlMo.Text = count25.ToString();
            con.Close();


            //Not work item
            // Count CPU not work
            con.Open();
            SqlCommand cmdnwCPU = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Hardware lab' AND item_name = 'CPU'", con);
            var count26 = (int)cmdnwCPU.ExecuteScalar();
            lblNwcpu.Text = count26.ToString();
            con.Close();

            //not work item
            // Count Monitor not work
            con.Open();
            SqlCommand cmdnwmoni = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Hardware lab' AND item_name = 'CPU'", con);
            var count27 = (int)cmdnwmoni.ExecuteScalar();
            lblNwmoni.Text = count27.ToString();
            con.Close();


            // Count KEYboard not work
            con.Open();
            SqlCommand cmdnwkey = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Hardware lab' AND item_name = 'CPU'", con);
            var count28 = (int)cmdnwkey.ExecuteScalar();
            lblNwkey.Text = count28.ToString();
            con.Close();


            // Count mice not work
            con.Open();
            SqlCommand cmdnwmo = new SqlCommand("SELECT COUNT(*) FROM items WHERE current_location = 'Hardware lab' AND item_name = 'CPU'", con);
            var count29 = (int)cmdnwmo.ExecuteScalar();
            lblNwmo.Text = count29.ToString();
            con.Close();


        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
