﻿namespace GradeApp
{
    partial class UC_Grade
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
            labelMataKuliah = new Label();
            dgvMataKuliah = new DataGridView();
            comboBoxMataKuliah = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvMataKuliah).BeginInit();
            SuspendLayout();
            // 
            // labelNama
            // 
            labelNama.AutoSize = true;
            labelNama.Location = new Point(35, 20);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(39, 15);
            labelNama.TabIndex = 0;
            labelNama.Text = "Nama";
            // 
            // labelNIM
            // 
            labelNIM.AutoSize = true;
            labelNIM.Location = new Point(44, 49);
            labelNIM.Name = "labelNIM";
            labelNIM.Size = new Size(30, 15);
            labelNIM.TabIndex = 1;
            labelNIM.Text = "NIM";
            // 
            // labelNilai
            // 
            labelNilai.AutoSize = true;
            labelNilai.Location = new Point(43, 78);
            labelNilai.Name = "labelNilai";
            labelNilai.Size = new Size(31, 15);
            labelNilai.TabIndex = 2;
            labelNilai.Text = "Nilai";
            // 
            // textBoxNama
            // 
            textBoxNama.Location = new Point(80, 12);
            textBoxNama.Name = "textBoxNama";
            textBoxNama.Size = new Size(156, 23);
            textBoxNama.TabIndex = 3;
            // 
            // textBoxNIM
            // 
            textBoxNIM.Location = new Point(80, 41);
            textBoxNIM.Name = "textBoxNIM";
            textBoxNIM.Size = new Size(156, 23);
            textBoxNIM.TabIndex = 4;
            // 
            // textBoxNilai
            // 
            textBoxNilai.Location = new Point(80, 70);
            textBoxNilai.Name = "textBoxNilai";
            textBoxNilai.Size = new Size(156, 23);
            textBoxNilai.TabIndex = 5;
            // 
            // buttonSimpan
            // 
            buttonSimpan.Location = new Point(80, 134);
            buttonSimpan.Name = "buttonSimpan";
            buttonSimpan.Size = new Size(60, 23);
            buttonSimpan.TabIndex = 6;
            buttonSimpan.Text = "Simpan";
            buttonSimpan.UseVisualStyleBackColor = true;
            buttonSimpan.Click += buttonSimpan_Click;
            // 
            // buttonHapus
            // 
            buttonHapus.Location = new Point(176, 134);
            buttonHapus.Name = "buttonHapus";
            buttonHapus.Size = new Size(60, 23);
            buttonHapus.TabIndex = 7;
            buttonHapus.Text = "Hapus";
            buttonHapus.UseVisualStyleBackColor = true;
            buttonHapus.Click += buttonHapus_Click;
            // 
            // labelMataKuliah
            // 
            labelMataKuliah.AutoSize = true;
            labelMataKuliah.Location = new Point(4, 107);
            labelMataKuliah.Name = "labelMataKuliah";
            labelMataKuliah.Size = new Size(70, 15);
            labelMataKuliah.TabIndex = 9;
            labelMataKuliah.Text = "Mata Kuliah";
            // 
            // dgvMataKuliah
            // 
            dgvMataKuliah.AllowUserToAddRows = false;
            dgvMataKuliah.AllowUserToDeleteRows = false;
            dgvMataKuliah.AllowUserToResizeColumns = false;
            dgvMataKuliah.AllowUserToResizeRows = false;
            dgvMataKuliah.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMataKuliah.Location = new Point(2, 162);
            dgvMataKuliah.Margin = new Padding(2);
            dgvMataKuliah.Name = "dgvMataKuliah";
            dgvMataKuliah.Size = new Size(643, 277);
            dgvMataKuliah.TabIndex = 11;
            dgvMataKuliah.CellContentClick += dgvMataKuliah_CellContentClick;
            // 
            // comboBoxMataKuliah
            // 
            comboBoxMataKuliah.FormattingEnabled = true;
            comboBoxMataKuliah.Location = new Point(80, 99);
            comboBoxMataKuliah.Name = "comboBoxMataKuliah";
            comboBoxMataKuliah.Size = new Size(156, 23);
            comboBoxMataKuliah.TabIndex = 12;
            comboBoxMataKuliah.SelectedIndexChanged += comboBoxMataKuliah_SelectedIndexChanged;
            // 
            // UC_Grade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBoxMataKuliah);
            Controls.Add(dgvMataKuliah);
            Controls.Add(labelMataKuliah);
            Controls.Add(buttonHapus);
            Controls.Add(buttonSimpan);
            Controls.Add(textBoxNilai);
            Controls.Add(textBoxNIM);
            Controls.Add(textBoxNama);
            Controls.Add(labelNilai);
            Controls.Add(labelNIM);
            Controls.Add(labelNama);
            Name = "UC_Grade";
            Size = new Size(648, 450);
            Load += UC_Manage_Load;
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
        private Label labelMataKuliah;
        private DataGridView dgvMataKuliah;
        private ComboBox comboBoxMataKuliah;
    }
}
