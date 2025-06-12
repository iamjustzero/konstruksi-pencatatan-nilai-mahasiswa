namespace GradeApp
{
    partial class UC_MataKuliah
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
            buttonSimpan = new Button();
            buttonClear = new Button();
            dgvMataKuliah = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMataKuliah).BeginInit();
            SuspendLayout();
            // 
            // labelNamaMataKuliah
            // 
            labelNamaMataKuliah.AutoSize = true;
            labelNamaMataKuliah.Location = new Point(305, 42);
            labelNamaMataKuliah.Name = "labelNamaMataKuliah";
            labelNamaMataKuliah.Size = new Size(104, 25);
            labelNamaMataKuliah.TabIndex = 0;
            labelNamaMataKuliah.Text = "Mata Kuliah";
            labelNamaMataKuliah.Click += labelNamaMataKuliah_Click;
            // 
            // textBoxMataKuliah
            // 
            textBoxMataKuliah.Location = new Point(437, 39);
            textBoxMataKuliah.Multiline = true;
            textBoxMataKuliah.Name = "textBoxMataKuliah";
            textBoxMataKuliah.Size = new Size(263, 39);
            textBoxMataKuliah.TabIndex = 1;
            textBoxMataKuliah.TextChanged += textBoxMataKuliah_TextChanged;
            // 
            // labelSKS
            // 
            labelSKS.AutoSize = true;
            labelSKS.Location = new Point(305, 107);
            labelSKS.Name = "labelSKS";
            labelSKS.Size = new Size(42, 25);
            labelSKS.TabIndex = 2;
            labelSKS.Text = "SKS";
            labelSKS.Click += labelSKS_Click;
            // 
            // comboBoxSKS
            // 
            comboBoxSKS.FormattingEnabled = true;
            comboBoxSKS.Location = new Point(437, 104);
            comboBoxSKS.Name = "comboBoxSKS";
            comboBoxSKS.Size = new Size(119, 33);
            comboBoxSKS.TabIndex = 3;
            comboBoxSKS.SelectedIndexChanged += comboBoxSKS_SelectedIndexChanged;
            // 
            // buttonSimpan
            // 
            buttonSimpan.Location = new Point(305, 168);
            buttonSimpan.Name = "buttonSimpan";
            buttonSimpan.Size = new Size(112, 34);
            buttonSimpan.TabIndex = 5;
            buttonSimpan.Text = "Simpan";
            buttonSimpan.UseVisualStyleBackColor = true;
            buttonSimpan.Click += buttonSimpan_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(453, 168);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(112, 34);
            buttonClear.TabIndex = 6;
            buttonClear.Text = "Reset";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // dgvMataKuliah
            // 
            dgvMataKuliah.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMataKuliah.Location = new Point(307, 244);
            dgvMataKuliah.Name = "dgvMataKuliah";
            dgvMataKuliah.RowHeadersWidth = 62;
            dgvMataKuliah.Size = new Size(360, 225);
            dgvMataKuliah.TabIndex = 7;
            dgvMataKuliah.CellContentClick += dgvMataKuliah_CellContentClick;
            // 
            // UC_MataKuliah
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvMataKuliah);
            Controls.Add(buttonClear);
            Controls.Add(buttonSimpan);
            Controls.Add(comboBoxSKS);
            Controls.Add(labelSKS);
            Controls.Add(textBoxMataKuliah);
            Controls.Add(labelNamaMataKuliah);
            Name = "UC_MataKuliah";
            Size = new Size(953, 511);
            ((System.ComponentModel.ISupportInitialize)dgvMataKuliah).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNamaMataKuliah;
        private TextBox textBoxMataKuliah;
        private Label labelSKS;
        private ComboBox comboBoxSKS;
        private Button buttonSimpan;
        private Button buttonClear;
        private DataGridView dgvMataKuliah;
    }
}
