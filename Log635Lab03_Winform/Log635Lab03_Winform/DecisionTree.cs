using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
        public string PredicateDescription { get; set; }
        public Predicate<double> Predicate { get; set; }
        public TreeNode ChildTrue { get; set; }
        public TreeNode ChildFalse { get; set; }
    }

    public class DecisionTree
    {
        private List<string> _remainingColumns;
        private List<string> _forbiddenColumns = new List<string>() { "Id"};
        private List<EvaluatedColumnPredicate> _evaluatedColumnPredicates = new List<EvaluatedColumnPredicate>();


        private struct Combinaison
        {
            public double Value { get; set; }
            public double Result { get; set; }
        }

        private struct EntropieCalculation
        {
            public string ColumnName { get; set; }
            public Dictionary<Combinaison, int> Repetitions { get; set; }
            public Dictionary<Combinaison, double> LP { get; set; }
            public double UP { get; set; }
            public double UH { get; set; }
            public double Entropie { get; set; }
        }

        private DrugDataset _dataset;

        public DecisionTree(DrugDataset dataset)
        {
            _dataset = dataset;
            _remainingColumns = _dataset.Columns.Select(c => c).ToList();

            Train();
        }

        private void Train()
        {
            Logger.LogWarning("\nStart building decision tree");

            while (CreateNode() != null)
            {
                
            }

            ;
        }

        private TreeNode CreateNode()
        {
            var results = _dataset.GetRows("Nicotine").Select(c => double.Parse(c)).ToList();
            var resultPredicateRange = DeterminePredicateRange(results);

            var nodeCandidates = new Tuple<double, TreeNode>(double.MaxValue, null);
            EvaluatedColumnPredicate evaluationCandidate = new EvaluatedColumnPredicate();

            _remainingColumns.ForEach(column =>
            {
                if (_forbiddenColumns.Contains(column))
                {
                    return;
                }

                var values = _dataset.GetRows(column).Select(c => double.Parse(c)).ToList();
                var valuePredicateRange = DeterminePredicateRange(values);

                for (int i = 0; i < resultPredicateRange.Item1; i++)
                {
                    for (int j = 0; j < valuePredicateRange.Item1; j++)
                    {
                        var valuePredicate = new Predicate<double>(d => d >= j * valuePredicateRange.Item2 && d < (j + 1) * valuePredicateRange.Item2);
                        var resultPredicate = new Predicate<double>(d => d >= i * resultPredicateRange.Item2 && d < (i + 1) * resultPredicateRange.Item2);

                        var predicateDescription = $"d >= {j * valuePredicateRange.Item2} && d < {(j + 1) * valuePredicateRange.Item2}";

                        var evaluation = new EvaluatedColumnPredicate{ Column = column, PredicateDescription = predicateDescription};

                        if (_evaluatedColumnPredicates.Contains(evaluation))
                        {
                            continue;
                        }

                        var entropie = CalculateEntropie(results, values, valuePredicate, resultPredicate);

                        if (entropie < nodeCandidates.Item1)
                        {
                            evaluationCandidate = evaluation;
                            nodeCandidates = new Tuple<double, TreeNode>(entropie, new TreeNode
                            {
                                ChildFalse = null,
                                ChildTrue = null,
                                Column = column,
                                Predicate = valuePredicate,
                                PredicateDescription = predicateDescription
                            });
                        }
                    }
                }
            });

            _evaluatedColumnPredicates.Add(evaluationCandidate);
            Logger.LogMessage($"Treenode created with column {nodeCandidates.Item2?.Column} and predicate = {nodeCandidates.Item2?.PredicateDescription}");

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

            return new Tuple<int, double>(tot, (max - min) / tot);
        }

        private void CalculateEntropie()
        {
        }
    }
}
