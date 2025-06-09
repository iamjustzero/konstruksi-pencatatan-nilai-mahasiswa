using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeApp
{
    public partial class MainApp : Form
    {
        public MainApp()
        {
            InitializeComponent();
            this.MaximumSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.MaximizeBox = false;
        }

        private void ShowUserControl(UserControl control)
        {
            panelContent.Controls.Clear();
            panelContent.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Dashboard());
        }

        private void buttonManage_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Manage());
        }

        private void buttonCounter_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Counter());
        }

        private void buttonRangking_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Rangking());
        }
    }
}
