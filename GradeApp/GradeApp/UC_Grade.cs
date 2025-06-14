using Newtonsoft.Json;
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
    public partial class UC_Grade : UserControl
    {
        private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();
        private Mahasiswa mahasiswaSaatIni;

        public UC_Grade()
        {
            InitializeComponent();

            dgvMataKuliah.AutoGenerateColumns = true;
            dgvMataKuliah.ReadOnly = true;
            dgvMataKuliah.AllowUserToAddRows = false;
            dgvMataKuliah.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMataKuliah.RowHeadersVisible = false;
            dgvMataKuliah.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMataKuliah.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            comboBoxMataKuliah.DropDownStyle = ComboBoxStyle.DropDownList;
            SetUkuranKolom();
            LoadData();
            LoadMataKuliah();
        }

        private void SetUkuranKolom()
        {
            if (dgvMataKuliah.Columns.Contains("NamaMK"))
                dgvMataKuliah.Columns["NamaMK"].Width = 150;

            if (dgvMataKuliah.Columns.Contains("Nilai"))
                dgvMataKuliah.Columns["Nilai"].Width = 80;
        }

        private void LoadData()
        {
            daftarMahasiswa = MahasiswaRepository.LoadData();
        }

        private void LoadMataKuliah()
        {
            comboBoxMataKuliah.Items.Clear();
            var semuaMK = MataKuliahRepository.Load();
            foreach (var mk in semuaMK)
            {
                comboBoxMataKuliah.Items.Add(mk.NamaMataKuliah);
            }

            if (comboBoxMataKuliah.Items.Count > 0)
                comboBoxMataKuliah.SelectedIndex = 0;
        }

        private void ResetForm()
        {
            textBoxNama.Clear();
            textBoxNIM.Clear();
            textBoxNilai.Clear();
            if (comboBoxMataKuliah.Items.Count > 0)
                comboBoxMataKuliah.SelectedIndex = 0;
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

                var semuaNilai = new List<dynamic>();

                foreach (var mhs in daftarMahasiswa)
                {
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
            }

            textBoxNIM.Clear();
            textBoxNama.Clear();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNIM.Text) || string.IsNullOrWhiteSpace(textBoxNama.Text))
            {
                MessageBox.Show("NIM dan Nama harus diisi!");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxNama.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama hanya boleh berisi huruf");
                return;
            }

            if (comboBoxMataKuliah.SelectedItem == null)
            {
                MessageBox.Show("Pilih mata kuliah dari daftar!");
                return;
            }

            if (!double.TryParse(textBoxNilai.Text, out double nilai))
            {
                MessageBox.Show("Nilai harus berupa angka!");
                return;
            }

            string nim = textBoxNIM.Text.Trim();
            string nama = textBoxNama.Text.Trim();
            string namaMK = comboBoxMataKuliah.SelectedItem.ToString();

            // Cek jika NIM sudah ada, maka nama harus sama
            var existingMahasiswa = daftarMahasiswa.FirstOrDefault(m => m.NIM == nim);
            if (existingMahasiswa != null && !string.Equals(existingMahasiswa.Nama, nama, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"NIM {nim} sudah terdaftar untuk nama \"{existingMahasiswa.Nama}\".\nPeriksa kembali input anda.");
                return;
            }

            // Cek duplikat NIM + Nama + Mata Kuliah
            bool sudahAda = daftarMahasiswa.Any(m =>
                m.NIM == nim &&
                m.Nama == nama &&
                m.DaftarNilai.Any(n => n.NamaMK == namaMK));

            if (sudahAda)
            {
                MessageBox.Show("Data dengan NIM, Nama, dan Mata Kuliah tersebut sudah ada!");
                return;
            }

            var daftarMK = new List<MataKuliah>
            {
                new MataKuliah
                {
                    NamaMK = namaMK,
                    Nilai = nilai
                }
            };

            var mhs = new Mahasiswa
            {
                NIM = nim,
                Nama = nama,
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
             if (dgvMataKuliah.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus!");
                return;
            }

            var result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            var selectedRow = dgvMataKuliah.SelectedRows[0];
            string nim = selectedRow.Cells["NIM"].Value?.ToString()?.Trim();
            string namaMK = selectedRow.Cells["NamaMK"].Value?.ToString()?.Trim();

            if (string.IsNullOrEmpty(nim) || string.IsNullOrEmpty(namaMK))
            {
                MessageBox.Show("Data tidak valid untuk dihapus.");
                return;
            }

            var mahasiswa = daftarMahasiswa.FirstOrDefault(m => m.NIM.Trim() == nim);
            if (mahasiswa != null)
            {
                var mkToRemove = mahasiswa.DaftarNilai
                    .FirstOrDefault(mk => string.Equals(mk.NamaMK?.Trim(), namaMK, StringComparison.OrdinalIgnoreCase));

                if (mkToRemove != null)
                {
                    mahasiswa.DaftarNilai.Remove(mkToRemove);

                    // Jika tidak ada mata kuliah lagi, hapus mahasiswa
                    if (!mahasiswa.DaftarNilai.Any())
                    {
                        daftarMahasiswa.Remove(mahasiswa);
                    }

                    MahasiswaRepository.SaveAll(daftarMahasiswa);
                    LoadData();
                    RefreshDataGrid();

                    MessageBox.Show("Data berhasil dihapus.");
                }
                else
                {
                    MessageBox.Show("Mata kuliah tidak ditemukan untuk mahasiswa ini.");
                }
            }
            else
            {
                MessageBox.Show("Mahasiswa tidak ditemukan.");
            }
        }

        private void RefreshDataGrid()
        {
            var semuaNilai = daftarMahasiswa.SelectMany(m => m.DaftarNilai.Select(mk => new
            {
                NIM = m.NIM,
                NamaMahasiswa = m.Nama,
                NamaMK = mk.NamaMK,
                Nilai = mk.Nilai
            })).ToList();

            dgvMataKuliah.DataSource = null;
            dgvMataKuliah.DataSource = semuaNilai;
        }




        private void dgvMahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dgvMataKuliah_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void comboBoxMataKuliah_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
