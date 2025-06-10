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
    public partial class UC_Manage : UserControl
    {

        private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();
        private Mahasiswa mahasiswaSaatIni;

        public UC_Manage()
        {
            InitializeComponent();
            dgvMataKuliah.AutoGenerateColumns = true;
            LoadData();
        }

        private void dgvMahasiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMahasiswa.Rows[e.RowIndex];
                textBoxNIM.Text = row.Cells["NIM"].Value.ToString();
                textBoxNama.Text = row.Cells["Nama"].Value.ToString();
                textBoxNilai.Text = row.Cells["Nilai"].Value.ToString();
            }
        }

        private void LoadData()
        {
            daftarMahasiswa = MahasiswaRepository.LoadData();
            dgvMahasiswa.DataSource = null;
            dgvMahasiswa.DataSource = daftarMahasiswa;
        }

        private void ResetForm()
        {
            textBoxNama.Clear();
            textBoxNIM.Clear();
            textBoxNilai.Clear();
            textBoxMataKuliah.Clear();
            dgvMataKuliah.DataSource = null;
            mahasiswaSaatIni = null;
        }

        private void UC_Manage_Load(object sender, EventArgs e)
        {
            LoadData();

            if (daftarMahasiswa.Count > 0)
            {
                mahasiswaSaatIni = daftarMahasiswa[0];
                textBoxNIM.Text = mahasiswaSaatIni.NIM;
                textBoxNama.Text = mahasiswaSaatIni.Nama;

                dgvMataKuliah.DataSource = null;
                dgvMataKuliah.DataSource = mahasiswaSaatIni.DaftarNilai;
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNIM.Text) || string.IsNullOrEmpty(textBoxNama.Text))
            {
                MessageBox.Show("NIM dan Nama harus diisi!");
                return;
            }

            var daftarMK = new List<MataKuliah>();
            if (!string.IsNullOrEmpty(textBoxMataKuliah.Text) && double.TryParse(textBoxNilai.Text, out double nilai))
            {
                daftarMK.Add(new MataKuliah
                {
                    NamaMK = textBoxMataKuliah.Text,
                    Nilai = nilai
                });
            }

            var mhs = new Mahasiswa
            {
                NIM = textBoxNIM.Text,
                Nama = textBoxNama.Text,
                DaftarNilai = daftarMK
            };

            MahasiswaRepository.Add(mhs);
            LoadData();

            mahasiswaSaatIni = mhs;
            dgvMataKuliah.DataSource = null;
            dgvMataKuliah.DataSource = mahasiswaSaatIni.DaftarNilai;

            ResetForm();

        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            if (dgvMahasiswa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus.");
                return;
            }

            string nim = textBoxNIM.Text;
            MahasiswaRepository.Delete(nim);
            LoadData();
        }

        private void dgvMahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMahasiswa.Rows[e.RowIndex];
                string nim = row.Cells["NIM"].Value.ToString();

                mahasiswaSaatIni = daftarMahasiswa.FirstOrDefault(m => m.NIM == nim);

                if (mahasiswaSaatIni != null)
                {
                    textBoxNIM.Text = mahasiswaSaatIni.NIM;
                    textBoxNama.Text = mahasiswaSaatIni.Nama;

                    // Tampilkan daftar mata kuliah
                    dgvMataKuliah.DataSource = null;
                    dgvMataKuliah.DataSource = mahasiswaSaatIni.DaftarNilai;
                }
            }

        }
    }
}
