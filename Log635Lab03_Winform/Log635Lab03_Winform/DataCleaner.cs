using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Log635Lab03_Winform
{

    public class DataCleaner
    {
        private string _column;
        
        private List<string> _data;

        public DataCleaner(List<string> data, string column)
        {
            _data = data;
            _column = column;
        }

        public List<string> TrimColumn()
        {
            Logger.LogMessage($"trim column: {_column}");

            for (int i = 0; i < _data.Count; i++)
            {
                _data[i] = _data[i].TrimStart().TrimEnd().Trim();
            }

            return _data;
        }

        public List<string> Clean()
        {
            Logger.LogMessage($"Clean column: {_column}");

            for (int i = 0; i < _data.Count; i++)
            {
                _data[i] = _data[i].TrimStart().TrimEnd().Trim();
            }

            DataType type = DataType.None;

            while (type != DataType.Normalized)
            {
                type = DataHelper.DetermineDataType(_data);
                Logger.LogWarning($"Detected column data type is {type.ToString()}");

                CleanType(type);
            }

            Logger.LogMessage($"Column cleaned successfully");

            return _data;
        }

        private void CleanType(DataType type)
        {
            switch (type)
            {
                case DataType.None:
                    break;
                case DataType.Normalized:
                    break;
                case DataType.Numeric:
                    CleanNumeric();
                    break;
                case DataType.NumericPercent:
                    CleanNumericPercent();
                    break;
                case DataType.StringCategory:
                    CleanStringCategory();
                    break;
            }
        }

        private void CleanNumeric()
        {
            double min = _data.Min(x => double.Parse(x));
            double max = _data.Max(x => double.Parse(x));

            Logger.LogMessage($"Cleaning numeric continue data. Min = {min} and Max = {max}");

            if (max - min == 0)
            {
                Logger.LogError($"Could'nt clean numeric continue because max - min equals 0");
                for (int i = 0; i < _data.Count; i++)
                {
                    _data[i] = 0.ToString();
                }
                return;
            }

            for (int i = 0; i < _data.Count; i++)
            {
                double value = double.Parse(_data[i]);
                double newValue = (value - min) / (max - min);
                _data[i] = newValue.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void CleanNumericPercent()
        {
            Logger.LogMessage($"Cleaning numeric percent data");

            for (int i = 0; i < _data.Count; i++)
            {
                _data[i] = _data[i].Replace("%", "").Replace(" ", "");
            }
        }
        
        private void CleanStringCategory()
        {
            Logger.LogMessage($"Cleaning string category data");

            var distinctCategories = _data.Distinct().ToList();

            Logger.LogWarning($"{distinctCategories.Count()} categories detected:\n   -{string.Join("\n   -", distinctCategories)}");

            Dictionary<string, double> values = new Dictionary<string, double>();
            double range = distinctCategories.Count > 0 ? 1 / (double)distinctCategories.Count: 0;

            for (int i = 0; i < distinctCategories.Count; i++)
            {
                values.Add(distinctCategories[i], i * range);
            }

            for (int i = 0; i < _data.Count; i++)
            {
                _data[i] = values[_data[i]].ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
