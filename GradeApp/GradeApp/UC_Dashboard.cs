using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GradeApp
{
    public partial class UC_Dashboard : UserControl
    {
        private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();

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

            var semuaNilai = daftarMahasiswa
                .SelectMany(m => m.DaftarNilai)
                .ToList();

            var dataGridSource = semuaNilai.Select(mk => new
            {
                NIM = daftarMahasiswa.First(m => m.DaftarNilai.Contains(mk)).NIM,
                NamaMK = mk.NamaMK,
                Nilai = mk.Nilai
            }).ToList();

            dgvMataKuliah.DataSource = null;
            dgvMataKuliah.DataSource = dataGridSource;

            
            if (semuaNilai.Count > 0)
            {
                double rataRata = semuaNilai.Average(mk => mk.Nilai);
                labelAverageValuee.Text = rataRata.ToString("0.00");

                double nilaiTertinggi = semuaNilai.Max(mk => mk.Nilai);
                labelHighestGradeValue.Text = nilaiTertinggi.ToString("0.00");

                double nilaiTerendah = semuaNilai.Min(mk => mk.Nilai);
                labelLowestGradeValue.Text = nilaiTerendah.ToString("0.00");

            }
            else
            {
                labelAverageValue.Text = "0.00";
                labelHighestGradeValue.Text = "0.00";
            }
        }


        private void dgvMataKuliah_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelAverageTitle_Click(object sender, EventArgs e)
        {

        }

        private void labelAverageValuee_Click(object sender, EventArgs e)
        {

        }
    }
}
