namespace GradeApp
{
    partial class MainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
            panelAdmin = new Panel();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            buttonLogout = new Button();
            button5 = new Button();
            button4 = new Button();
            buttonDashboard = new Button();
            panelContent = new Panel();
            panelAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panelAdmin
            // 
            panelAdmin.BackColor = SystemColors.AppWorkspace;
            panelAdmin.Controls.Add(button1);
            panelAdmin.Controls.Add(pictureBox2);
            panelAdmin.Controls.Add(buttonLogout);
            panelAdmin.Controls.Add(button5);
            panelAdmin.Controls.Add(button4);
            panelAdmin.Controls.Add(buttonDashboard);
            panelAdmin.Dock = DockStyle.Left;
            panelAdmin.Location = new Point(0, 0);
            panelAdmin.Name = "panelAdmin";
            panelAdmin.Size = new Size(149, 450);
            panelAdmin.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 143);
            button1.Name = "button1";
            button1.Size = new Size(112, 23);
            button1.TabIndex = 7;
            button1.Text = "Manage";
            button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(35, 21);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(66, 73);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // buttonLogout
            // 
            buttonLogout.Location = new Point(12, 379);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(112, 23);
            buttonLogout.TabIndex = 6;
            buttonLogout.Text = "Logout";
            buttonLogout.UseVisualStyleBackColor = true;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // button5
            // 
            button5.Location = new Point(12, 201);
            button5.Name = "button5";
            button5.Size = new Size(112, 23);
            button5.TabIndex = 5;
            button5.Text = "Rangking";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 172);
            button4.Name = "button4";
            button4.Size = new Size(112, 23);
            button4.TabIndex = 4;
            button4.Text = "Counter";
            button4.UseVisualStyleBackColor = true;
            // 
            // buttonDashboard
            // 
            buttonDashboard.Location = new Point(12, 114);
            buttonDashboard.Name = "buttonDashboard";
            buttonDashboard.Size = new Size(112, 23);
            buttonDashboard.TabIndex = 0;
            buttonDashboard.Text = "Dashboard";
            buttonDashboard.UseVisualStyleBackColor = true;
            buttonDashboard.Click += buttonDashboard_Click;
            // 
            // panelContent
            // 
            panelContent.Location = new Point(145, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(654, 450);
            panelContent.TabIndex = 1;
            // 
            // MainApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContent);
            Controls.Add(panelAdmin);
            Name = "MainApp";
            Text = "Main App";
            panelAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelAdmin;
        private Button button2;
        private Button button1;
        private Button buttonDashboard;
        private Button buttonLogout;
        private Button button5;
        private Button button4;
        private Button button3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panelContent;
    }
}