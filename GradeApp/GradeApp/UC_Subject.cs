using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeApp
{

    public partial class UC_Subject : UserControl
    {
        public class Matkul
        {
            public string NamaMataKuliah { get; set; }
            public int SKS { get; set; }
        }

        List<Matkul> listMataKuliah = new List<Matkul>();
        int selectedRow = -1;

        public UC_Subject()
        {
            InitializeComponent();

            dgvMataKuliah.RowHeadersVisible = false;
            dgvMataKuliah.ReadOnly = true;
            dgvMataKuliah.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMataKuliah.MultiSelect = false;
            dgvMataKuliah.AllowUserToResizeColumns = false;
            dgvMataKuliah.AllowUserToResizeRows = false;
            dgvMataKuliah.AllowUserToOrderColumns = false;
            dgvMataKuliah.AllowUserToAddRows = false;
            dgvMataKuliah.AllowUserToDeleteRows = false;
            dgvMataKuliah.ClearSelection();
            dgvMataKuliah.Enabled = false;
            this.Load += UC_MataKuliah_Load;
        }


        private void UC_MataKuliah_Load(object sender, EventArgs e)
        {
            comboBoxSKS.Items.Clear();
            comboBoxSKS.Items.Add("2");
            comboBoxSKS.Items.Add("3");
            comboBoxSKS.Items.Add("4");
            comboBoxSKS.SelectedIndex = 0;

            dgvMataKuliah.ColumnCount = 2;
            dgvMataKuliah.Columns[0].Name = "Mata Kuliah";
            dgvMataKuliah.Columns[1].Name = "SKS";

            listMataKuliah = MataKuliahRepository.Load();
            TampilkanMataKuliah();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelNamaMataKuliah_Click(object sender, EventArgs e)
        {

        }

        private void textBoxMataKuliah_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSKS_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSKS_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMataKuliah_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = e.RowIndex;
                textBoxMataKuliah.Text = dgvMataKuliah.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboBoxSKS.SelectedItem = dgvMataKuliah.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMataKuliah.Text))
            {
                MessageBox.Show("Nama Mata Kuliah harus diisi.");
                return;
            }

            Matkul mataKuliah = new Matkul
            {
                NamaMataKuliah = textBoxMataKuliah.Text,
                SKS = int.Parse(comboBoxSKS.SelectedItem.ToString())
            };

            listMataKuliah.Add(mataKuliah);
            MataKuliahRepository.Save(listMataKuliah);

            TampilkanMataKuliah();
            ClearInput();
        }



        private void TampilkanMataKuliah()
        {
            dgvMataKuliah.Rows.Clear();
            foreach (var mk in listMataKuliah)
            {
                dgvMataKuliah.Rows.Add(mk.NamaMataKuliah, mk.SKS);
            }

            dgvMataKuliah.ClearSelection();
        }

        private void ClearInput()
        {
            textBoxMataKuliah.Clear();
            comboBoxSKS.SelectedIndex = 0;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

        }
    }
}

