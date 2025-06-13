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
        private Mahasiswa mahasiswaSaatIni;

        public UC_Dashboard()
        {
            InitializeComponent();

            dgvMataKuliah.AutoGenerateColumns = true;
            dgvMataKuliah.ReadOnly = true;
            dgvMataKuliah.Enabled = true;
            dgvMataKuliah.AllowUserToAddRows = false;
            dgvMataKuliah.AllowUserToResizeColumns = false;
            dgvMataKuliah.AllowUserToResizeRows = false;
            dgvMataKuliah.AllowUserToOrderColumns = false;
            dgvMataKuliah.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvMataKuliah.MultiSelect = false;
            dgvMataKuliah.ClearSelection();
            dgvMataKuliah.RowHeadersVisible = false;
            dgvMataKuliah.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMataKuliah.DefaultCellStyle.SelectionBackColor = dgvMataKuliah.DefaultCellStyle.BackColor;
            dgvMataKuliah.DefaultCellStyle.SelectionForeColor = dgvMataKuliah.DefaultCellStyle.ForeColor;

            dgvMataKuliah.Enabled = false; 

            SetUkuranKolom();
            LoadData();
        }


        private void SetUkuranKolom()
        {
            if (dgvMataKuliah.Columns.Contains("NamaMK"))
                dgvMataKuliah.Columns["NamaMK"].Width = 150;

            if (dgvMataKuliah.Columns.Contains("Nilai"))
                dgvMataKuliah.Columns["Nilai"].Width = 80;

            if (dgvMataKuliah.Columns.Contains("NIM"))
                dgvMataKuliah.Columns["NIM"].Width = 100;
        }

        private void LoadData()
        {
            daftarMahasiswa = MahasiswaRepository.LoadData();

            var semuaNilai = new List<dynamic>();

            foreach (var mhs in daftarMahasiswa)
            {
                foreach (var mk in mhs.DaftarNilai)
                {
                    semuaNilai.Add(new
                    {
                        NIM = mhs.NIM,
                        NamaMK = mk.NamaMK,
                        Nilai = mk.Nilai
                    });
                }
            }

            dgvMataKuliah.DataSource = null;
            dgvMataKuliah.DataSource = semuaNilai;
        }

        private void dgvMataKuliah_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}