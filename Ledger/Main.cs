using System.ComponentModel;

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

            ledgerGridView.DataSource = LedgerManager.LedgerRecords;
        }

        private void valueBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
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

            ledgerGridView.DataSource = LedgerManager.LedgerRecords;

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

            ledgerGridView.DataSource = LedgerManager.LedgerRecords;
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

            ledgerGridView.DataSource = LedgerManager.LedgerRecords;
        }

        private void btnAppendLedger_Click(object sender, EventArgs e)
        {
            LedgerManager.LedgerRecord record = new LedgerManager.LedgerRecord()
            {
                Index = LedgerManager.LedgerRecords.Count(),
                NotaOperatiei = txtNotaOperatiei.Text,
                AnalizaOperatiei = "STUB Analiza Operatiei",
                IdContDebitor = int.Parse(debitCombo.Text.Split(':')[0].Trim()),
                IdContCreditor = int.Parse(creditCombo.Text.Split(':')[0].Trim()),
                Valoare = double.Parse(valueBox.Text)
            };

            LedgerManager.LedgerRecords.Add(record);
        }

        private void btnGenerateT_Click(object sender, EventArgs e)
        {

        }
    }
}