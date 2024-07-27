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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Home_Load(new Dashboard());
        }

        private void Home_Load(object Form)
        {
            if (this.panel3.Controls.Count > 0)
                this.panel3.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(f);
            this.panel3.Tag = f;
            f.Show();
        }

        private void btndboard_Click(object sender, EventArgs e)
        {
            Home_Load(new Form1());
        }

        private void btnimange_Click(object sender, EventArgs e)
        {
            Home_Load(new Inventorymange());
        }

        private void btncinventory_Click(object sender, EventArgs e)
        {
            Home_Load(new Inventorysearch());
        }

        private void btnsetting_Click(object sender, EventArgs e)
        {
            new settings_and_maintenance().Show();
        }

        private void btniitem_Click(object sender, EventArgs e)
        {
            Home_Load(new Inventory_items());
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            Home_Load(new Report());
        }
    }
}
