using SharpDocx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
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
            //If the input char is not a control char (especially backspace), a digit or the decimal separator, "eat" the input
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

        string OpenFilePath = string.Empty;
        bool FileWasModified = false;

        private void UpdateFormTitle()
        {
            this.Text = $"Ledger | {(OpenFilePath == String.Empty ? "No file open": OpenFilePath )} {(FileWasModified? "" : " *")}";
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Comma Separated Values|*.csv", Multiselect = false })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    OpenFilePath = ofd.FileName;
                    LedgerManager.OpenLedger(OpenFilePath);
                } else
                {
                    //File was not opened

                }
            }

            UpdateFormTitle();
            ledgerGridView.DataSource = LedgerManager.OperationRecords;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (OpenFilePath == string.Empty) //If the file has not been saved yet
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Comma Separated Values|*.csv" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        OpenFilePath = sfd.FileName;
                        LedgerManager.SaveLedger(OpenFilePath);
                    }
                }
            } else //A previous version of the file has been saved
            {
                LedgerManager.SaveLedger(OpenFilePath);
            }

            UpdateFormTitle();
            ledgerGridView.DataSource = LedgerManager.OperationRecords;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFilePath = string.Empty; //Mark the file as unsaved yet
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
            //Cheap data validation
            try
            {
                LedgerManager.OperationRecord record = new LedgerManager.OperationRecord()
                {
                    Index = LedgerManager.OperationRecords.Count + 1,
                    NotaOperatiei = txtNotaOperatiei.Text,
                    AnalizaOperatiei = "STUB Analiza Operatiei",
                    IdContDebitor = int.Parse(debitCombo.Text.Split(':')[0].Trim()),
                    IdContCreditor = int.Parse(creditCombo.Text.Split(':')[0].Trim()),
                    Valoare = double.Parse(valueBox.Text)
                };

                LedgerManager.OperationRecords.Add(record);

                FileWasModified = true;
                UpdateFormTitle();

                //Reset fields
                txtNotaOperatiei.Text = string.Empty;
                debitCombo.Text = string.Empty;
                creditCombo.Text = string.Empty;
                valueBox.Text = string.Empty;

                txtNotaOperatiei.Focus();
            } catch (Exception ex)
            {
                SystemSounds.Beep.Play();
                statusLabel.Text = $"{ex.Message} ({ex.Source})";
            }
        }

        private void btnGenerateT_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerGenerateT.IsBusy)
            {
                backgroundWorkerGenerateT.RunWorkerAsync();
            }
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FileWasModified)
            {
                string title = "Salvezi modificarile?";
                string message = "Modificarile facute la fisierul deschis inca nu au fost salvate.";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                switch (MessageBox.Show(title, message, buttons))
                {
                    case DialogResult.Yes:
                        //Save file and close
                        break;
                    case DialogResult.No:

                        //Just close
                        break;
                    case DialogResult.Cancel:
                        //Cancel closing the form
                        e.Cancel = true;
                        break;
                    default:
                        //Invalid, nu ar trebui sa apara vreodata
                        break;
                }
            } else
            {
                //Just exit
            }
        }

        void ReportProgressUpdate(int progress, string description)
        {
            backgroundWorkerGenerateT.ReportProgress(progress);
            statusLabel.Text = description;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerGenerateT_DoWork(object sender, DoWorkEventArgs e)
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
            ReportProgressUpdate(0, "Starting generating");
            Dictionary<int, LedgerManager.LedgerRecord> Conturi = LedgerManager.ProcessLedgerRecords();
            ReportProgressUpdate(33, "Process accounts");
            LedgerManager.LedgerModel model = new LedgerManager.LedgerModel
            {
                Accounts = Conturi.Values.ToList(),
                OperationRecords = LedgerManager.OperationRecords.ToList()

            };

            ReportProgressUpdate(50, "Load document template");
            var document = DocumentFactory.Create("ledger.cs.docx", model);
            ReportProgressUpdate(66, "Fill document template");
            document.Generate("ledger.docx");
            ReportProgressUpdate(100, "Done (took n ms)");
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SystemSounds.Exclamation.Play();
            this.FlashNotification();
        }
    }
}
