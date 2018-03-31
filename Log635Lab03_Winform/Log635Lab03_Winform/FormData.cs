using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log635Lab03_Winform
{
    public partial class FormData : Form
    {
        private readonly string _csvFile;
        private DrugDataset _drugDataset;


        public FormData(string file)
        {
            InitializeComponent();

            _csvFile = file;
            _drugDataset = new DrugDataset();

            FillCombobox();
            CreateDataset();
        }

        private void FillCombobox()
        {
            _drugDataset.Columns.ForEach(c => cmbColumns.Items.Add(c));
        }
        
        private void CreateDataset()
        {
            _drugDataset.CreateDataset(File.ReadAllLines(_csvFile).Select(x => x.Split(',')).ToList());
            dataGridView1.DataSource = _drugDataset.DataTable;
        }

        private void btnCleanColumn_Click(object sender, EventArgs e)
        {
            if (!_drugDataset.Columns.Contains(cmbColumns.Text))
            {
                MessageBox.Show("Colonne invalide");
                return;
            }

            _drugDataset.CleanColumn(cmbColumns.Text);
        }

        private void btnCleanAll_Click(object sender, EventArgs e)
        {
            _drugDataset.CleanAllColumns();
        }

        private void btnShowColumn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Visible = column.Name == cmbColumns.Text;
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Visible = true;
            }
        }
    }
}
