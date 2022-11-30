using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger
{
    public class AccountsManager
    {
        public class Account
        {
            public int Id { get; set; }
            public string? Nume { get; set; }
            public string? IncadrareCont { get; set; }
            public string? CategorieBilant { get; set; }
            public string? SubcategorieBilant { get; set; }
            public string? Intrari { get; set; }
            public string? Bilant { get; set; }
        }

        internal static List<Account> Accounts = new List<Account>();

        internal static void LoadAccountsFromDisk()
        {
            using (var reader = new StreamReader("lookup-conturi.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                IEnumerable<Account> records = csv.GetRecords<Account>();
                Accounts = records.ToList();
                Accounts.Insert(0, new Account() { Id = 0, Nume = "Sold Initial" });
            }
        }
    }
}
