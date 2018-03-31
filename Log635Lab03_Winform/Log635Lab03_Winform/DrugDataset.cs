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
        public DataTable DataTable { get; set; }

        public List<string> Columns => new List<string>
        {
            "Id",
            "Age",
            "Genre",
            "Education",
            "Pays",
            "Ethnicité",
            "Neuroticisme",
            "Extraversion",
            "Ouverture",
            "Agréabilité",
            "Conscienciosité",
            "Impulsivité",
            "Recherche de sensations",
            "Alcohol",
            "Amphetamines",
            "Amyl nitrite",
            "Benzodiazepine",
            "Caffeine",
            "Cannabis",
            "Chocolate",
            "Cocaine",
            "Crack",
            "Ecstasy",
            "Heroin",
            "Ketamine",
            "Legal highs",
            "LSD",
            "Methadone",
            "Magic mushrooms",
            "Nicotine",
            "Semeron",
            "Volatile substance abuse",
            "INVALID COLUMN"
        };

        public void CreateDataset(List<string[]> rows)
        {
            DataTable = new DataTable();
            Columns.ForEach(x => DataTable.Columns.Add(x));
            rows.ForEach(x => DataTable.Rows.Add(x));
        }

        public void CleanAllColumns()
        {

        }

        public void CleanColumn(string columnName)
        {
            if (!Columns.Contains(columnName))
            {
                return;
            }


        }
    }
}
