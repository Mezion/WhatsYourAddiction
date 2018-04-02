namespace Log635Lab03_Winform
{
    partial class FormTree
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
            this.components = new System.ComponentModel.Container();
            this.treePanel1 = new Log635Lab03_Winform.TreePanel(this.components);
            this.SuspendLayout();
            // 
            // treePanel1
            // 
            this.treePanel1.AutoScroll = true;
            this.treePanel1.Location = new System.Drawing.Point(0, 0);
            this.treePanel1.Name = "treePanel1";
            this.treePanel1.Size = new System.Drawing.Size(20000, 20000);
            this.treePanel1.TabIndex = 0;
            // 
            // FormTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(973, 544);
            this.Controls.Add(this.treePanel1);
            this.Name = "FormTree";
            this.Text = "FormTree";
            this.ResumeLayout(false);

        }

        #endregion

        private TreePanel treePanel1;
    }
}