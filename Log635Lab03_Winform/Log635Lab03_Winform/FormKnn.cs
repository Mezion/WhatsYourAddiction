using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log635Lab03_Winform
{
    public partial class FormKnn : Form
    {
        private DrugDataset _drugDataset;
        private KNN2 _knn2;

        public FormKnn(DrugDataset drugDataset)
        {
            InitializeComponent();

            _drugDataset = drugDataset;
            _drugDataset.Columns.OrderBy(c => c).ToList().ForEach(c => checkedListBox1.Items.Add(c));
        }

        private void btnSearchEvaluationFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = "csv files (*.csv)|*.csv",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtEvaluationFile.Text = dialog.FileName;
            }
        }

        private void btnEvaluateFile_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtEvaluationFile.Text))
            {
                MessageBox.Show("Chemin invalide");
                return;
            }

            var dataset = new DrugDataset();
           
            var lines = File.ReadAllLines(txtEvaluationFile.Text).Select(x => x.Split(',')).ToList();
            Logger.LogMessage($"All lines were read from evaluation file ${txtEvaluationFile.Text}");

            try
            {
                dataset.CreateDataset(lines);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error happened while creating Dataset: ${ex.Message}");
            }

            var columnsInConsideration = new List<string>();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    columnsInConsideration.Add(checkedListBox1.Items[i].ToString());
                }
            }
            
            _knn2 = new KNN2(_drugDataset, columnsInConsideration, dataset);
        }
    }
}
