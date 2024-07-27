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
    public partial class Other : Form
    {
        public Other()
        {
            InitializeComponent();
        }

        private void Other_Load(object sender, EventArgs e)
        {
            Other_Load(new otherplace());
        }

        private void Other_Load(Form form)
        {
            // Remove any existing controls from the panel
            if (otherPnl.Controls.Count > 0)
                otherPnl.Controls.RemoveAt(0);

            // Set properties and add the form to the panel
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            otherPnl.Controls.Add(form);
            otherPnl.Tag = form;
            form.Show();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            Other_Load(new otherplace());
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
           Other_Load(new items_return());
        }

        private void otherPnl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
