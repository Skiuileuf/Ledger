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

        //BindingList<LedgerManager.LedgerRecord> LdgrRcrdsBindingList = new BindingList<LedgerManager.LedgerRecord>();

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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
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

            //foreach(LedgerManager.LedgerRecord lr in LedgerManager.LedgerRecords)
            //{
            //    LdgrRcrdsBindingList.Add(lr);
            //}
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
            debitCombo.SelectedIndex = 0;
            creditCombo.SelectedIndex = 0;
            valueBox.Text = "";
        }

        private void btnGenerateT_Click(object sender, EventArgs e)
        {
            //Gaseste toate conturile unice
            //Pentru fiecare cont genereaza o foaie

            //Suma se adauga la contul debitor pe coloana debit
            //Suma se adauga la contul creditor pe coloana credit
            //Se calculeaza rulajul debitor/creditor
            //Se calculeaza total sume debitoare/creditoare
            //Se calculeaza sold fimal debitor/creditor si se pune pe coloana opusa naturii sale

            //Pentru validare - se aduna toate valorile credit cu toate valorile debit, daca sumele sunt diferite datele nu sunt valide (elementul lipsa are jumate din valoarea diferentei)
            //Se umple o foaie cu datele rezultate.

            Dictionary<int, LedgerManager.LedgerRecord> Turi = new Dictionary<int, LedgerManager.LedgerRecord>();

            foreach(LedgerManager.OperationRecord or in LedgerManager.OperationRecords)
            {
                LedgerManager.LedgerRecord? ContDebitor = null;
                LedgerManager.LedgerRecord? ContCreditor = null;

                if (!Turi.ContainsKey(or.IdContDebitor))
                {
                    ContDebitor = new LedgerManager.LedgerRecord() {
                        IdCont = or.IdContDebitor,
                        NumeCont = AccountsManager.Accounts.Find(cont => cont.Id == or.IdContDebitor).Nume,
                        eContDebitor = AccountsManager.Accounts.Find(cont => cont.Id == or.IdContDebitor).Intrari == "C" ? true : false,
                    };
                    Turi.Add(or.IdContDebitor, ContDebitor);
                } else
                {
                    ContDebitor = Turi[or.IdContDebitor];
                }

                if (!Turi.ContainsKey(or.IdContCreditor))
                {
                    ContCreditor = new LedgerManager.LedgerRecord()
                    {
                        IdCont = or.IdContCreditor,
                        NumeCont = AccountsManager.Accounts.Find(cont => cont.Id == or.IdContCreditor).Nume,
                        eContDebitor = AccountsManager.Accounts.Find(cont => cont.Id == or.IdContCreditor).Intrari == "C" ? true : false,
                    };
                    Turi.Add(or.IdContCreditor, ContCreditor);
                } else
                {
                    ContCreditor = Turi[or.IdContCreditor];
                }

                //FIXME SA STIE AUTOMAT DACA SOLDUL INITIAL E DEBIT SAU CREDIT
                if (or.IdContCreditor == 0 || or.IdContDebitor == 0) //Sold initial
                {
                    if (or.IdContDebitor != 0) ContDebitor.Debit.SoldInitial = or.Valoare;
                    if (or.IdContCreditor != 0) ContCreditor.Credit.SoldInitial = or.Valoare;

                } //FIXME: daca e sold initial
                else
                {
                    //ContDebitor.Debit.Rulaj.Add(or.Valoare);
                    //ContCreditor.Credit.Rulaj.Add(or.Valoare);
                    ContDebitor.Debit.Rulaj.Add(or.Index, or.Valoare);
                    ContCreditor.Credit.Rulaj.Add(or.Index, or.Valoare);
                }
            }


            

            LedgerManager.LedgerModel model = new LedgerManager.LedgerModel
            {
                Accounts = Turi.Values.ToList(),
                OperationRecords = LedgerManager.OperationRecords.ToList()

            };

            
            var document = DocumentFactory.Create("ledger.cs.docx", model);

            document.Generate("ledger.docx");

            MessageBox.Show("GATA GENERAREA");

            //MessageBox.Show(Turi.Count().ToString());
            //MessageBox.Show(Turi[401].ToString());
        }
    }
}