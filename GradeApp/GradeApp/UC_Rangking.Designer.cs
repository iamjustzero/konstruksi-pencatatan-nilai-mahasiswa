namespace GradeApp
{
    partial class UC_Rangking
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
            dataGridViewMataKuliah = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMataKuliah).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMataKuliah
            // 
            dataGridViewMataKuliah.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMataKuliah.Location = new Point(3, 3);
            dataGridViewMataKuliah.Name = "dataGridViewMataKuliah";
            dataGridViewMataKuliah.Size = new Size(628, 443);
            dataGridViewMataKuliah.TabIndex = 0;
            // 
            // UC_Rangking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewMataKuliah);
            Name = "UC_Rangking";
            Size = new Size(635, 449);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMataKuliah).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewMataKuliah;
    }
}
