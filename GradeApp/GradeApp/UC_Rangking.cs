using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeApp
{
    public partial class UC_Rangking : UserControl
    {
        public UC_Rangking()
        {
            InitializeComponent();
            dgvMataKuliah.AllowUserToResizeRows = false;
            dgvMataKuliah.AllowUserToOrderColumns = false;
            this.Load += UC_Rangking_Load;
        }

        private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();

        private void UC_Rangking_Load(object sender, EventArgs e)
        {
            LoadData();
            TampilkanSemuaNilai();
            AturDataGridView();
        }

        private void LoadData()
        {
            daftarMahasiswa = MahasiswaRepository.LoadData();
        }

        private void TampilkanSemuaNilai()
        {
            // Kalkulasi IPK untuk setiap mahasiswa pada skala 4 (0.00 - 4.00)
            var dataRangking = daftarMahasiswa
                .Where(m => m.DaftarNilai != null && m.DaftarNilai.Count > 0)
                .Select(m => new
                {
                    NIM = m.NIM,
                    NamaMahasiswa = m.Nama,
                    IPK = Math.Round(m.DaftarNilai.Average(x => x.Nilai) / 100 * 4, 2) // IPK skala 4, 2 digit desimal
                })
                .OrderByDescending(m => m.IPK)
                .ToList();

            dgvMataKuliah.DataSource = null;
            dgvMataKuliah.DataSource = dataRangking;

            // Ganti header kolom jika perlu
            if (dgvMataKuliah.Columns["IPK"] != null)
                dgvMataKuliah.Columns["IPK"].HeaderText = "IPK";

            // Pastikan semua kolom dapat di-sort (opsional, untuk jaga-jaga)
            foreach (DataGridViewColumn column in dgvMataKuliah.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void AturDataGridView()
        {
            dgvMataKuliah.AutoGenerateColumns = true;
            dgvMataKuliah.ReadOnly = true;
            dgvMataKuliah.AllowUserToAddRows = false;
            dgvMataKuliah.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMataKuliah.RowHeadersVisible = false;
            dgvMataKuliah.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMataKuliah.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvMataKuliah_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kosong, bisa diisi sesuai kebutuhan
        }
    }
}