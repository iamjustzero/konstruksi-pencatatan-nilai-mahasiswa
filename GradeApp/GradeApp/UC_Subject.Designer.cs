﻿namespace GradeApp
{
    partial class UC_Subject
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
            labelNamaMataKuliah = new Label();
            textBoxMataKuliah = new TextBox();
            labelSKS = new Label();
            comboBoxSKS = new ComboBox();
            buttonSave = new Button();
            buttonClear = new Button();
            dgvMataKuliah = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMataKuliah).BeginInit();
            SuspendLayout();
            // 
            // labelNamaMataKuliah
            // 
            labelNamaMataKuliah.AutoSize = true;
            labelNamaMataKuliah.Location = new Point(14, 20);
            labelNamaMataKuliah.Margin = new Padding(2, 0, 2, 0);
            labelNamaMataKuliah.Name = "labelNamaMataKuliah";
            labelNamaMataKuliah.Size = new Size(70, 15);
            labelNamaMataKuliah.TabIndex = 0;
            labelNamaMataKuliah.Text = "Mata Kuliah";
            labelNamaMataKuliah.Click += labelNamaMataKuliah_Click;
            // 
            // textBoxMataKuliah
            // 
            textBoxMataKuliah.Location = new Point(106, 17);
            textBoxMataKuliah.Margin = new Padding(2);
            textBoxMataKuliah.Multiline = true;
            textBoxMataKuliah.Name = "textBoxMataKuliah";
            textBoxMataKuliah.Size = new Size(185, 25);
            textBoxMataKuliah.TabIndex = 1;
            textBoxMataKuliah.TextChanged += textBoxMataKuliah_TextChanged;
            // 
            // labelSKS
            // 
            labelSKS.AutoSize = true;
            labelSKS.Location = new Point(14, 46);
            labelSKS.Margin = new Padding(2, 0, 2, 0);
            labelSKS.Name = "labelSKS";
            labelSKS.Size = new Size(26, 15);
            labelSKS.TabIndex = 2;
            labelSKS.Text = "SKS";
            labelSKS.Click += labelSKS_Click;
            // 
            // comboBoxSKS
            // 
            comboBoxSKS.FormattingEnabled = true;
            comboBoxSKS.Location = new Point(106, 46);
            comboBoxSKS.Margin = new Padding(2);
            comboBoxSKS.Name = "comboBoxSKS";
            comboBoxSKS.Size = new Size(48, 23);
            comboBoxSKS.TabIndex = 3;
            comboBoxSKS.SelectedIndexChanged += comboBoxSKS_SelectedIndexChanged;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(14, 73);
            buttonSave.Margin = new Padding(2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(78, 31);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSimpan_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(106, 73);
            buttonClear.Margin = new Padding(2);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(78, 31);
            buttonClear.TabIndex = 6;
            buttonClear.Text = "Delete";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // dgvMataKuliah
            // 
            dgvMataKuliah.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMataKuliah.Location = new Point(2, 108);
            dgvMataKuliah.Margin = new Padding(2);
            dgvMataKuliah.Name = "dgvMataKuliah";
            dgvMataKuliah.RowHeadersWidth = 62;
            dgvMataKuliah.Size = new Size(647, 340);
            dgvMataKuliah.TabIndex = 7;
            dgvMataKuliah.CellContentClick += dgvMataKuliah_CellContentClick;
            // 
            // UC_Subject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvMataKuliah);
            Controls.Add(buttonClear);
            Controls.Add(buttonSave);
            Controls.Add(comboBoxSKS);
            Controls.Add(labelSKS);
            Controls.Add(textBoxMataKuliah);
            Controls.Add(labelNamaMataKuliah);
            Margin = new Padding(2);
            Name = "UC_Subject";
            Size = new Size(651, 450);
            ((System.ComponentModel.ISupportInitialize)dgvMataKuliah).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNamaMataKuliah;
        private TextBox textBoxMataKuliah;
        private Label labelSKS;
        private ComboBox comboBoxSKS;
        private Button buttonSave;
        private Button buttonClear;
        private DataGridView dgvMataKuliah;
    }
}
