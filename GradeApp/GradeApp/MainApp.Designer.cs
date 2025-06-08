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
            panel1 = new Panel();
            buttonDashboard = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(buttonDashboard);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(149, 450);
            panel1.TabIndex = 0;
            // 
            // buttonDashboard
            // 
            buttonDashboard.Location = new Point(12, 100);
            buttonDashboard.Name = "buttonDashboard";
            buttonDashboard.Size = new Size(112, 23);
            buttonDashboard.TabIndex = 0;
            buttonDashboard.Text = "Dashboard";
            buttonDashboard.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(12, 129);
            button1.Name = "button1";
            button1.Size = new Size(112, 23);
            button1.TabIndex = 1;
            button1.Text = "Input";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 158);
            button2.Name = "button2";
            button2.Size = new Size(112, 23);
            button2.TabIndex = 2;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 187);
            button3.Name = "button3";
            button3.Size = new Size(112, 23);
            button3.TabIndex = 3;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(12, 216);
            button4.Name = "button4";
            button4.Size = new Size(112, 23);
            button4.TabIndex = 4;
            button4.Text = "Hitung";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(12, 245);
            button5.Name = "button5";
            button5.Size = new Size(112, 23);
            button5.TabIndex = 5;
            button5.Text = "Rangking";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(12, 379);
            button6.Name = "button6";
            button6.Size = new Size(112, 23);
            button6.TabIndex = 6;
            button6.Text = "Logout";
            button6.UseVisualStyleBackColor = true;
            // 
            // MainApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "MainApp";
            Text = "Main App";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Button button1;
        private Button buttonDashboard;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
    }
}