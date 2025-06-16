using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GradeApp
{
    public partial class UC_Counter : UserControl
    {
        // Deklarasi komponen UI
        private DataGridView dgvMahasiswa;
        private DataGridView dgvNilaiDetail;

        private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();

        public UC_Counter()
        {
            InitializeComponent();
            LoadData();
            DisplayMahasiswaList();
        }

        private void LoadData()
        {
            daftarMahasiswa = MahasiswaRepository.LoadData();
        }

        private void DisplayMahasiswaList()
        {
            var dataTampil = daftarMahasiswa
                .Where(m => m.DaftarNilai != null && m.DaftarNilai.Count > 0)
                .Select(m => new
                {
                    m.NIM,
                    m.Nama,
                    IPK = Math.Round(m.DaftarNilai.Average(n => n.Nilai) / 100 * 4, 2)
                })
                .OrderByDescending(x => x.IPK)
                .ToList();

            dgvMahasiswa.DataSource = dataTampil;
            dgvMahasiswa.CellClick += DgvMahasiswa_CellClick;
        }

        private void DisplayNilaiDetail(Mahasiswa mhs)
        {
            var nilaiDetail = mhs.DaftarNilai
                .Select(n => new
                {
                    MataKuliah = n.Nama_MK,
                    Nilai = n.Nilai
                })
                .ToList();

            dgvNilaiDetail.DataSource = nilaiDetail;
        }

        private void DgvMahasiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nim = dgvMahasiswa.Rows[e.RowIndex].Cells["NIM"].Value?.ToString();
                var mhs = daftarMahasiswa.FirstOrDefault(m => m.NIM == nim);

                if (mhs != null)
                {
                    DisplayNilaiDetail(mhs);
                }
            }
        }

        private void UC_Counter_Load(object sender, EventArgs e)
        {
            // Optional: reload data jika diperlukan
        }
    }
}