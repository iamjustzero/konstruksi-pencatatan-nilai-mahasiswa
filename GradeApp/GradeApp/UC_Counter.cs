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
    public partial class UC_Counter : UserControl
    {
        private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();
        public UC_Counter()
        {
            InitializeComponent();
            dgvMataKuliah.AllowUserToResizeRows = false;
            dgvMataKuliah.AllowUserToOrderColumns = false;
            //dgvMataKuliah.CellClick += dgvMataKuliah_CellClick;
            this.Load += UC_Counter_Load;
        }

        private void UC_Counter_Load(object sender, EventArgs e)
        {
            LoadData();
            TampilkanSemuaNilai();
            AturDataGridView();
        }

        private void LoadData()
        {
            try
            {
                daftarMahasiswa = MahasiswaRepository.LoadData() ?? new List<Mahasiswa>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
                daftarMahasiswa = new List<Mahasiswa>();
            }
        }

        private void TampilkanSemuaNilai()
        {
            // Pastikan DaftarNilai tidak null untuk setiap mahasiswa
            var dataRangking = new List<dynamic>();

            foreach (var mhs in daftarMahasiswa)
            {
                if (mhs.DaftarNilai == null || mhs.DaftarNilai.Count == 0)
                {
                    continue; // Lewati jika tidak ada nilai
                }

                double ipk = Math.Round(mhs.DaftarNilai.Average(x => x.Nilai) / 25, 2); // Contoh skala 0–4

                dataRangking.Add(new
                {
                    NIM = mhs.NIM,
                    NamaMahasiswa = mhs.Nama,
                    IPK = ipk
                });
            }

            dgvMataKuliah.DataSource = null;
            dgvMataKuliah.DataSource = dataRangking;

            // Ganti header kolom jika perlu
            if (dgvMataKuliah.Columns.Contains("IPK"))
                dgvMataKuliah.Columns["IPK"].HeaderText = "IPK";

            // Aktifkan sorting via klik header
            foreach (DataGridViewColumn column in dgvMataKuliah.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void AturDataGridView()
        {
            dgvMataKuliah.AutoGenerateColumns = true;
            dgvMataKuliah.ReadOnly = true;
            dgvMataKuliah.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMataKuliah.RowHeadersVisible = false;
            dgvMataKuliah.AllowUserToAddRows = false;
            dgvMataKuliah.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMataKuliah.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }





        private void dgvMataKuliah_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
