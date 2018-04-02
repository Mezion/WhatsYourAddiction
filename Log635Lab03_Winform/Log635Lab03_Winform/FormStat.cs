using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log635Lab03_Winform
{
    public partial class FormStat : Form
    {
        public FormStat(string column, List<StatResult> stats)
        {
            InitializeComponent();

            lblColumn.Text = $"Colonne {column}";
            DataTable statTable = new DataTable();
            statTable.Columns.Add("Titre");
            statTable.Columns.Add("Valeur");

            stats.ForEach(stat => statTable.Rows.Add(new object[]
            {
                stat.Label,
                stat.Result.ToString(CultureInfo.InvariantCulture)
            }));

            dataGridView1.DataSource = statTable;
        }
    }
}
