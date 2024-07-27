using System;
using System.Windows.Forms;

namespace SCLIMS
{
    public partial class settings_and_maintenance : Form
    {
        public settings_and_maintenance()
        {
            InitializeComponent();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            LoadForm(new Users());
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadForm(new Locations());
        }

        private void btnPchange_Click(object sender, EventArgs e)
        {
            LoadForm(new Password_manage());
        }

        private void LoadForm(Form form)
        {
            // Remove any existing controls from the panel
            if (settingPnl.Controls.Count > 0)
                settingPnl.Controls.RemoveAt(0);

            // Set properties and add the form to the panel
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            settingPnl.Controls.Add(form);
            settingPnl.Tag = form;
            form.Show();
        }

        private void settings_and_maintenance_Load(object sender, EventArgs e)
        {
            LoadForm(new Users());
        }

        private void settingPnl_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadForm(new Category());
        }
    }
}
