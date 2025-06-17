using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GradeApp
{
    public partial class UC_Counter : UserControl
    {
        private static UC_Counter _instance;

        // Properti Singleton
        public static UC_Counter Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new UC_Counter();
                }
                return _instance;
            }
        }

        private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();
        private List<UC_Subject.Matkul> daftarMatkul = new List<UC_Subject.Matkul>();

        // Konstruktor private agar tidak bisa diakses dari luar
        private UC_Counter()
        {
            InitializeComponent();

            dgvMataKuliah.AllowUserToResizeRows = false;
            dgvMataKuliah.AllowUserToOrderColumns = false;
            dgvMataKuliah.CellClick += dgvMataKuliah_CellClick;
            this.Load += UC_Counter_Load;
        }

        private void UC_Counter_Load(object sender, EventArgs e)
        {
            LoadData();
            TampilkanSemuaNilai();
            AturDataGridView();
            daftarMatkul = LoadMatkulData();
        }

        private void LoadData()
        {
            try
            {
                daftarMahasiswa = MahasiswaRepository.LoadData() ?? new List<Mahasiswa>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data mahasiswa: " + ex.Message);
                daftarMahasiswa = new List<Mahasiswa>();
            }
        }

        private List<UC_Subject.Matkul> LoadMatkulData()
        {
            try
            {
                var data = MataKuliahRepository.Load();

                if (data == null)
                {
                    MessageBox.Show("Data mata kuliah bernilai null.");
                    return new List<UC_Subject.Matkul>();
                }

                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat data mata kuliah: " + ex.Message);
                return new List<UC_Subject.Matkul>();
            }
        }

        private void TampilkanSemuaNilai()
        {
            var dataRangking = new List<dynamic>();

            foreach (var mhs in daftarMahasiswa)
            {
                if (mhs.DaftarNilai == null || mhs.DaftarNilai.Count == 0)
                {
                    continue;
                }

                double ipk = Math.Round(mhs.DaftarNilai.Average(x => x.Nilai) / 25, 2);

                dataRangking.Add(new
                {
                    NIM = mhs.NIM,
                    NamaMahasiswa = mhs.Nama,
                    IPK = ipk
                });
            }

            dgvMataKuliah.DataSource = null;
            dgvMataKuliah.DataSource = dataRangking;

            if (dgvMataKuliah.Columns.Contains("IPK"))
                dgvMataKuliah.Columns["IPK"].HeaderText = "IPK";

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

        private void dgvMataKuliah_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMataKuliah.Rows[e.RowIndex];
                string nim = row.Cells["NIM"].Value.ToString();
                string nama = row.Cells["NamaMahasiswa"].Value.ToString();

                var mahasiswa = daftarMahasiswa.FirstOrDefault(m => m.NIM == nim);

                if (mahasiswa != null)
                {
                    StringBuilder detailText = new StringBuilder();

                    detailText.AppendLine($"Nama\t: {nama}");
                    detailText.AppendLine($"NIM\t: {nim}");

                    double totalSKS = 0;
                    foreach (var mk in mahasiswa.DaftarNilai)
                    {
                        var matkul = daftarMatkul.FirstOrDefault(m => m.NamaMataKuliah == mk.Nama_MK);
                        int sks = matkul?.SKS ?? 0;

                        detailText.AppendLine($"- {mk.Nama_MK} | Nilai: {mk.Nilai} | SKS: {sks}");
                        totalSKS += sks;
                    }

                    double ipk = 0;
                    if (totalSKS > 0 && mahasiswa.DaftarNilai.Count > 0)
                    {
                        ipk = Math.Round(mahasiswa.DaftarNilai.Average(x => x.Nilai) / 25, 2);
                    }

                    detailText.AppendLine($"\nTotal SKS\t: {totalSKS}");
                    detailText.AppendLine($"IPK\t: {ipk}");

                    MessageBox.Show(detailText.ToString(), "Detail Mahasiswa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvMataKuliah_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // kosong
        }
    }
}
