namespace Log635Lab03_Winform
{
    partial class FormData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbColumns = new System.Windows.Forms.ComboBox();
            this.btnCleanColumn = new System.Windows.Forms.Button();
            this.btnCleanAll = new System.Windows.Forms.Button();
            this.btnShowColumn = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 38);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1219, 549);
            this.dataGridView1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1225, 590);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.cmbColumns);
            this.flowLayoutPanel1.Controls.Add(this.btnCleanColumn);
            this.flowLayoutPanel1.Controls.Add(this.btnCleanAll);
            this.flowLayoutPanel1.Controls.Add(this.btnShowColumn);
            this.flowLayoutPanel1.Controls.Add(this.btnShowAll);
            this.flowLayoutPanel1.Controls.Add(this.btnRemoveAll);
            this.flowLayoutPanel1.Controls.Add(this.btnStat);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1156, 29);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(103, 18);
            this.panel1.TabIndex = 5;
            // 
            // cmbColumns
            // 
            this.cmbColumns.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbColumns.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbColumns.FormattingEnabled = true;
            this.cmbColumns.Location = new System.Drawing.Point(112, 3);
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.Size = new System.Drawing.Size(371, 21);
            this.cmbColumns.TabIndex = 2;
            // 
            // btnCleanColumn
            // 
            this.btnCleanColumn.Location = new System.Drawing.Point(489, 3);
            this.btnCleanColumn.Name = "btnCleanColumn";
            this.btnCleanColumn.Size = new System.Drawing.Size(130, 23);
            this.btnCleanColumn.TabIndex = 1;
            this.btnCleanColumn.Text = "Nettoyer la colonne";
            this.btnCleanColumn.UseVisualStyleBackColor = true;
            this.btnCleanColumn.Click += new System.EventHandler(this.btnCleanColumn_Click);
            // 
            // btnCleanAll
            // 
            this.btnCleanAll.Location = new System.Drawing.Point(625, 3);
            this.btnCleanAll.Name = "btnCleanAll";
            this.btnCleanAll.Size = new System.Drawing.Size(121, 23);
            this.btnCleanAll.TabIndex = 4;
            this.btnCleanAll.Text = "Tout nettoyer";
            this.btnCleanAll.UseVisualStyleBackColor = true;
            this.btnCleanAll.Click += new System.EventHandler(this.btnCleanAll_Click);
            // 
            // btnShowColumn
            // 
            this.btnShowColumn.Location = new System.Drawing.Point(752, 3);
            this.btnShowColumn.Name = "btnShowColumn";
            this.btnShowColumn.Size = new System.Drawing.Size(92, 23);
            this.btnShowColumn.TabIndex = 6;
            this.btnShowColumn.Text = "Afficher";
            this.btnShowColumn.UseVisualStyleBackColor = true;
            this.btnShowColumn.Click += new System.EventHandler(this.btnShowColumn_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(850, 3);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(100, 23);
            this.btnShowAll.TabIndex = 7;
            this.btnShowAll.Text = "Tout Afficher";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(956, 3);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(92, 23);
            this.btnRemoveAll.TabIndex = 8;
            this.btnRemoveAll.Text = "Rien Afficher";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choisir un colonne";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 593);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 14);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnStat
            // 
            this.btnStat.Location = new System.Drawing.Point(1054, 3);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(99, 23);
            this.btnStat.TabIndex = 9;
            this.btnStat.Text = "Statistiques";
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // FormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 590);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormData";
            this.Text = "FormData";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbColumns;
        private System.Windows.Forms.Button btnCleanColumn;
        private System.Windows.Forms.Button btnCleanAll;
        private System.Windows.Forms.Button btnShowColumn;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStat;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}