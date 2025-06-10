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
        public UC_Manage()
        {
            InitializeComponent();
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
            dgvMahasiswa.DataSource = null;
            dgvMahasiswa.DataSource = MahasiswaRepository.LoadData();
            ResetForm();
        }

        private void ResetForm()
        {
            textBoxNama.Clear();
            textBoxNIM.Clear();
            textBoxNilai.Clear();
        }

        private void UC_Manage_Load(object sender, EventArgs e)
        {

        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNIM.Text) || string.IsNullOrEmpty(textBoxNama.Text))
            {
                MessageBox.Show("NIM dan Nama harus diisi!");
                return;
            }

            if (!double.TryParse(textBoxNilai.Text, out double nilai))
            {
                MessageBox.Show("Nilai harus angka!");
                return;
            }

            var mhs = new Mahasiswa
            {
                NIM = textBoxNIM.Text,
                Nama = textBoxNama.Text,
                Nilai = nilai
            };

            MahasiswaRepository.Add(mhs);
            LoadData();

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

        }
    }
}
