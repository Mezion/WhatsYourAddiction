using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace Log635Lab03_Winform
{
    public struct EvaluatedColumnPredicate
    {
        public string Column { get; set; }
        public string PredicateDescription { get; set; }
    }

    public class TreeNode
    {
        public string Column { get; set; }
        public string TrueFilterExpression { get; set; }
        public string FalseFilterExpression { get; set; }
        public Predicate<double> Predicate { get; set; }
        public double Result { get; set; }
        public TreeNode ChildTrue { get; set; }
        public TreeNode ChildFalse { get; set; }
        public TreeNode Parent { get; set; }
    }

    public class DecisionTree
    {
        private FormTree _treeForm = new FormTree();

        private readonly List<string> _remainingColumns;
        private readonly List<string> _forbiddenColumns = new List<string>() {"Id", "Nicotine"};
        private readonly DrugDataset _dataset;

        public DecisionTree(DrugDataset dataset)
        {
            _treeForm.Show();
            _dataset = dataset;
            _remainingColumns = _dataset.Columns.Select(c => c).ToList();

            var root = Train();

            Evaluate(root);
        }

        private void Evaluate(TreeNode tree)
        {
            int i = 0;
            foreach (DataRow row in _dataset.DrugDataTable.Rows)
            {
                if (i % 2 == 0)
                {
                    i++;
                    continue;
                }

                var evalutation = RunTree(row, tree, 0);
                var expected = double.Parse(row["Nicotine"].ToString());

                Logger.LogWarning($"{Math.Abs(evalutation - expected) < 0.01}, Evaluation: {evalutation}, Expected: {expected}");

                i++;
            }
        }

        private double RunTree(DataRow row, TreeNode currentNode, double result)
        {
            if (currentNode == null)
                return result;

            if (currentNode.Predicate(double.Parse(row[currentNode.Column].ToString())))
                return RunTree(row, currentNode.ChildTrue, currentNode.Result);
            else
                return RunTree(row, currentNode.ChildFalse, currentNode.Result);
            
        }

        private TreeNode Train()
        {
            Logger.LogWarning("\nStart building decision tree");

            TreeNode root = CreateNode(new List<EvaluatedColumnPredicate>(), _dataset);
            _treeForm.TreePanel.Root = root;

            return root;
        }

        private DrugDataset CreateFilteredDataset(DrugDataset fromDataset, string filterExpression)
        {
            var dataRows = fromDataset.DrugDataTable.Select(filterExpression);

            var rows = new List<string[]>();

            rows.Add(_dataset.Columns.ToArray());

            foreach (var dataRow in dataRows)
            {
                rows.Add(dataRow.ItemArray.Select(i => i.ToString()).ToArray());
            }

            var newDataset = new DrugDataset();
            newDataset.CreateDataset(rows);

            return newDataset;
        }

        private TreeNode CreateNode(List<EvaluatedColumnPredicate> evaluatedParent, DrugDataset dataset)
        {
            var results = dataset.GetTrainingRows("Nicotine").Select(c => double.Parse(c)).ToList();
            var resultPredicateRange = DeterminePredicateRange(results);

            var nodeCandidates = new Tuple<double, TreeNode>(double.MaxValue, null);
            EvaluatedColumnPredicate evaluationCandidate = new EvaluatedColumnPredicate();
            double entropieCandidate = -1;

            _remainingColumns.ForEach(column =>
            {
                if (_forbiddenColumns.Contains(column))
                {
                    return;
                }

                var values = dataset.GetTrainingRows(column).Select(c => double.Parse(c)).ToList();
                var valuePredicateRange = DeterminePredicateRange(values);

                for (int i = 0; i < resultPredicateRange.Item1; i++)
                {
                    for (int j = 0; j < valuePredicateRange.Item1; j++)
                    {
                        var valuePredicate = new Predicate<double>(d => d >= j * valuePredicateRange.Item2 && d < (j + 1) * valuePredicateRange.Item2);
                        var resultPredicate = new Predicate<double>(d => d >= i * resultPredicateRange.Item2 && d < (i + 1) * resultPredicateRange.Item2);

                        var minExp = (j * valuePredicateRange.Item2).ToString();
                        var maxExp = ((j + 1) * valuePredicateRange.Item2).ToString();
                        var reg = new Regex(@"^[\d]+\.[\d]+$");

                        if (!reg.IsMatch(minExp))
                            minExp += ".0";

                        if (!reg.IsMatch(maxExp))
                            maxExp += ".0";

                        var trueFilterExpression = $"{column} >= {minExp} AND {column} < {maxExp}";
                        var falseFilterExpression = $"NOT ({column} >= {minExp} AND {column} < {maxExp})";

                        var evaluation = new EvaluatedColumnPredicate{ Column = column, PredicateDescription = trueFilterExpression};

                        if (evaluatedParent.Contains(evaluation))
                        {
                            continue;
                        }

                        var entropie = CalculateEntropie(results, values, valuePredicate, resultPredicate);

                        if (entropie < 0 || entropie > 1)
                            Logger.LogError($"Calculated entropie on column {column} with predicate {trueFilterExpression} is not valid => {entropie}");

                        if (entropie < nodeCandidates.Item1)
                        {
                            evaluationCandidate = evaluation;
                            entropieCandidate = entropie;
                            nodeCandidates = new Tuple<double, TreeNode>(entropie, new TreeNode
                            {
                                ChildFalse = null,
                                ChildTrue = null,
                                Column = column,
                                Predicate = valuePredicate,
                                TrueFilterExpression = trueFilterExpression,
                                FalseFilterExpression = falseFilterExpression,
                                Result = i * resultPredicateRange.Item2
                            });
                        }
                    }
                }
            });


            evaluatedParent.Add(evaluationCandidate);

            if (nodeCandidates.Item2 != null)
            {
                Logger.LogMessage($"Treenode created with column {nodeCandidates.Item2?.Column}, entropie = {entropieCandidate}, predicate = {nodeCandidates.Item2?.TrueFilterExpression}, result = {nodeCandidates.Item2?.Result}");

                nodeCandidates.Item2.ChildFalse = CreateNode(evaluatedParent, CreateFilteredDataset(dataset, nodeCandidates.Item2.TrueFilterExpression));
                nodeCandidates.Item2.ChildTrue = CreateNode(evaluatedParent, CreateFilteredDataset(dataset, nodeCandidates.Item2.FalseFilterExpression));
            }
            
            return nodeCandidates.Item2;
        }

        private double CalculateEntropie(List<double> results, List<double> values, Predicate<double> valuePredicate, Predicate<double> resultPredicate)
        {
            int f1s1 = 0, f1s0 = 0, f0s1 = 0, f0s0 = 0;
            
            for (int i = 0; i < results.Count; i++)
            {
                if (valuePredicate(values[i]) && resultPredicate(results[i]))
                    f1s1 += 1;
                else if (valuePredicate(values[i]) && !resultPredicate(results[i]))
                    f1s0 += 1;
                else if (!valuePredicate(values[i]) && resultPredicate(results[i]))
                    f0s1 += 1;
                else if (!valuePredicate(values[i]) && !resultPredicate(results[i]))
                    f0s0 += 1;
            }

            double p1 = (double)f1s1 / (f1s1 + f1s0);
            double p0 = (double)f0s1 / (f0s1 + f0s0);

            double H1 = -p1 * Math.Log(p1, 2) - (1 - p1) * Math.Log(1 - p1, 2);
            double H0 = -p0 * Math.Log(p0, 2) - (1 - p0) * Math.Log(1 - p0, 2);

            double up1 = (double)(f1s0 + f1s1) / (f1s1 + f1s0 + f0s0 + f0s1);
            double up0 = (double)(f0s0 + f0s1) / (f1s1 + f1s0 + f0s0 + f0s1);

            double entropie = H1 * up1 + H0 * up0;

            return entropie;
        }

        private Tuple<int, double> DeterminePredicateRange(List<double> values)
        {
            var orderedValues = values.Distinct().OrderBy(v => v).ToList();

            var min = Statistics.Minimum(orderedValues);
            var max = Statistics.Maximum(orderedValues);

            var tot = orderedValues.Count > 10 ? 10 : orderedValues.Count;

            return new Tuple<int, double>(tot, (max - min) / (tot - 1));
        }
    }
}
