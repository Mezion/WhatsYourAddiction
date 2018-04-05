using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Statistics;
using Newtonsoft.Json;

namespace Log635Lab03_Winform
{
    public enum TrainingRatio
    {
        T1_E1, // 1/1
        T2_E1, // 2/1
        T3_E1, // 3/1
        T4_E1, // 4/1
        T1_E2, // 1/2
        T1_E3, // 1/3
        T1_E4, // 1/4
        T2_E3, // 2/3
        T3_E4, // 3/4
    }

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
        [JsonIgnore]
        public Predicate<double> Predicate { get; set; }
        public string PredicateMinExp { get; set; }
        public string PredicateMaxExp { get; set; }
        public double Result { get; set; }
        public TreeNode ChildTrue { get; set; }
        public TreeNode ChildFalse { get; set; }
    }

    public class DecisionTree
    {
        private readonly List<string> _remainingColumns;
        private readonly List<string> _columnsInConsideration;
        private readonly DrugDataset _dataset;
        private Tuple<int, double> _resultPredicateRange;
        private TrainingRatio _trainingRatio;
        private readonly double _stopEntropie;

        public DecisionTree(DrugDataset dataset, List<string> columnsInConsideration, double stopEntropie, TrainingRatio trainingRatio)
        {
            _dataset = dataset;
            _columnsInConsideration = columnsInConsideration;
            _stopEntropie = stopEntropie;
            _trainingRatio = trainingRatio;
            _remainingColumns = _dataset.Columns.Select(c => c).ToList();
        }

        public SavingTree RunTraining()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            InitResult();
            var root = Train();
            var rate = Evaluate(root);

            stopwatch.Stop();

            string ratio = "";
            switch (_trainingRatio)
            {
                case TrainingRatio.T1_E1:
                    ratio = "1 training / 1 evaluation";
                    break;
                case TrainingRatio.T2_E1:
                    ratio = "2 training / 1 evaluation";
                    break;
                case TrainingRatio.T3_E1:
                    ratio = "3 training / 1 evaluation";
                    break;
                case TrainingRatio.T4_E1:
                    ratio = "4 training / 1 evaluation";
                    break;
                case TrainingRatio.T1_E2:
                    ratio = "1 training / 2 evaluation";
                    break;
                case TrainingRatio.T1_E3:
                    ratio = "1 training / 3 evaluation";
                    break;
                case TrainingRatio.T1_E4:
                    ratio = "1 training / 4 evaluation";
                    break;
                case TrainingRatio.T2_E3:
                    ratio = "2 training / 3 evaluation";
                    break;
                case TrainingRatio.T3_E4:
                    ratio = "3 training / 4 evaluation";
                    break;
            }

            return new SavingTree
            {
                BuildTime = stopwatch.ElapsedMilliseconds,
                Columns = _columnsInConsideration.ToArray(),
                Name = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString(),
                Root = root,
                StoppingEntropie = _stopEntropie,
                SuccessRate = rate,
                TrainingRatio = ratio
            };
        }

        private void InitResult()
        {
            var results = _dataset.GetTrainingRows("Nicotine", _trainingRatio).Select(c => double.Parse(c)).ToList();
            _resultPredicateRange = DeterminePredicateRange(results);
        }

        private double Evaluate(TreeNode tree)
        {
            int i = 0;

            List<bool> succeed = new List<bool>();
            List<double> diffs = new List<double>();

            foreach (DataRow row in _dataset.DrugDataTable.Rows)
            {
                switch (_trainingRatio)
                {
                    case TrainingRatio.T1_E1:
                        if (i % 2 == 1)
                        {
                            i++;
                            continue;
                        }

                        break;
                    case TrainingRatio.T2_E1:
                        if (i % 3 <= 1)
                        {
                            i++;
                            continue;
                        }

                        break;
                    case TrainingRatio.T3_E1:
                        if (i % 4 <= 2)
                        {
                            i++;
                            continue;
                        }

                        break;
                    case TrainingRatio.T4_E1:
                        if (i % 5 <= 3)
                        {
                            i++;
                            continue;
                        }

                        break;
                    case TrainingRatio.T1_E2:
                        if (i % 3 > 1)
                        {
                            i++;
                            continue;
                        }

                        break;
                    case TrainingRatio.T1_E3:
                        if (i % 4 > 2)
                            i++;
                        continue;
                    case TrainingRatio.T1_E4:
                        if (i % 5 > 3)
                        {
                            i++;
                            continue;
                        }

                        break;
                    case TrainingRatio.T2_E3:
                        if (i % 5 > 2)
                        {
                            i++;
                            continue;
                        }

                        break;
                    case TrainingRatio.T3_E4:
                        if (i % 7 > 3)
                        {
                            i++;
                            continue;
                        }

                        break;
                }

                int depth = 0;

                var evalutation = RunTree(row, tree, 0, ref depth);
                var expected = double.Parse(row["Nicotine"].ToString());

                var success = Math.Abs(evalutation - expected) < 0.01;
                succeed.Add(success);

                var standardexpected = Math.Round(expected * 6, 0, MidpointRounding.ToEven);
                var standardevalutation = Math.Round(evalutation * 6, 0, MidpointRounding.ToEven);
                var diff = Math.Abs(standardexpected - standardevalutation);
                diffs.Add(1.0 - (double)diff / 6);
                var depthstr = depth < 10 ? "0" + depth.ToString() : depth.ToString();

                Logger.LogWarning($"Diff: {diff} Evaluation: {standardevalutation}, Expected: {standardexpected}, node ran: {depthstr}, success: {standardevalutation == standardexpected}");

                i++;
            }

            var rate = ((double)succeed.Count(s => s) / succeed.Count) * 100;
            var precision = ((double) diffs.Sum() / diffs.Count()) * 100;
            Logger.LogWarning($"\nSuccess {rate} % ");
            Logger.LogWarning($"\nPrecision {precision} % ");

            return rate;
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

        private TreeNode Train()
        {
            Logger.LogWarning("\nStart building decision tree");

            TreeNode root = CreateNode(new List<EvaluatedColumnPredicate>(), _dataset);

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
            var nodeCandidates = new Tuple<double, TreeNode>(double.MaxValue, null);
            EvaluatedColumnPredicate evaluationCandidate = new EvaluatedColumnPredicate();
            double entropieCandidate = -1;

            _remainingColumns.ForEach(column =>
            {
                if (!_columnsInConsideration.Contains(column))
                {
                    return;
                }

                var values = dataset.GetTrainingRows(column, _trainingRatio).Select(c => double.Parse(c)).ToList();
                var valuePredicateRange = DeterminePredicateRange(values);

                for (int i = 0; i < _resultPredicateRange.Item1; i++)
                {
                    for (int j = 0; j < valuePredicateRange.Item1; j++)
                    {
                        var resultPredicate = new Predicate<double>(d => d >= i * _resultPredicateRange.Item2 && d < (i + 1) * _resultPredicateRange.Item2);

                        var minExp = 0.ToString();
                        var maxExp = (valuePredicateRange.Item1 * valuePredicateRange.Item2 - ((j + 1) * valuePredicateRange.Item2)).ToString(CultureInfo.InvariantCulture);
                        //var minExp = (j * valuePredicateRange.Item2).ToString();
                        //var maxExp = ((j + 1) * valuePredicateRange.Item2).ToString();
                        var reg = new Regex(@"^[\d]+\.[\d]+$");

                        if (!reg.IsMatch(minExp))
                            minExp += ".0";

                        if (!reg.IsMatch(maxExp))
                            maxExp += ".0";

                        double test = 0;
                        if (!double.TryParse(maxExp, out test))
                        {
                            continue;
                        }

                        var valuePredicate = new Predicate<double>(d => d >= double.Parse(minExp) && d < double.Parse(maxExp));

                        var trueFilterExpression = $"{column} >= {minExp} AND {column} < {maxExp}";
                        var falseFilterExpression = $"NOT ({column} >= {minExp} AND {column} < {maxExp})";

                        var evaluation = new EvaluatedColumnPredicate{ Column = column, PredicateDescription = trueFilterExpression};

                        if (evaluatedParent.Contains(evaluation))
                        {
                            continue;
                        }

                        var results = dataset.GetTrainingRows("Nicotine", _trainingRatio).Select(c => double.Parse(c)).ToList();
                        var entropie = CalculateEntropie(results, values, valuePredicate, resultPredicate);

                        if (entropie < 0 || entropie > 1)
                            Logger.LogError($"Calculated entropie on column {column} with predicate {trueFilterExpression} is not valid => {entropie}");

                        if (entropie < nodeCandidates.Item1 && entropie > _stopEntropie)
                        {
                            evaluationCandidate = evaluation;
                            entropieCandidate = entropie;
                            nodeCandidates = new Tuple<double, TreeNode>(entropie, new TreeNode
                            {
                                ChildFalse = null,
                                ChildTrue = null,
                                Column = column,
                                Predicate = valuePredicate,
                                PredicateMaxExp = maxExp,
                                PredicateMinExp = minExp,
                                TrueFilterExpression = trueFilterExpression,
                                FalseFilterExpression = falseFilterExpression,
                                Result = i * _resultPredicateRange.Item2
                            });
                        }

                        if (_resultPredicateRange.Item2 < 0.16 || _resultPredicateRange.Item2 > 0.17)
                        {
                            Logger.LogError("Worng result");
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
