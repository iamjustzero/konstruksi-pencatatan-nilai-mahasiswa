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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            lUsername = new Label();
            lPassword = new Label();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            bLogin = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lUsername
            // 
            lUsername.AutoSize = true;
            lUsername.Location = new Point(205, 235);
            lUsername.Name = "lUsername";
            lUsername.Size = new Size(60, 15);
            lUsername.TabIndex = 0;
            lUsername.Text = "Username";
            lUsername.Click += label1_Click;
            // 
            // lPassword
            // 
            lPassword.AutoSize = true;
            lPassword.Location = new Point(205, 268);
            lPassword.Name = "lPassword";
            lPassword.Size = new Size(57, 15);
            lPassword.TabIndex = 1;
            lPassword.Text = "Password";
            lPassword.Click += label2_Click;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(308, 235);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(161, 23);
            tbUsername.TabIndex = 2;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(308, 268);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(161, 23);
            tbPassword.TabIndex = 3;
            // 
            // bLogin
            // 
            bLogin.Location = new Point(354, 321);
            bLogin.Name = "bLogin";
            bLogin.Size = new Size(75, 23);
            bLogin.TabIndex = 4;
            bLogin.Text = "Login";
            bLogin.UseVisualStyleBackColor = true;
            bLogin.Click += bLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(329, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(126, 140);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(238, 49);
            label1.Name = "label1";
            label1.Size = new Size(304, 22);
            label1.TabIndex = 6;
            label1.Text = "Student Grade Management System";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(bLogin);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(lPassword);
            Controls.Add(lUsername);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lUsername;
        private Label lPassword;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button bLogin;
        private PictureBox pictureBox1;
        private Label label1;
    }
}
