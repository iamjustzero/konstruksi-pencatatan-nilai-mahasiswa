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
            dgvMataKuliah = new DataGridView();
            labelAverageTitle = new Label();
            labelAverageValue = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMataKuliah).BeginInit();
            SuspendLayout();
            // 
            // dgvMataKuliah
            // 
            dgvMataKuliah.Location = new Point(13, 110);
            dgvMataKuliah.Name = "dgvMataKuliah";
            dgvMataKuliah.Size = new Size(611, 324);
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
            // 
            // labelAverageValue
            // 
            labelAverageValue.AutoSize = true;
            labelAverageValue.Location = new Point(103, 19);
            labelAverageValue.Name = "labelAverageValue";
            labelAverageValue.Size = new Size(0, 15);
            labelAverageValue.TabIndex = 2;
            // 
            // UC_Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelAverageValue);
            Controls.Add(labelAverageTitle);
            Controls.Add(dgvMataKuliah);
            Name = "UC_Dashboard";
            Size = new Size(644, 455);
            Load += UC_Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMataKuliah).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMataKuliah;
        private Label labelAverageTitle;
        private Label labelAverageValue;
    }
}
