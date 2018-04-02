using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace Log635Lab03_Winform
{
    public struct StatResult
    {
        public string Label { get; set; }
        public double Result { get; set; }
    }

    public static class DataStat
    {
        public static List<StatResult> Calculate(List<string> data)
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
                    Result = ArrayStatistics.Mean(numData.ToArray())
                });
                results.Add(new StatResult
                {
                    Label = "Médiane",
                    Result = ArrayStatistics.MedianInplace(numData.ToArray())
                });
                results.Add(new StatResult
                {
                    Label = "Maximum",
                    Result = max
                });
                results.Add(new StatResult
                {
                    Label = "Minimum",
                    Result = min
                });
                results.Add(new StatResult
                {
                    Label = "Étendue",
                    Result = max - min
                });
                results.Add(new StatResult
                {
                    Label = "Écart-type",
                    Result = ArrayStatistics.StandardDeviation(numData.ToArray())
                });
                results.Add(new StatResult
                {
                    Label = "Variance",
                    Result = ArrayStatistics.Variance(numData.ToArray())
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
