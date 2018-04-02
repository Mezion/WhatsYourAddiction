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

            CreateDataset();
            FillCombobox();
        }

        private void FillCombobox()
        {
            _drugDataset.Columns.ForEach(c => cmbColumns.Items.Add(c));
        }
        
        private void CreateDataset()
        {
            var lines = File.ReadAllLines(_csvFile).Select(x => x.Split(',')).ToList();
            Logger.LogMessage($"All lines were read from file ${_csvFile}");

            try
            {
                _drugDataset.CreateDataset(lines);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error happened while creating Dataset: ${ex.Message}");
            }
            
            dataGridView1.DataSource = _drugDataset.DrugDataTable;
        }

        private void btnCleanColumn_Click(object sender, EventArgs e)
        {
            if (!_drugDataset.Columns.Contains(cmbColumns.Text))
            {
                MessageBox.Show("Colonne invalide");
                return;
            }

            Logger.LogMessage($"Request clean column: {cmbColumns.Text}");
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
                column.Visible = column.Visible || column.Name == cmbColumns.Text;
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Visible = true;
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Visible = false;
            }
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            var results = DataStat.Calculate(_drugDataset.GetRows(cmbColumns.Text));
            var formStat = new FormStat(cmbColumns.Text, results);
            formStat.Show();
        }

        private void btnDecisionTree_Click(object sender, EventArgs e)
        {
            btnCleanAll_Click(sender, e);
            DecisionTree decisionTree = new DecisionTree(_drugDataset);
        }

        private void btnKNN_Click(object sender, EventArgs e)
        {
            btnCleanAll_Click(sender, e);
            KNN knn = new KNN(_drugDataset);
        }
    }
}
