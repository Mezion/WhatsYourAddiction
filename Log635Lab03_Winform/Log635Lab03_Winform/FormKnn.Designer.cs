namespace Log635Lab03_Winform
{
    partial class FormKnn
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
            this.label11 = new System.Windows.Forms.Label();
            this.btnEvaluateFile = new System.Windows.Forms.Button();
            this.btnSearchEvaluationFile = new System.Windows.Forms.Button();
            this.txtEvaluationFile = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(360, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(289, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "KNN  Évaluer des entrés d\'un ficher .csv";
            // 
            // btnEvaluateFile
            // 
            this.btnEvaluateFile.Location = new System.Drawing.Point(361, 73);
            this.btnEvaluateFile.Name = "btnEvaluateFile";
            this.btnEvaluateFile.Size = new System.Drawing.Size(124, 23);
            this.btnEvaluateFile.TabIndex = 19;
            this.btnEvaluateFile.Text = "Évaluer le fichier";
            this.btnEvaluateFile.UseVisualStyleBackColor = true;
            this.btnEvaluateFile.Click += new System.EventHandler(this.btnEvaluateFile_Click);
            // 
            // btnSearchEvaluationFile
            // 
            this.btnSearchEvaluationFile.Location = new System.Drawing.Point(751, 42);
            this.btnSearchEvaluationFile.Name = "btnSearchEvaluationFile";
            this.btnSearchEvaluationFile.Size = new System.Drawing.Size(124, 23);
            this.btnSearchEvaluationFile.TabIndex = 20;
            this.btnSearchEvaluationFile.Text = "Rechercher un fichier";
            this.btnSearchEvaluationFile.UseVisualStyleBackColor = true;
            this.btnSearchEvaluationFile.Click += new System.EventHandler(this.btnSearchEvaluationFile_Click);
            // 
            // txtEvaluationFile
            // 
            this.txtEvaluationFile.Location = new System.Drawing.Point(361, 47);
            this.txtEvaluationFile.Name = "txtEvaluationFile";
            this.txtEvaluationFile.Size = new System.Drawing.Size(385, 20);
            this.txtEvaluationFile.TabIndex = 21;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 18);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(342, 604);
            this.checkedListBox1.TabIndex = 23;
            // 
            // FormKnn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 636);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnEvaluateFile);
            this.Controls.Add(this.btnSearchEvaluationFile);
            this.Controls.Add(this.txtEvaluationFile);
            this.Name = "FormKnn";
            this.Text = "FormKnn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnEvaluateFile;
        private System.Windows.Forms.Button btnSearchEvaluationFile;
        private System.Windows.Forms.TextBox txtEvaluationFile;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}