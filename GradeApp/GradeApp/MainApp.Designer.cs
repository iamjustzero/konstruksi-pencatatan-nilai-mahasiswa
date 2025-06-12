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
            buttonMataKuliah = new Button();
            buttonRangking = new Button();
            buttonManage = new Button();
            pictureBox2 = new PictureBox();
            buttonLogout = new Button();
            buttonCounter = new Button();
            buttonDashboard = new Button();
            panelContent = new Panel();
            panelAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panelAdmin
            // 
            panelAdmin.BackColor = SystemColors.AppWorkspace;
            panelAdmin.Controls.Add(buttonMataKuliah);
            panelAdmin.Controls.Add(buttonRangking);
            panelAdmin.Controls.Add(buttonManage);
            panelAdmin.Controls.Add(pictureBox2);
            panelAdmin.Controls.Add(buttonLogout);
            panelAdmin.Controls.Add(buttonCounter);
            panelAdmin.Controls.Add(buttonDashboard);
            panelAdmin.Dock = DockStyle.Left;
            panelAdmin.Location = new Point(0, 0);
            panelAdmin.Name = "panelAdmin";
            panelAdmin.Size = new Size(149, 449);
            panelAdmin.TabIndex = 0;
            // 
            // buttonMataKuliah
            // 
            buttonMataKuliah.Location = new Point(12, 230);
            buttonMataKuliah.Name = "buttonMataKuliah";
            buttonMataKuliah.Size = new Size(112, 23);
            buttonMataKuliah.TabIndex = 9;
            buttonMataKuliah.Text = "Subject";
            buttonMataKuliah.UseVisualStyleBackColor = true;
            buttonMataKuliah.Click += buttonMataKuliah_Click;
            // 
            // buttonRangking
            // 
            buttonRangking.Location = new Point(12, 201);
            buttonRangking.Name = "buttonRangking";
            buttonRangking.Size = new Size(112, 23);
            buttonRangking.TabIndex = 8;
            buttonRangking.Text = "Rangking";
            buttonRangking.UseVisualStyleBackColor = true;
            buttonRangking.Click += buttonRangking_Click;
            // 
            // buttonManage
            // 
            buttonManage.Location = new Point(12, 143);
            buttonManage.Name = "buttonManage";
            buttonManage.Size = new Size(112, 23);
            buttonManage.TabIndex = 7;
            buttonManage.Text = "Manage";
            buttonManage.UseVisualStyleBackColor = true;
            buttonManage.Click += buttonManage_Click;
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
            // buttonCounter
            // 
            buttonCounter.Location = new Point(12, 172);
            buttonCounter.Name = "buttonCounter";
            buttonCounter.Size = new Size(112, 23);
            buttonCounter.TabIndex = 4;
            buttonCounter.Text = "Counter";
            buttonCounter.UseVisualStyleBackColor = true;
            buttonCounter.Click += buttonCounter_Click;
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
            ClientSize = new Size(800, 449);
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
        private Button buttonManage;
        private Button buttonDashboard;
        private Button buttonLogout;
        private Button buttonCounter;
        private Button button3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panelContent;
        private Button buttonRangking;
        private Button buttonMataKuliah;
    }
}