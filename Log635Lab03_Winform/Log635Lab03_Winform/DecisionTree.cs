using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log635Lab03_Winform
{
    public class DecisionTree
    {
        private List<string> _remainingColumns;

        private struct Repetition
        {
            public double Value { get; set; }
            public double Result { get; set; }
        }

        private struct EntropieCalculation
        {
            public string ColumnName { get; set; }
            public Dictionary<Repetition, int> Repetitions => new Dictionary<Repetition, int>();
            public Dictionary<Repetition, double> LP => new Dictionary<Repetition, double>();
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

        public void Train()
        {
            Logger.LogWarning("\nStart building decision tree");

            _remainingColumns.ForEach(column =>
            {
                Logger.LogMessage($"Calculate entropie for column {column}");

                var values = _dataset.GetRows(column).Select(r => double.Parse(r)).ToList();
                var results = _dataset.GetRows("Nicotine").Select(r => double.Parse(r)).ToList();

                if (values.Count != results.Count)
                    Logger.LogError($"Values and results didn't have the same length");

                var distinctValues = values.Distinct().ToList();
                var distinctResults = results.Distinct().ToList();

                var calcul = new EntropieCalculation();

                foreach (var result in distinctResults)
                foreach (var value in distinctValues)
                {
                    var key = new Repetition {Result = result, Value = value};
                    calcul.Repetitions.Add(key, 0);
                    calcul.LP.Add(key, value);
                }

                Logger.LogMessage($"Possible scenarios = {calcul.Repetitions.Count}");

                for (int i = 0; i < values.Count; i++)
                {
                    var repetition = new Repetition { Result = results[i], Value = values[i]};
                    calcul.Repetitions[repetition] += 1;
                }

                ;
            });
        }

        private void CalculateEntropie()
        {
        }
    }
}
