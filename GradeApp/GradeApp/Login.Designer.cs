namespace GradeApp
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lUsername = new Label();
            lPassword = new Label();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            bLogin = new Button();
            SuspendLayout();
            // 
            // lUsername
            // 
            lUsername.AutoSize = true;
            lUsername.Location = new Point(223, 152);
            lUsername.Name = "lUsername";
            lUsername.Size = new Size(60, 15);
            lUsername.TabIndex = 0;
            lUsername.Text = "Username";
            lUsername.Click += label1_Click;
            // 
            // lPassword
            // 
            lPassword.AutoSize = true;
            lPassword.Location = new Point(223, 185);
            lPassword.Name = "lPassword";
            lPassword.Size = new Size(57, 15);
            lPassword.TabIndex = 1;
            lPassword.Text = "Password";
            lPassword.Click += label2_Click;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(326, 152);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(161, 23);
            tbUsername.TabIndex = 2;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(326, 185);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(161, 23);
            tbPassword.TabIndex = 3;
            // 
            // bLogin
            // 
            bLogin.Location = new Point(372, 238);
            bLogin.Name = "bLogin";
            bLogin.Size = new Size(75, 23);
            bLogin.TabIndex = 4;
            bLogin.Text = "Login";
            bLogin.UseVisualStyleBackColor = true;
            bLogin.Click += bLogin_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bLogin);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(lPassword);
            Controls.Add(lUsername);
            Name = "Form1";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lUsername;
        private Label lPassword;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button bLogin;
    }
}
