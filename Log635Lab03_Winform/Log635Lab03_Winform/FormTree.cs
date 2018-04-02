using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log635Lab03_Winform
{
    public partial class FormTree : Form
    {
        public TreePanel TreePanel
        {
            get { return treePanel1; }
        }

        public FormTree()
        {
            InitializeComponent();
        }
    }
}
