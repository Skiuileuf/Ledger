﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger
{
    public class LedgerManager
    {
        public class LedgerModel
        {
            public List<OperationRecord> OperationRecords = new List<OperationRecord>();
            public List<LedgerRecord> Accounts = new List<LedgerRecord>();

            public bool Validate()
            {
                return true;
            }

            public class RecordRow
            {
                public int debitRecordId;
                //public string debitDesc;
                public double debitValue;
                public int creditRecordId;
                //public string creditDesc;
                public double creditValue;
            }
            public List<RecordRow> GenerateRecordRows(int accountIndex)
            {
                List<RecordRow> result = new List<RecordRow>();
                LedgerRecord account = Accounts.Find(rec => rec.IdCont == accountIndex);

                int debitCount = account.Debit.Rulaj.Count();
                int creditCount = account.Credit.Rulaj.Count();

                int size = Math.Min(debitCount, creditCount);
                int delta = Math.Abs(debitCount - creditCount);

                for(int i = 0; i < size; i++)
                {
                    result.Add(new RecordRow() { 
                        debitRecordId = account.Debit.Rulaj.Keys.ElementAt(i),
                        debitValue = account.Debit.Rulaj.Values.ElementAt(i),
                        creditRecordId = account.Credit.Rulaj.Keys.ElementAt(i),
                        creditValue = account.Credit.Rulaj.Values.ElementAt(i)
                    });
                }

                if (debitCount > creditCount)
                {
                    for (int i = size; i < size + delta; i++)
                    {
                        result.Add(new RecordRow()
                        {
                            debitRecordId = account.Debit.Rulaj.Keys.ElementAt(i),
                            debitValue = account.Debit.Rulaj.Values.ElementAt(i),
                            creditRecordId = 0,
                            creditValue = 0
                        });
                    }
                } else if (creditCount > debitCount)
                {
                    for (int i = size; i < size + delta; i++)
                    {
                        result.Add(new RecordRow()
                        {
                            debitRecordId = 0,
                            debitValue = 0,
                            creditRecordId = account.Credit.Rulaj.Keys.ElementAt(i),
                            creditValue = account.Credit.Rulaj.Values.ElementAt(i)
                        });
                    }
                }


                return result;
            }
        }

        public class OperationRecord
        {
            public int Index { get; set; }
            public string? NotaOperatiei { get; set; }
            public string? AnalizaOperatiei { get; set; }

            //Formula contabila
            public int IdContDebitor { get; set; }
            public int IdContCreditor { get; set; }
            public double Valoare { get; set; }
        }


        //public static List<LedgerRecord> LedgerRecords = new List<LedgerRecord>();
        public static BindingList<OperationRecord> OperationRecords = new BindingList<OperationRecord>();

        public static void CreateLedger(string path)
        {
            var records = new List<OperationRecord>{};

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
                IEnumerable<OperationRecord> records = csv.GetRecords<OperationRecord>();
                OperationRecords = new BindingList<OperationRecord>(records.ToList());
            }
        }

        public static void SaveLedger(string path)
        {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(OperationRecords);
            }
        }

        public class LedgerColumn
        {
            public double SoldInitial;
            //public List<double> Rulaj = new List<double>();
            public Dictionary<int, double> Rulaj = new Dictionary<int, double>();
            public double TotalSume;
        }

        public class LedgerRecord
        {
            public enum TSF
            {
                Debitor,
                Creditor
            }
            public int IdCont;
            public string? NumeCont;
            public bool eContDebitor;
            public LedgerColumn Debit = new LedgerColumn();
            public LedgerColumn Credit = new LedgerColumn();

            public double RulajDebitor { get => Debit.Rulaj.Values.Sum(); }
            public double RulajCreditor { get => Credit.Rulaj.Values.Sum(); }
            public double TotalSoldDebitor { get => RulajDebitor + Debit.SoldInitial; }
            public double TotalSoldCreditor { get => RulajCreditor + Credit.SoldInitial; }
            public double SoldFinal { get => Math.Abs(TotalSoldDebitor - TotalSoldCreditor); }
            public TSF TipSoldFinal { get => Math.Sign(TotalSoldDebitor - TotalSoldCreditor) == -1 ? TSF.Creditor : TSF.Debitor; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Contul {IdCont} cu numele \"{NumeCont}\"");
                sb.AppendLine($"Rulaj Debitor {RulajDebitor} ; Rulaj Creditor {RulajCreditor}");
                sb.AppendLine($"Total Sold Debitor {TotalSoldDebitor}; Total Sold Creditor {TotalSoldCreditor}");
                sb.AppendLine($"Sold Final {SoldFinal} de tip {TipSoldFinal}");
                return sb.ToString();
            }
        }
    }
}
