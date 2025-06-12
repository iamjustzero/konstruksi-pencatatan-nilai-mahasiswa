using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GradeApp
{
    public partial class UC_Dashboard : UserControl
    {
        private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();

        public UC_Dashboard()
        {
            InitializeComponent();

            if (dgvMataKuliah != null)
            {
                dgvMataKuliah.AutoGenerateColumns = false;
                dgvMataKuliah.RowHeadersVisible = false;

                SetupColumns(dgvMataKuliah);
                //adada
                LoadData();
            }
        }

        private void SetupColumns(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();

            var colNIM = new DataGridViewTextBoxColumn();
            colNIM.Name = "NIM";
            colNIM.HeaderText = "NIM Mahasiswa";
            colNIM.Width = 80;
            colNIM.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNIM.DefaultCellStyle.Font = new Font("Arial", 9); // Atur font
            dataGridView.Columns.Add(colNIM);

            var colNamaMahasiswa = new DataGridViewTextBoxColumn();
            colNamaMahasiswa.Name = "NamaMahasiswa";
            colNamaMahasiswa.HeaderText = "Nama Mahasiswa";
            colNamaMahasiswa.Width = 150;
            colNamaMahasiswa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colNamaMahasiswa.DefaultCellStyle.Font = new Font("Arial", 9); // Atur font
            dataGridView.Columns.Add(colNamaMahasiswa);

            var colNamaMK = new DataGridViewTextBoxColumn();
            colNamaMK.Name = "NamaMK";
            colNamaMK.HeaderText = "Nama Mata Kuliah";
            colNamaMK.Width = 150;
            colNamaMK.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colNamaMK.DefaultCellStyle.Font = new Font("Arial", 9); // Atur font
            dataGridView.Columns.Add(colNamaMK);

            var colNilai = new DataGridViewTextBoxColumn();
            colNilai.Name = "Nilai";
            colNilai.HeaderText = "Nilai";
            colNilai.Width = 80;
            colNilai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colNilai.DefaultCellStyle.Font = new Font("Arial", 9); // Atur font
            dataGridView.Columns.Add(colNilai);
        }

        private void LoadData()
        {
            daftarMahasiswa = MahasiswaRepository.LoadData();

            var semuaNilai = new List<dynamic>();

            Console.WriteLine($"Jumlah mahasiswa: {daftarMahasiswa.Count}");

            foreach (var mhs in daftarMahasiswa)
            {
                Console.WriteLine($"Mahasiswa: {mhs.Nama} - {mhs.DaftarNilai.Count} mata kuliah");

                foreach (var mk in mhs.DaftarNilai)
                {
                    semuaNilai.Add(new
                    {
                        NIM = mhs.NIM,
                        NamaMahasiswa = mhs.Nama,
                        NamaMK = mk.NamaMK,
                        Nilai = mk.Nilai
                    });
                }
            }

            dgvMataKuliah.DataSource = null;
            dgvMataKuliah.DataSource = semuaNilai;

            // Debug
            System.Diagnostics.Debug.WriteLine($"Total nilai: {semuaNilai.Count}");
            if (semuaNilai.Count == 0)
            {
                MessageBox.Show("Tidak ada data mata kuliah yang bisa ditampilkan.");
            }
        }
    }
}