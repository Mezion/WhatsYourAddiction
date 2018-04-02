using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Log635Lab03_Winform
{
    public enum DataType
    {
        None,
        Normalized,
        Numeric,
        NumericPercent,
        StringCategory
    }

    public static class DataHelper
    {
        public static DataType DetermineDataType(List<string> data)
        {
            var regPercent = new Regex(@"^[\d\.\s]+%$");
            var regNumeric = new Regex(@"^[\d\.]+$");
            var regNormalized = new Regex(@"^0.\d+|1|0$");

            if (data.All(r => regNormalized.IsMatch(r)))
            {
                return DataType.Normalized;
            }

            if (data.All(r => regPercent.IsMatch(r)))
            {
                return DataType.NumericPercent;
            }

            if (data.All(r => regNumeric.IsMatch(r)))
            {
                return DataType.Numeric;
            }

            return DataType.StringCategory;
        }
    }
}
