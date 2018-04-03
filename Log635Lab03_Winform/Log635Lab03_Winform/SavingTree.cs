using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log635Lab03_Winform
{
    public class SavingTree
    {
        public string Name { get; set; }
        public TreeNode Root { get; set; }
        public double SuccessRate { get; set; }
        public double StoppingEntropie { get; set; }
        public string[] Columns { get; set; }
        public double BuildTime { get; set; }
        public string TrainingRatio { get; set; }
    }
}
