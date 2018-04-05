using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//////////////////////////////////////////////////////////////////////
using System.IO;
using MathNet.Numerics.Statistics;

namespace Log635Lab03_Winform
{
    public enum KNNInterpretation
    {
        Mean,
        Median,
        Mode
    }

    public class KNN2
    {
        private readonly int _neighborsInCondideration;
        private KNNInterpretation _interpretation;

        /// <summary>
        /// Liste de chaque row a evaluer contenant
        /// une liste de tous les voisins les plus proche pour chacune des rows
        /// Le voisin est un tuple qui contient la distance et la DataRow ( le data du voisin )
        /// </summary>
        private List<List<Tuple<double, DataRow>>> _nearers = new List<List<Tuple<double, DataRow>>>();

        private List<string> _columnsInConsideration;
        private DrugDataset _drugDataset;
        private DrugDataset _predictionDataset;

        public KNN2(DrugDataset drugDataset, List<string> columnsInConsideration, DrugDataset predictionDataset,
            int neighborsInCondideration, KNNInterpretation interpretation)
        {
            _drugDataset = drugDataset;
            _columnsInConsideration = columnsInConsideration;
            _predictionDataset = predictionDataset;
            _neighborsInCondideration = neighborsInCondideration;
            _interpretation = interpretation;

            _predictionDataset.CleanAllColumns();
            _drugDataset.CleanAllColumns();

            Predict();
            ShowResult();
            Interpret();
        }

        private void Predict()
        {
            _nearers.Clear();

            int index = 0;

            foreach (DataRow rowToPredict in _predictionDataset.DrugDataTable.Rows)
            {
                var neighbors = new List<Tuple<double, DataRow>>();

                foreach (DataRow dataRow in _drugDataset.DrugDataTable.Rows)
                {
                    var sum = 0.0;

                    _columnsInConsideration.ForEach(column =>
                    {
                        sum += Math.Pow(
                            double.Parse(rowToPredict[column].ToString()) - double.Parse(dataRow[column].ToString()),
                            2);
                    });

                    var distance = Math.Sqrt(sum);

                    if (neighbors.Count < _neighborsInCondideration)
                    {
                        neighbors.Add(new Tuple<double, DataRow>(distance, dataRow));
                        neighbors = neighbors.OrderBy(n => n.Item1).ToList();
                        continue;
                    }

                    var indexPivot = -1;

                    for (int i = 0; i < neighbors.Count; i++)
                    {
                        if (distance < neighbors[i].Item1)
                        {
                            indexPivot = i;
                            break;
                        }
                    }

                    if (indexPivot != -1)
                    {
                        var replacementNeighbor = new Tuple<double, DataRow>(distance, dataRow);

                        for (int i = indexPivot; i < neighbors.Count; i++)
                        {
                            var tempNeighbor = neighbors[i];
                            neighbors[i] = replacementNeighbor;
                            replacementNeighbor = new Tuple<double, DataRow>(tempNeighbor.Item1, tempNeighbor.Item2);
                        }
                    }
                }

                _nearers.Add(neighbors);

                Logger.LogMessage($"{neighbors.Count} nearer neighbors have been found for row {index}");

                index++;
            }
        }

        private void ShowResult()
        {
            var index = 0;

            foreach (var nearer in _nearers)
            {
                var nicotine = nearer.Select(ne =>
                {
                    var value = double.Parse(ne.Item2["Nicotine"].ToString());
                    return $"Nicotine: {Math.Round(value * 6, 0, MidpointRounding.ToEven)}   Distance: {ne.Item1}";
                });

                Logger.LogMessage(
                    $"Nearer neighbors for row {index} has a Nicotine of \n- {string.Join("\n- ", nicotine)}");

                index++;
            }
        }

        private void Interpret()
        {
            var index = 0;

            Logger.LogMessage("\n\nInterprétation des résultats");

            foreach (var nearer in _nearers)
            {
                var nicotine = nearer.Select(ne =>
                {
                    var value = double.Parse(ne.Item2["Nicotine"].ToString());
                    return Math.Round(value * 6, 0, MidpointRounding.ToEven);
                }).ToList();

                var result = -1.0;

                

                switch (_interpretation)
                {
                    case KNNInterpretation.Mean:
                        result = Math.Round(nicotine.Mean(), 0, MidpointRounding.ToEven);
                        break;
                    case KNNInterpretation.Median:
                        result = nicotine.Median();
                        break;
                    case KNNInterpretation.Mode:
                        result = nicotine.GroupBy(d => d)
                            .OrderByDescending(g => g.Count())
                            .First()
                            .Key;
                        break;
                }

                Logger.LogMessage($"Prediction for row {index} is {result}");

                index++;
            }
        }
    }
}