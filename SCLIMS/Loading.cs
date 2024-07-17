using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCLIMS
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
            label2.Text = $"{progressBar1.Value}%";

            if (progressBar1.Value >= 99)
            {
                timer1.Enabled = false;
                Login frm = new Login();
                frm.Show();
                Hide();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (circularProgressBar1.Value + 3 <= circularProgressBar1.Maximum)
            {
                circularProgressBar1.Value += 3;
            }
            else
            {
                circularProgressBar1.Value = 0;
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
