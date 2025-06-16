namespace GradeApp
{
    partial class UC_Dashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label labelLowestGradeTitle;
            dgvMataKuliah = new DataGridView();
            labelAverageTitle = new Label();
            labelAverageValue = new Label();
            labelHighestGradeTitle = new Label();
            labelHighestGradeValue = new Label();
            labelAverageValuee = new Label();
            labelLowestGradeValue = new Label();
            labelLowestGradeTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMataKuliah).BeginInit();
            SuspendLayout();
            // 
            // labelLowestGradeTitle
            // 
            labelLowestGradeTitle.AutoSize = true;
            labelLowestGradeTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLowestGradeTitle.Location = new Point(13, 70);
            labelLowestGradeTitle.Name = "labelLowestGradeTitle";
            labelLowestGradeTitle.Size = new Size(93, 15);
            labelLowestGradeTitle.TabIndex = 7;
            labelLowestGradeTitle.Text = "Lowest Grade : ";
            // 
            // dgvMataKuliah
            // 
            dgvMataKuliah.Location = new Point(3, 100);
            dgvMataKuliah.Name = "dgvMataKuliah";
            dgvMataKuliah.Size = new Size(647, 341);
            dgvMataKuliah.TabIndex = 0;
            dgvMataKuliah.CellContentClick += dgvMataKuliah_CellContentClick;
            // 
            // labelAverageTitle
            // 
            labelAverageTitle.AutoSize = true;
            labelAverageTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAverageTitle.Location = new Point(13, 19);
            labelAverageTitle.Name = "labelAverageTitle";
            labelAverageTitle.Size = new Size(100, 15);
            labelAverageTitle.TabIndex = 1;
            labelAverageTitle.Text = "Average Grade : ";
            labelAverageTitle.Click += labelAverageTitle_Click;
            // 
            // labelAverageValue
            // 
            labelAverageValue.AutoSize = true;
            labelAverageValue.Location = new Point(103, 19);
            labelAverageValue.Name = "labelAverageValue";
            labelAverageValue.Size = new Size(0, 15);
            labelAverageValue.TabIndex = 2;
            // 
            // labelHighestGradeTitle
            // 
            labelHighestGradeTitle.AutoSize = true;
            labelHighestGradeTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHighestGradeTitle.Location = new Point(13, 45);
            labelHighestGradeTitle.Name = "labelHighestGradeTitle";
            labelHighestGradeTitle.Size = new Size(96, 15);
            labelHighestGradeTitle.TabIndex = 3;
            labelHighestGradeTitle.Text = "Highest Grade : ";
            // 
            // labelHighestGradeValue
            // 
            labelHighestGradeValue.AutoSize = true;
            labelHighestGradeValue.Location = new Point(115, 45);
            labelHighestGradeValue.Name = "labelHighestGradeValue";
            labelHighestGradeValue.Size = new Size(24, 15);
            labelHighestGradeValue.TabIndex = 5;
            labelHighestGradeValue.Text = "[   ]";
            labelHighestGradeValue.Click += label2_Click;
            // 
            // labelAverageValuee
            // 
            labelAverageValuee.AutoSize = true;
            labelAverageValuee.Location = new Point(115, 19);
            labelAverageValuee.Name = "labelAverageValuee";
            labelAverageValuee.Size = new Size(24, 15);
            labelAverageValuee.TabIndex = 6;
            labelAverageValuee.Text = "[   ]";
            labelAverageValuee.Click += labelAverageValuee_Click;
            // 
            // labelLowestGradeValue
            // 
            labelLowestGradeValue.AutoSize = true;
            labelLowestGradeValue.Location = new Point(115, 70);
            labelLowestGradeValue.Name = "labelLowestGradeValue";
            labelLowestGradeValue.Size = new Size(24, 15);
            labelLowestGradeValue.TabIndex = 8;
            labelLowestGradeValue.Text = "[   ]";
            // 
            // UC_Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelLowestGradeValue);
            Controls.Add(labelLowestGradeTitle);
            Controls.Add(labelAverageValuee);
            Controls.Add(labelHighestGradeValue);
            Controls.Add(labelHighestGradeTitle);
            Controls.Add(labelAverageValue);
            Controls.Add(labelAverageTitle);
            Controls.Add(dgvMataKuliah);
            Name = "UC_Dashboard";
            Size = new Size(653, 453);
            Load += UC_Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMataKuliah).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMataKuliah;
        private Label labelAverageTitle;
        private Label labelAverageValue;
        private Label labelHighestGradeTitle;
        private Label labelHighestGradeValue;
        private Label labelAverageValuee;
        private Label labelLowestGradeValue;
    }
}
