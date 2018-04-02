using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log635Lab03_Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtFile.Text = @"G:\workspace\WhatsYourAddiction\Dataset.csv";
            
            Logger.Show();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = "csv files (*.csv)|*.csv",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = dialog.FileName;
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtFile.Text))
            {
                MessageBox.Show("Le chemin est invalid");
                return;
            }

            FormData formData = new FormData(txtFile.Text);
            formData.Show();
        }
    }
}
