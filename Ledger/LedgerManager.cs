using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger
{
    public class LedgerManager
    {
        public class LedgerRecord
        {
            public int Index { get; set; }
            public string NotaOperatiei { get; set; }
            public string AnalizaOperatiei { get; set; }

            //Formula contabila
            public int IdContDebitor { get; set; }
            public int IdContCreditor { get; set; }
            public double Valoare { get; set; }
        }


        //public static List<LedgerRecord> LedgerRecords = new List<LedgerRecord>();
        public static BindingList<LedgerRecord> LedgerRecords = new BindingList<LedgerRecord>();

        public static void CreateLedger(string path)
        {
            var records = new List<LedgerRecord>{};

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }

        public static void OpenLedger(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                IEnumerable<LedgerRecord> records = csv.GetRecords<LedgerRecord>();
                LedgerRecords = new BindingList<LedgerRecord>(records.ToList());
            }
        }

        public static void SaveLedger(string path)
        {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(LedgerRecords);
            }
        }


    }
}
