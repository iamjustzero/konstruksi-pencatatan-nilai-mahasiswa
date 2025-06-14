namespace GradeApp
{
    public partial class Login : Form
    {
        private const string username = "admin";
        private const string password = "admin";

        public Login()
        {
            InitializeComponent();
            this.MaximumSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            string usernameInput = tbUsername.Text;
            string passwordInput = tbPassword.Text;

            if (usernameInput == username && passwordInput == password)
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
