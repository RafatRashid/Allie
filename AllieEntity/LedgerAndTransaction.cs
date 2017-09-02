using System;
using System.Collections.Generic;
using System.Text;

namespace AllieEntity
{
    public class LedgerAndTransaction
    {
        public int LedgerCode { get; set; }
        public int TransactionCode { get; set; }
        public float Amount { get; set; }
        public string Type { get;  set; }
    }
}
