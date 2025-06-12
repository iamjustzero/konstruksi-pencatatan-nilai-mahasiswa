namespace GradeApp
{
    partial class UC_Manage
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
            labelNama = new Label();
            labelNIM = new Label();
            labelNilai = new Label();
            textBoxNama = new TextBox();
            textBoxNIM = new TextBox();
            textBoxNilai = new TextBox();
            buttonSimpan = new Button();
            buttonHapus = new Button();
            dgvMahasiswa = new DataGridView();
            labelMataKuliah = new Label();
            textBoxMataKuliah = new TextBox();
            dgvMataKuliah = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMahasiswa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMataKuliah).BeginInit();
            SuspendLayout();
            // 
            // labelNama
            // 
            labelNama.AutoSize = true;
            labelNama.Location = new Point(50, 33);
            labelNama.Margin = new Padding(4, 0, 4, 0);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(59, 25);
            labelNama.TabIndex = 0;
            labelNama.Text = "Nama";
            // 
            // labelNIM
            // 
            labelNIM.AutoSize = true;
            labelNIM.Location = new Point(63, 82);
            labelNIM.Margin = new Padding(4, 0, 4, 0);
            labelNIM.Name = "labelNIM";
            labelNIM.Size = new Size(46, 25);
            labelNIM.TabIndex = 1;
            labelNIM.Text = "NIM";
            // 
            // labelNilai
            // 
            labelNilai.AutoSize = true;
            labelNilai.Location = new Point(61, 130);
            labelNilai.Margin = new Padding(4, 0, 4, 0);
            labelNilai.Name = "labelNilai";
            labelNilai.Size = new Size(46, 25);
            labelNilai.TabIndex = 2;
            labelNilai.Text = "Nilai";
            // 
            // textBoxNama
            // 
            textBoxNama.Location = new Point(114, 20);
            textBoxNama.Margin = new Padding(4, 5, 4, 5);
            textBoxNama.Name = "textBoxNama";
            textBoxNama.Size = new Size(221, 31);
            textBoxNama.TabIndex = 3;
            // 
            // textBoxNIM
            // 
            textBoxNIM.Location = new Point(114, 68);
            textBoxNIM.Margin = new Padding(4, 5, 4, 5);
            textBoxNIM.Name = "textBoxNIM";
            textBoxNIM.Size = new Size(221, 31);
            textBoxNIM.TabIndex = 4;
            // 
            // textBoxNilai
            // 
            textBoxNilai.Location = new Point(114, 117);
            textBoxNilai.Margin = new Padding(4, 5, 4, 5);
            textBoxNilai.Name = "textBoxNilai";
            textBoxNilai.Size = new Size(221, 31);
            textBoxNilai.TabIndex = 5;
            // 
            // buttonSimpan
            // 
            buttonSimpan.Location = new Point(114, 223);
            buttonSimpan.Margin = new Padding(4, 5, 4, 5);
            buttonSimpan.Name = "buttonSimpan";
            buttonSimpan.Size = new Size(86, 38);
            buttonSimpan.TabIndex = 6;
            buttonSimpan.Text = "Simpan";
            buttonSimpan.UseVisualStyleBackColor = true;
            buttonSimpan.Click += buttonSimpan_Click;
            // 
            // buttonHapus
            // 
            buttonHapus.Location = new Point(251, 223);
            buttonHapus.Margin = new Padding(4, 5, 4, 5);
            buttonHapus.Name = "buttonHapus";
            buttonHapus.Size = new Size(86, 38);
            buttonHapus.TabIndex = 7;
            buttonHapus.Text = "Hapus";
            buttonHapus.UseVisualStyleBackColor = true;
            buttonHapus.Click += buttonHapus_Click;
            // 
            // dgvMahasiswa
            // 
            dgvMahasiswa.AllowUserToAddRows = false;
            dgvMahasiswa.AllowUserToDeleteRows = false;
            dgvMahasiswa.AllowUserToResizeColumns = false;
            dgvMahasiswa.AllowUserToResizeRows = false;
            dgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMahasiswa.Location = new Point(13, 272);
            dgvMahasiswa.Margin = new Padding(4, 5, 4, 5);
            dgvMahasiswa.Name = "dgvMahasiswa";
            dgvMahasiswa.RowHeadersWidth = 62;
            dgvMahasiswa.Size = new Size(511, 250);
            dgvMahasiswa.TabIndex = 8;
            dgvMahasiswa.CellContentClick += dgvMahasiswa_CellContentClick;
            // 
            // labelMataKuliah
            // 
            labelMataKuliah.AutoSize = true;
            labelMataKuliah.Location = new Point(6, 178);
            labelMataKuliah.Margin = new Padding(4, 0, 4, 0);
            labelMataKuliah.Name = "labelMataKuliah";
            labelMataKuliah.Size = new Size(104, 25);
            labelMataKuliah.TabIndex = 9;
            labelMataKuliah.Text = "Mata Kuliah";
            // 
            // textBoxMataKuliah
            // 
            textBoxMataKuliah.Location = new Point(114, 165);
            textBoxMataKuliah.Margin = new Padding(4, 5, 4, 5);
            textBoxMataKuliah.Name = "textBoxMataKuliah";
            textBoxMataKuliah.Size = new Size(221, 31);
            textBoxMataKuliah.TabIndex = 10;
            // 
            // dgvMataKuliah
            // 
            dgvMataKuliah.AllowUserToAddRows = false;
            dgvMataKuliah.AllowUserToDeleteRows = false;
            dgvMataKuliah.AllowUserToResizeColumns = false;
            dgvMataKuliah.AllowUserToResizeRows = false;
            dgvMataKuliah.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMataKuliah.Location = new Point(13, 532);
            dgvMataKuliah.Margin = new Padding(4, 5, 4, 5);
            dgvMataKuliah.Name = "dgvMataKuliah";
            dgvMataKuliah.RowHeadersWidth = 62;
            dgvMataKuliah.Size = new Size(511, 250);
            dgvMataKuliah.TabIndex = 11;
            // 
            // UC_Manage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvMataKuliah);
            Controls.Add(textBoxMataKuliah);
            Controls.Add(labelMataKuliah);
            Controls.Add(dgvMahasiswa);
            Controls.Add(buttonHapus);
            Controls.Add(buttonSimpan);
            Controls.Add(textBoxNilai);
            Controls.Add(textBoxNIM);
            Controls.Add(textBoxNama);
            Controls.Add(labelNilai);
            Controls.Add(labelNIM);
            Controls.Add(labelNama);
            Margin = new Padding(4, 5, 4, 5);
            Name = "UC_Manage";
            Size = new Size(1277, 928);
            Load += UC_Manage_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMahasiswa).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMataKuliah).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelNama;
        private Label labelNIM;
        private Label labelNilai;
        private TextBox textBoxNama;
        private TextBox textBoxNIM;
        private TextBox textBoxNilai;
        private Button button1;
        private Button button2;
        private Button buttonSimpan;
        private Button buttonHapus;
        private DataGridView dgvMahasiswa;
        private Label labelMataKuliah;
        private TextBox textBoxMataKuliah;
        private DataGridView dgvMataKuliah;
    }
}
