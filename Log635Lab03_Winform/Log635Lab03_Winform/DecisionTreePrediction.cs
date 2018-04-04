using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log635Lab03_Winform
{
    public class DecisionTreePrediction
    {
        private DrugDataset _rawDataset;
        private DrugDataset _normalizedDataset;
        private SavingTree _tree;

        public DecisionTreePrediction(DrugDataset rawDataset, DrugDataset normalizedDataset, SavingTree tree)
        {
            _rawDataset = rawDataset;
            _normalizedDataset = normalizedDataset;
            _tree = tree;
        }

        public void Predict()
        {
            _rawDataset.DrugDataTable.Columns.Add("Prediction Nicotine");

            int i = 0;

            foreach (DataRow row in _normalizedDataset.DrugDataTable.Rows)
            {
                int depth = 0;
                var evaluation = RunTree(row, _tree.Root, 0, ref depth);
                var standard = Math.Round(evaluation * 6, 0, MidpointRounding.ToEven);
                _rawDataset.DrugDataTable.Rows[i]["Prediction Nicotine"] = standard;

                Logger.LogMessage($"Normalized prediction for row {i}: normalized = {evaluation},  standard = {standard}");

                i++;
            }

            
        }

        private double RunTree(DataRow row, TreeNode currentNode, double result, ref int depth)
        {
            if (currentNode == null)
                return result;

            depth++;

            if (!currentNode.Predicate(double.Parse(row[currentNode.Column].ToString())))
                return RunTree(row, currentNode.ChildTrue, currentNode.Result, ref depth);
            else
                return RunTree(row, currentNode.ChildFalse, currentNode.Result, ref depth);
        }
    }
}
