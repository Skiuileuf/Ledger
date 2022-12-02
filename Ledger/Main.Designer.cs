using System.Windows.Forms;

namespace Ledger
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.debitCombo = new Ledger.AutoCompleteCombobox(this.components);
            this.creditCombo = new Ledger.AutoCompleteCombobox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAppendLedger = new System.Windows.Forms.Button();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.txtNotaOperatiei = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ledgerGridView = new System.Windows.Forms.DataGridView();
            this.btnGenerateT = new System.Windows.Forms.Button();
            this.btnGenerateVerification = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnGenerateBalanceSheet = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.debitCombo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.creditCombo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAppendLedger, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.valueBox, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 166);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 74);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Debit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Credit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(519, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Valoare";
            // 
            // debitCombo
            // 
            this.debitCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.debitCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debitCombo.FormattingEnabled = true;
            this.debitCombo.Location = new System.Drawing.Point(3, 18);
            this.debitCombo.Name = "debitCombo";
            this.debitCombo.Size = new System.Drawing.Size(252, 23);
            this.debitCombo.TabIndex = 0;
            // 
            // creditCombo
            // 
            this.creditCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.creditCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creditCombo.FormattingEnabled = true;
            this.creditCombo.Location = new System.Drawing.Point(261, 18);
            this.creditCombo.Name = "creditCombo";
            this.creditCombo.Size = new System.Drawing.Size(252, 23);
            this.creditCombo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "(NUMECONT)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "(NUMECONT)";
            // 
            // btnAppendLedger
            // 
            this.btnAppendLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAppendLedger.Location = new System.Drawing.Point(519, 47);
            this.btnAppendLedger.Name = "btnAppendLedger";
            this.btnAppendLedger.Size = new System.Drawing.Size(254, 24);
            this.btnAppendLedger.TabIndex = 3;
            this.btnAppendLedger.Text = "Adauga la Ledger";
            this.btnAppendLedger.UseVisualStyleBackColor = true;
            this.btnAppendLedger.Click += new System.EventHandler(this.btnAppendLedger_Click);
            // 
            // valueBox
            // 
            this.valueBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueBox.Location = new System.Drawing.Point(519, 18);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(254, 23);
            this.valueBox.TabIndex = 2;
            this.valueBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valueBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Nota Operatiei";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            // 
            // txtNotaOperatiei
            // 
            this.txtNotaOperatiei.Location = new System.Drawing.Point(127, 28);
            this.txtNotaOperatiei.Name = "txtNotaOperatiei";
            this.txtNotaOperatiei.Size = new System.Drawing.Size(661, 23);
            this.txtNotaOperatiei.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Analiza Operatiei";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Formula Contabila";
            // 
            // ledgerGridView
            // 
            this.ledgerGridView.AllowUserToAddRows = false;
            this.ledgerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ledgerGridView.Location = new System.Drawing.Point(12, 246);
            this.ledgerGridView.Name = "ledgerGridView";
            this.ledgerGridView.RowTemplate.Height = 25;
            this.ledgerGridView.Size = new System.Drawing.Size(776, 211);
            this.ledgerGridView.TabIndex = 6;
            // 
            // btnGenerateT
            // 
            this.btnGenerateT.Location = new System.Drawing.Point(414, 463);
            this.btnGenerateT.Name = "btnGenerateT";
            this.btnGenerateT.Size = new System.Drawing.Size(184, 23);
            this.btnGenerateT.TabIndex = 1;
            this.btnGenerateT.Text = "Genereaza T-uri";
            this.btnGenerateT.UseVisualStyleBackColor = true;
            this.btnGenerateT.Click += new System.EventHandler(this.btnGenerateT_Click);
            // 
            // btnGenerateVerification
            // 
            this.btnGenerateVerification.Location = new System.Drawing.Point(604, 463);
            this.btnGenerateVerification.Name = "btnGenerateVerification";
            this.btnGenerateVerification.Size = new System.Drawing.Size(184, 23);
            this.btnGenerateVerification.TabIndex = 2;
            this.btnGenerateVerification.Text = "Genereaza Balanta de Verificare";
            this.btnGenerateVerification.UseVisualStyleBackColor = true;
            this.btnGenerateVerification.Click += new System.EventHandler(this.btnGenerateVerification_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cresc",
            "Scad"});
            this.comboBox1.Location = new System.Drawing.Point(127, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.TabStop = false;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Cresc",
            "Scad"});
            this.comboBox2.Location = new System.Drawing.Point(127, 86);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 10;
            this.comboBox2.TabStop = false;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Active",
            "Capital Propriu",
            "Datorii"});
            this.comboBox3.Location = new System.Drawing.Point(254, 57);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 23);
            this.comboBox3.TabIndex = 11;
            this.comboBox3.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(381, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "=>";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Active",
            "Capital Propriu",
            "Datorii"});
            this.comboBox4.Location = new System.Drawing.Point(254, 86);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 23);
            this.comboBox4.TabIndex = 13;
            this.comboBox4.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(419, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "label10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(419, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 15);
            this.label11.TabIndex = 15;
            this.label11.Text = "label11";
            // 
            // btnGenerateBalanceSheet
            // 
            this.btnGenerateBalanceSheet.Location = new System.Drawing.Point(224, 463);
            this.btnGenerateBalanceSheet.Name = "btnGenerateBalanceSheet";
            this.btnGenerateBalanceSheet.Size = new System.Drawing.Size(184, 23);
            this.btnGenerateBalanceSheet.TabIndex = 16;
            this.btnGenerateBalanceSheet.Text = "Genereaza Bilantul si CPrPi\r\n\r\n";
            this.btnGenerateBalanceSheet.UseVisualStyleBackColor = true;
            this.btnGenerateBalanceSheet.Click += new System.EventHandler(this.btnGenerateBalanceSheet_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.btnGenerateBalanceSheet);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnGenerateVerification);
            this.Controls.Add(this.btnGenerateT);
            this.Controls.Add(this.ledgerGridView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNotaOperatiei);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.Text = "Cartea Mare";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgerGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private AutoCompleteCombobox debitCombo;
        private AutoCompleteCombobox creditCombo;
        private Label label4;
        private Label label5;
        private Label label6;
        private ToolStrip toolStrip1;
        private ToolStripButton newToolStripButton;
        private ToolStripButton openToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton printToolStripButton;
        private TextBox txtNotaOperatiei;
        private Label label7;
        private Label label8;
        private DataGridView ledgerGridView;
        private Button btnGenerateT;
        private Button btnGenerateVerification;
        private Button btnAppendLedger;
        private TextBox valueBox;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Label label9;
        private ComboBox comboBox4;
        private Label label10;
        private Label label11;
        private Timer timer1;
        private Button btnGenerateBalanceSheet;
    }
}