using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace Log635Lab03_Winform
{
    public struct StatResult
    {
        public string Label { get; set; }
        public string Result { get; set; }
    }

    public static class DataStat
    {
        public static List<StatResult> Calculate(List<string> data)
        {
            switch (DataHelper.DetermineDataType(data))
            {
                case DataType.None:
                    return NumericStat(data);
                case DataType.Normalized:
                    return NumericStat(data);
                case DataType.Numeric:
                    return NumericStat(data);
                case DataType.NumericPercent:
                    return NumericStat(data);
                case DataType.StringCategory:
                    return StringCategoriesStat(data);
            }

            return new List<StatResult>();
        }

        private static List<StatResult> StringCategoriesStat(List<string> data)
        {
            List<StatResult> results = new List<StatResult>();

            var groups = data.GroupBy(v => v).ToList();

            results.Add(new StatResult
            {
                Label = "Mode (valeur)",
                Result = groups
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Key
            });
            results.Add(new StatResult
            {
                Label = "Mode (nombre de valeurs)",
                Result = groups.Max(gr => gr.Count()).ToString(CultureInfo.InvariantCulture)
            });

            groups.ForEach(gr =>
            {
                results.Add(new StatResult
                {
                    Label = $"Fréquence: {gr.Key}",
                    Result = gr.Count().ToString()
                });
            });

            return results;
        }

        private static List<StatResult> NumericStat(List<string> data)
        {
            List<StatResult> results = new List<StatResult>();
            try
            {
                var numData = data.Select(x => double.Parse(x)).ToList();

                double min = ArrayStatistics.Minimum(numData.ToArray());
                double max = ArrayStatistics.Maximum(numData.ToArray());

                results.Add(new StatResult
                {
                    Label = "Moyenne",
                    Result = ArrayStatistics.Mean(numData.ToArray()).ToString(CultureInfo.InvariantCulture)
                });
                results.Add(new StatResult
                {
                    Label = "Médiane",
                    Result = ArrayStatistics.MedianInplace(numData.ToArray()).ToString(CultureInfo.InvariantCulture)
                });
                results.Add(new StatResult
                {
                    Label = "Maximum",
                    Result = max.ToString(CultureInfo.InvariantCulture)
                });
                results.Add(new StatResult
                {
                    Label = "Minimum",
                    Result = min.ToString(CultureInfo.InvariantCulture)
                });
                results.Add(new StatResult
                {
                    Label = "Étendue",
                    Result = (max - min).ToString(CultureInfo.InvariantCulture)
                });
                results.Add(new StatResult
                {
                    Label = "Écart-type",
                    Result = ArrayStatistics.StandardDeviation(numData.ToArray()).ToString(CultureInfo.InvariantCulture)
                });
                results.Add(new StatResult
                {
                    Label = "Variance",
                    Result = ArrayStatistics.Variance(numData.ToArray()).ToString(CultureInfo.InvariantCulture)
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }

            return results;
        }
    }
}
