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

        }
    }
}
