namespace Log635Lab03_Winform
{
    partial class FormTreeBuilder
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
            this.btnLoadTree = new System.Windows.Forms.Button();
            this.btnSearchTree = new System.Windows.Forms.Button();
            this.txtLoadTree = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEpsilon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnCheckNothing = new System.Windows.Forms.Button();
            this.rb34 = new System.Windows.Forms.RadioButton();
            this.rb23 = new System.Windows.Forms.RadioButton();
            this.rb14 = new System.Windows.Forms.RadioButton();
            this.rb13 = new System.Windows.Forms.RadioButton();
            this.rb12 = new System.Windows.Forms.RadioButton();
            this.rb41 = new System.Windows.Forms.RadioButton();
            this.rb31 = new System.Windows.Forms.RadioButton();
            this.rb21 = new System.Windows.Forms.RadioButton();
            this.rb11 = new System.Windows.Forms.RadioButton();
            this.btnBuild = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnShowGraph = new System.Windows.Forms.Button();
            this.txtResultTrainingTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtResultRatio = new System.Windows.Forms.TextBox();
            this.txtResultSuccess = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtResultEntropie = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxResultColumn = new System.Windows.Forms.ListBox();
            this.lblTree = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.btnEvaluateFile = new System.Windows.Forms.Button();
            this.btnSearchEvaluationFile = new System.Windows.Forms.Button();
            this.txtEvaluationFile = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadTree
            // 
            this.btnLoadTree.Location = new System.Drawing.Point(12, 84);
            this.btnLoadTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadTree.Name = "btnLoadTree";
            this.btnLoadTree.Size = new System.Drawing.Size(165, 28);
            this.btnLoadTree.TabIndex = 0;
            this.btnLoadTree.Text = "Charger l\'arbre";
            this.btnLoadTree.UseVisualStyleBackColor = true;
            this.btnLoadTree.Click += new System.EventHandler(this.btnLoadTree_Click);
            // 
            // btnSearchTree
            // 
            this.btnSearchTree.Location = new System.Drawing.Point(697, 52);
            this.btnSearchTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearchTree.Name = "btnSearchTree";
            this.btnSearchTree.Size = new System.Drawing.Size(165, 28);
            this.btnSearchTree.TabIndex = 1;
            this.btnSearchTree.Text = "Rechercher un arbre";
            this.btnSearchTree.UseVisualStyleBackColor = true;
            this.btnSearchTree.Click += new System.EventHandler(this.btnSearchTree_Click);
            // 
            // txtLoadTree
            // 
            this.txtLoadTree.Location = new System.Drawing.Point(12, 52);
            this.txtLoadTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLoadTree.Name = "txtLoadTree";
            this.txtLoadTree.Size = new System.Drawing.Size(676, 22);
            this.txtLoadTree.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chargement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Construire un nouvel arbre";
            // 
            // txtEpsilon
            // 
            this.txtEpsilon.Location = new System.Drawing.Point(605, 68);
            this.txtEpsilon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEpsilon.Name = "txtEpsilon";
            this.txtEpsilon.Size = new System.Drawing.Size(203, 22);
            this.txtEpsilon.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Entropie minimale";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Colonnes à considérer";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(181, 71);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(203, 616);
            this.checkedListBox1.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1196, 754);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnLoadTree);
            this.tabPage1.Controls.Add(this.btnSearchTree);
            this.tabPage1.Controls.Add(this.txtLoadTree);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1151, 725);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ouvrir un arbre existant";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCheckAll);
            this.tabPage2.Controls.Add(this.btnCheckNothing);
            this.tabPage2.Controls.Add(this.rb34);
            this.tabPage2.Controls.Add(this.rb23);
            this.tabPage2.Controls.Add(this.rb14);
            this.tabPage2.Controls.Add(this.rb13);
            this.tabPage2.Controls.Add(this.rb12);
            this.tabPage2.Controls.Add(this.rb41);
            this.tabPage2.Controls.Add(this.rb31);
            this.tabPage2.Controls.Add(this.rb21);
            this.tabPage2.Controls.Add(this.rb11);
            this.tabPage2.Controls.Add(this.btnBuild);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.checkedListBox1);
            this.tabPage2.Controls.Add(this.txtEpsilon);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(1151, 725);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Construire un arbre";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(24, 142);
            this.btnCheckAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(145, 28);
            this.btnCheckAll.TabIndex = 22;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnCheckNothing
            // 
            this.btnCheckNothing.Location = new System.Drawing.Point(24, 106);
            this.btnCheckNothing.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCheckNothing.Name = "btnCheckNothing";
            this.btnCheckNothing.Size = new System.Drawing.Size(145, 28);
            this.btnCheckNothing.TabIndex = 21;
            this.btnCheckNothing.Text = "Check Nothing";
            this.btnCheckNothing.UseVisualStyleBackColor = true;
            this.btnCheckNothing.Click += new System.EventHandler(this.btnCheckNothing_Click);
            // 
            // rb34
            // 
            this.rb34.AutoSize = true;
            this.rb34.Location = new System.Drawing.Point(605, 348);
            this.rb34.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb34.Name = "rb34";
            this.rb34.Size = new System.Drawing.Size(49, 21);
            this.rb34.TabIndex = 20;
            this.rb34.TabStop = true;
            this.rb34.Text = "3/4";
            this.rb34.UseVisualStyleBackColor = true;
            // 
            // rb23
            // 
            this.rb23.AutoSize = true;
            this.rb23.Location = new System.Drawing.Point(605, 320);
            this.rb23.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb23.Name = "rb23";
            this.rb23.Size = new System.Drawing.Size(49, 21);
            this.rb23.TabIndex = 19;
            this.rb23.TabStop = true;
            this.rb23.Text = "2/3";
            this.rb23.UseVisualStyleBackColor = true;
            // 
            // rb14
            // 
            this.rb14.AutoSize = true;
            this.rb14.Location = new System.Drawing.Point(605, 292);
            this.rb14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb14.Name = "rb14";
            this.rb14.Size = new System.Drawing.Size(49, 21);
            this.rb14.TabIndex = 18;
            this.rb14.TabStop = true;
            this.rb14.Text = "1/4";
            this.rb14.UseVisualStyleBackColor = true;
            // 
            // rb13
            // 
            this.rb13.AutoSize = true;
            this.rb13.Location = new System.Drawing.Point(605, 263);
            this.rb13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb13.Name = "rb13";
            this.rb13.Size = new System.Drawing.Size(49, 21);
            this.rb13.TabIndex = 17;
            this.rb13.TabStop = true;
            this.rb13.Text = "1/3";
            this.rb13.UseVisualStyleBackColor = true;
            // 
            // rb12
            // 
            this.rb12.AutoSize = true;
            this.rb12.Location = new System.Drawing.Point(605, 235);
            this.rb12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb12.Name = "rb12";
            this.rb12.Size = new System.Drawing.Size(49, 21);
            this.rb12.TabIndex = 16;
            this.rb12.TabStop = true;
            this.rb12.Text = "1/2";
            this.rb12.UseVisualStyleBackColor = true;
            // 
            // rb41
            // 
            this.rb41.AutoSize = true;
            this.rb41.Location = new System.Drawing.Point(605, 207);
            this.rb41.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb41.Name = "rb41";
            this.rb41.Size = new System.Drawing.Size(49, 21);
            this.rb41.TabIndex = 15;
            this.rb41.TabStop = true;
            this.rb41.Text = "4/1";
            this.rb41.UseVisualStyleBackColor = true;
            // 
            // rb31
            // 
            this.rb31.AutoSize = true;
            this.rb31.Location = new System.Drawing.Point(605, 178);
            this.rb31.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb31.Name = "rb31";
            this.rb31.Size = new System.Drawing.Size(49, 21);
            this.rb31.TabIndex = 14;
            this.rb31.TabStop = true;
            this.rb31.Text = "3/1";
            this.rb31.UseVisualStyleBackColor = true;
            // 
            // rb21
            // 
            this.rb21.AutoSize = true;
            this.rb21.Location = new System.Drawing.Point(605, 150);
            this.rb21.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb21.Name = "rb21";
            this.rb21.Size = new System.Drawing.Size(49, 21);
            this.rb21.TabIndex = 13;
            this.rb21.TabStop = true;
            this.rb21.Text = "2/1";
            this.rb21.UseVisualStyleBackColor = true;
            // 
            // rb11
            // 
            this.rb11.AutoSize = true;
            this.rb11.Location = new System.Drawing.Point(605, 122);
            this.rb11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb11.Name = "rb11";
            this.rb11.Size = new System.Drawing.Size(49, 21);
            this.rb11.TabIndex = 12;
            this.rb11.TabStop = true;
            this.rb11.Text = "1/1";
            this.rb11.UseVisualStyleBackColor = true;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(416, 394);
            this.btnBuild.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(393, 95);
            this.btnBuild.TabIndex = 11;
            this.btnBuild.Text = "Construire";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ratio entrainement/test";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.btnEvaluateFile);
            this.tabPage3.Controls.Add(this.btnSearchEvaluationFile);
            this.tabPage3.Controls.Add(this.txtEvaluationFile);
            this.tabPage3.Controls.Add(this.btnSave);
            this.tabPage3.Controls.Add(this.btnShowGraph);
            this.tabPage3.Controls.Add(this.txtResultTrainingTime);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.txtResultRatio);
            this.tabPage3.Controls.Add(this.txtResultSuccess);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.txtResultEntropie);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.listBoxResultColumn);
            this.tabPage3.Controls.Add(this.lblTree);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(1188, 725);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Arbre actuel";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(327, 240);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(221, 28);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Sauvegarder l\'arbre";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnShowGraph
            // 
            this.btnShowGraph.Location = new System.Drawing.Point(327, 204);
            this.btnShowGraph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowGraph.Name = "btnShowGraph";
            this.btnShowGraph.Size = new System.Drawing.Size(221, 28);
            this.btnShowGraph.TabIndex = 13;
            this.btnShowGraph.Text = "Afficher le graphique";
            this.btnShowGraph.UseVisualStyleBackColor = true;
            this.btnShowGraph.Click += new System.EventHandler(this.btnShowGraph_Click);
            // 
            // txtResultTrainingTime
            // 
            this.txtResultTrainingTime.Location = new System.Drawing.Point(507, 158);
            this.txtResultTrainingTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResultTrainingTime.Name = "txtResultTrainingTime";
            this.txtResultTrainingTime.Size = new System.Drawing.Size(199, 22);
            this.txtResultTrainingTime.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(323, 158);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Temps entrainement (ms)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(323, 96);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "Ratio entrainement/test";
            // 
            // txtResultRatio
            // 
            this.txtResultRatio.Location = new System.Drawing.Point(507, 92);
            this.txtResultRatio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResultRatio.Name = "txtResultRatio";
            this.txtResultRatio.Size = new System.Drawing.Size(199, 22);
            this.txtResultRatio.TabIndex = 8;
            // 
            // txtResultSuccess
            // 
            this.txtResultSuccess.Location = new System.Drawing.Point(507, 126);
            this.txtResultSuccess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResultSuccess.Name = "txtResultSuccess";
            this.txtResultSuccess.Size = new System.Drawing.Size(199, 22);
            this.txtResultSuccess.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(323, 126);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Taux de succèss";
            // 
            // txtResultEntropie
            // 
            this.txtResultEntropie.Location = new System.Drawing.Point(507, 60);
            this.txtResultEntropie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResultEntropie.Name = "txtResultEntropie";
            this.txtResultEntropie.Size = new System.Drawing.Size(199, 22);
            this.txtResultEntropie.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Entropie minimale";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 60);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Colonnes considérées";
            // 
            // listBoxResultColumn
            // 
            this.listBoxResultColumn.FormattingEnabled = true;
            this.listBoxResultColumn.ItemHeight = 16;
            this.listBoxResultColumn.Location = new System.Drawing.Point(28, 84);
            this.listBoxResultColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxResultColumn.Name = "listBoxResultColumn";
            this.listBoxResultColumn.Size = new System.Drawing.Size(236, 516);
            this.listBoxResultColumn.TabIndex = 1;
            // 
            // lblTree
            // 
            this.lblTree.AutoSize = true;
            this.lblTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTree.ForeColor = System.Drawing.Color.Red;
            this.lblTree.Location = new System.Drawing.Point(23, 17);
            this.lblTree.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTree.Name = "lblTree";
            this.lblTree.Size = new System.Drawing.Size(184, 25);
            this.lblTree.TabIndex = 0;
            this.lblTree.Text = "Aucun arbre chargé";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(326, 299);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(308, 25);
            this.label11.TabIndex = 18;
            this.label11.Text = "Évaluer des entrés d\'un ficher .csv";
            // 
            // btnEvaluateFile
            // 
            this.btnEvaluateFile.Location = new System.Drawing.Point(327, 367);
            this.btnEvaluateFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnEvaluateFile.Name = "btnEvaluateFile";
            this.btnEvaluateFile.Size = new System.Drawing.Size(165, 28);
            this.btnEvaluateFile.TabIndex = 15;
            this.btnEvaluateFile.Text = "Évaluer le fichier";
            this.btnEvaluateFile.UseVisualStyleBackColor = true;
            this.btnEvaluateFile.Click += new System.EventHandler(this.btnEvaluateFile_Click);
            // 
            // btnSearchEvaluationFile
            // 
            this.btnSearchEvaluationFile.Location = new System.Drawing.Point(847, 329);
            this.btnSearchEvaluationFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchEvaluationFile.Name = "btnSearchEvaluationFile";
            this.btnSearchEvaluationFile.Size = new System.Drawing.Size(165, 28);
            this.btnSearchEvaluationFile.TabIndex = 16;
            this.btnSearchEvaluationFile.Text = "Rechercher un fichier";
            this.btnSearchEvaluationFile.UseVisualStyleBackColor = true;
            this.btnSearchEvaluationFile.Click += new System.EventHandler(this.btnSearchEvaluationFile_Click);
            // 
            // txtEvaluationFile
            // 
            this.txtEvaluationFile.Location = new System.Drawing.Point(327, 335);
            this.txtEvaluationFile.Margin = new System.Windows.Forms.Padding(4);
            this.txtEvaluationFile.Name = "txtEvaluationFile";
            this.txtEvaluationFile.Size = new System.Drawing.Size(512, 22);
            this.txtEvaluationFile.TabIndex = 17;
            // 
            // FormTreeBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 754);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormTreeBuilder";
            this.Text = "FormTreeBuilder";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadTree;
        private System.Windows.Forms.Button btnSearchTree;
        private System.Windows.Forms.TextBox txtLoadTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEpsilon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rb12;
        private System.Windows.Forms.RadioButton rb41;
        private System.Windows.Forms.RadioButton rb31;
        private System.Windows.Forms.RadioButton rb21;
        private System.Windows.Forms.RadioButton rb11;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblTree;
        private System.Windows.Forms.RadioButton rb34;
        private System.Windows.Forms.RadioButton rb23;
        private System.Windows.Forms.RadioButton rb14;
        private System.Windows.Forms.RadioButton rb13;
        private System.Windows.Forms.TextBox txtResultTrainingTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtResultRatio;
        private System.Windows.Forms.TextBox txtResultSuccess;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtResultEntropie;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxResultColumn;
        private System.Windows.Forms.Button btnShowGraph;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnCheckNothing;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnEvaluateFile;
        private System.Windows.Forms.Button btnSearchEvaluationFile;
        private System.Windows.Forms.TextBox txtEvaluationFile;
    }
}