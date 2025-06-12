namespace GradeApp
{
    public partial class Login : Form
    {
        private const string USERNAME = "admin";
        private const string PASSWORD = "admin";

        public Login()
        {
            InitializeComponent();
            this.MaximumSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.MaximizeBox = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            if (username == USERNAME && password == PASSWORD)
            {
                this.Hide();
                MainApp mainApp = new MainApp();
                mainApp.Show();
            }
            else
            {
                MessageBox.Show("Username atau password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
