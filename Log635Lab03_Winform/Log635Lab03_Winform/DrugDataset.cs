using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log635Lab03_Winform
{
    public class DrugDataset
    {
        public DataTable DrugDataTable { get; set; }
        public List<string> Columns { get; set; }

        public void CreateDataset(List<string[]> rows)
        {
            DrugDataTable = new DataTable();

            var columnCount = rows.Max(r => r.Length);

            Columns = rows.ElementAt(0)?.ToList();

            for (int i = Columns?.Count ?? 0; i < columnCount; i++)
            {
                Columns?.Add($"{i}?");
            }

            Columns?.ForEach(x => DrugDataTable.Columns.Add(x));
            rows.RemoveAt(0);
            rows.ForEach(x => DrugDataTable.Rows.Add(x));

            TrimDataset();

            Logger.LogMessage($"Dataset created successfully");
        }

        private void TrimDataset()
        {
            Columns.ForEach(column =>
            {
                var cleaner = new DataCleaner(GetRows(column), column);
                var trimmedData = cleaner.TrimColumn();
                for (int i = 0; i < trimmedData.Count; i++)
                {
                    try
                    {
                        DrugDataTable.Rows[i][column] = trimmedData[i];
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex.Message);
                    }
                }
            });
        }
        
        public void CleanAllColumns()
        {
            Logger.LogMessage("Start cleaning all columns");
            
            foreach (var column in Columns)
            {
                CleanColumn(column);
            }

            Logger.LogMessage("Cleaned all columns successfully");
        }

        public void CleanColumn(string columnName)
        {
            if (!Columns.Contains(columnName))
            {
                return;
            }

            Logger.LogMessage($"\nCreate temporary data list");
            List<string> tempList = GetRows(columnName);
            Logger.LogMessage($"Create DataCleaner, ready to clean {tempList.Count} rows");

            DataCleaner dataCleaner = new DataCleaner(tempList, columnName);
            var cleanedData = dataCleaner.Clean();

            for (int i = 0; i < cleanedData.Count; i++)
            {
                try
                {
                    DrugDataTable.Rows[i][columnName] = cleanedData[i];
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex.Message);
                }
            }

            Logger.LogMessage($"Data has been updated in Dataset successfully\n");
        }

        public List<string> GetRows(string columnName)
        {
            if (!Columns.Contains(columnName))
            {
                return new List<string>();
            }

            List<string> tempList = new List<string>();

            foreach (DataRow row in DrugDataTable.Rows)
            {
                tempList.Add(row[columnName].ToString());
            }

            return tempList;
        }
    }
}
