using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Log635Lab03_Winform
{
    public partial class FormTreeBuilder : Form
    {
        private DrugDataset _drugDataset;
        private SavingTree _tree;

        public FormTreeBuilder(DrugDataset drugDataset)
        {
            _drugDataset = drugDataset;
            InitializeComponent();

            checkedListBox1.Items.Clear();
            _drugDataset.Columns.ForEach(c => checkedListBox1.Items.Add(c));
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);

            txtEpsilon.Text = 0.ToString();
            rb31.Checked = true;
        }

        private void btnSearchTree_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = "tree files (*.tree)|*.tree",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtLoadTree.Text = dialog.FileName;
            }
        }

        private void btnLoadTree_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtLoadTree.Text))
            {
                MessageBox.Show("Le chemin est invalid");
                return;
            }

            string json = "";

            try
            {
                json = File.ReadAllText(txtLoadTree.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la lecture du fichier");
                return;
            }
            
            try
            {
                _tree = JsonConvert.DeserializeObject<SavingTree>(json, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur lors de la désérialisation de l'arbre, {ex.Message}");
                return;
            }

            ShowTreeInfo();
            RebuildPredicate(_tree.Root);

            lblTree.Text = _tree.Name + "( sauvegardé )";
            tabControl1.SelectedTab = tabPage3;
        }

        private void RebuildPredicate(TreeNode node)
        {
            if (node == null) { return; }
            var min = double.Parse(node.PredicateMinExp);
            var max = double.Parse(node.PredicateMaxExp);
            node.Predicate = d => d >= min && d < max;

            RebuildPredicate(node.ChildFalse);
            RebuildPredicate(node.ChildTrue);
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {

            List<string> columnsInConsideration = new List<string>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    columnsInConsideration.Add(checkedListBox1.Items[i].ToString());
                }
            }

            double entropie;

            if (!double.TryParse(txtEpsilon.Text, out entropie))
            {
                MessageBox.Show("Entropie format est pas valide");
                return;
            }
            if (entropie < 0 || entropie > 1)
            {
                MessageBox.Show("Entropie doit etre entre 0 et 1");
                return;
            }

            TrainingRatio ratio = TrainingRatio.T1_E1;

            if (rb11.Checked)
                ratio = TrainingRatio.T1_E1;
            if (rb21.Checked)
                ratio = TrainingRatio.T2_E1;
            if (rb31.Checked)
                ratio = TrainingRatio.T3_E1;
            if (rb41.Checked)
                ratio = TrainingRatio.T4_E1;
            if (rb12.Checked)
                ratio = TrainingRatio.T1_E2;
            if (rb13.Checked)
                ratio = TrainingRatio.T1_E3;
            if (rb14.Checked)
                ratio = TrainingRatio.T1_E4;
            if (rb23.Checked)
                ratio = TrainingRatio.T2_E3;
            if (rb34.Checked)
                ratio = TrainingRatio.T3_E4;


            Logger.BringToFront();

            _drugDataset.CleanAllColumns();

            DecisionTree decisionTree = new DecisionTree(_drugDataset, columnsInConsideration, entropie, ratio);
            _tree = decisionTree.RunTraining();

            lblTree.ForeColor = Color.Green;
            lblTree.Text = _tree.Name + "( non sauvegardé )";

            ShowTreeInfo();
            tabControl1.SelectedTab = tabPage3;
        }

        private void btnShowGraph_Click(object sender, EventArgs e)
        {
            if (_tree == null)
            {
                MessageBox.Show("Aucun arbre est loadé");
                return;
            }

            FormTreeResult result = new FormTreeResult();
            result.TreePanel.Root = _tree.Root;
            result.Show();
        }

        private void ShowTreeInfo()
        {
            txtResultEntropie.Text = _tree.StoppingEntropie.ToString(CultureInfo.InvariantCulture);
            txtResultSuccess.Text = _tree.SuccessRate.ToString(CultureInfo.InvariantCulture);
            txtResultTrainingTime.Text = _tree.BuildTime.ToString(CultureInfo.InvariantCulture);
            txtResultRatio.Text = _tree.TrainingRatio;

            listBoxResultColumn.Items.Clear();
            _tree.Columns.ToList().ForEach(c => { listBoxResultColumn.Items.Add(c); });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            var result = dialog.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                var jsonTree = JsonConvert.SerializeObject(_tree, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });

                File.WriteAllText(dialog.FileName + ".tree", jsonTree);

                lblTree.Text = _tree.Name + "( sauvegardé )";
            }
        }

        private void btnCheckNothing_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
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
            var rawDataset = new DrugDataset();
            var normalizedDataset = new DrugDataset();

            var rawLines = File.ReadAllLines(txtEvaluationFile.Text).Select(x => x.Split(',')).ToList();
            var lines = File.ReadAllLines(txtEvaluationFile.Text).Select(x => x.Split(',')).ToList();
            Logger.LogMessage($"All lines were read from evaluation file ${txtEvaluationFile.Text}");

            try
            {
                rawDataset.CreateDataset(rawLines);
                normalizedDataset.CreateDataset(lines);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error happened while creating Dataset: ${ex.Message}");
            }

            normalizedDataset.CleanAllColumns();

            DecisionTreePrediction prediction = new DecisionTreePrediction(rawDataset, normalizedDataset, _tree);
            prediction.Predict();
           
        }

    }
}