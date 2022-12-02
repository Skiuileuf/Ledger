using SharpDocx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Ledger
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AccountsManager.LoadAccountsFromDisk();

            foreach(AccountsManager.Account ac in AccountsManager.Accounts)
            {
                string fmt = $"{ac.Id} : {ac.Nume}";
                debitCombo.Items.Add(fmt);
                creditCombo.Items.Add(fmt);
            }

            ledgerGridView.DataSource = LedgerManager.OperationRecords;
        }

        private void valueBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && (((TextBox)sender).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Comma Separated Values|*.csv", Multiselect = false })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    this.Text = $"Ledger | {ofd.FileName}";
                    LedgerManager.OpenLedger(ofd.FileName);
                }
            }

            ledgerGridView.DataSource = LedgerManager.OperationRecords;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Comma Separated Values|*.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //this.Text = $"Ledger | {sfd.FileName}";
                    LedgerManager.SaveLedger(sfd.FileName);
                }
            }

            ledgerGridView.DataSource = LedgerManager.OperationRecords;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog sfd = new SaveFileDialog() { Filter = "Comma Separated Values|*.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //this.Text = $"Ledger | {sfd.FileName}";
                    LedgerManager.CreateLedger(sfd.FileName);
                }
            }

            ledgerGridView.DataSource = LedgerManager.OperationRecords;
        }

        private void btnAppendLedger_Click(object sender, EventArgs e)
        {
            LedgerManager.OperationRecord record = new LedgerManager.OperationRecord()
            {
                Index = LedgerManager.OperationRecords.Count() + 1,
                NotaOperatiei = txtNotaOperatiei.Text,
                AnalizaOperatiei = "STUB Analiza Operatiei",
                IdContDebitor = int.Parse(debitCombo.Text.Split(':')[0].Trim()),
                IdContCreditor = int.Parse(creditCombo.Text.Split(':')[0].Trim()),
                Valoare = double.Parse(valueBox.Text)
            };

            LedgerManager.OperationRecords.Add(record);

            //Reset fields
            txtNotaOperatiei.Text = "";
            //debitCombo.SelectedIndex = 0;
            debitCombo.Text = "";
            //creditCombo.SelectedIndex = 0;
            creditCombo.Text = "";
            valueBox.Text = "";

            txtNotaOperatiei.Focus();
        }

        private void btnGenerateT_Click(object sender, EventArgs e)
        {
            //Gaseste toate conturile unice
            //Pentru fiecare cont genereaza un tabel

            //Suma se adauga la contul debitor pe coloana debit
            //Suma se adauga la contul creditor pe coloana credit
            //Se calculeaza rulajul debitor/creditor
            //Se calculeaza total sume debitoare/creditoare
            //Se calculeaza sold fimal debitor/creditor si se pune pe coloana opusa naturii sale

            //Pentru validare - se aduna toate valorile credit cu toate valorile debit, daca sumele sunt diferite datele nu sunt valide (elementul lipsa are jumate din valoarea diferentei)
            //Se umple o foaie cu datele rezultate.

            Dictionary<int, LedgerManager.LedgerRecord> Conturi = LedgerManager.ProcessLedgerRecords();
            LedgerManager.LedgerModel model = new LedgerManager.LedgerModel
            {
                Accounts = Conturi.Values.ToList(),
                OperationRecords = LedgerManager.OperationRecords.ToList()

            };

            var document = DocumentFactory.Create("ledger.cs.docx", model);
            document.Generate("ledger.docx");
            MessageBox.Show("GATA GENERAREA");

        }

        private void btnGenerateVerification_Click(object sender, EventArgs e)
        {
            Dictionary<int, LedgerManager.LedgerRecord> Conturi = LedgerManager.ProcessLedgerRecords();
            var document = DocumentFactory.Create("balanta-verificare.cs.docx", Conturi.Values.ToList());
            document.Generate("balanta-verificare.docx");
            MessageBox.Show("GATA GENERAREA");
        }

        private void btnGenerateBalanceSheet_Click(object sender, EventArgs e)
        {

        }
    }
}