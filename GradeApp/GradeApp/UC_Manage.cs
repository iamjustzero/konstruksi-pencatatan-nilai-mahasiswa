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
            dgvMataKuliah.ReadOnly = true;
            dgvMataKuliah.AllowUserToAddRows = false;
            dgvMataKuliah.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMataKuliah.RowHeadersVisible = false;
            dgvMataKuliah.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetUkuranKolom();
            LoadData();
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
            //if (dgvMahasiswa.SelectedRows.Count == 0)
            //{
            //    MessageBox.Show("Pilih data yang ingin dihapus.");
            //    return;
            //}

            //string nim = textBoxNIM.Text;
            //MahasiswaRepository.Delete(nim);
            //LoadData();
        }

        private void dgvMahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgvMataKuliah_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
