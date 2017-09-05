using System;
using System.Collections.Generic;
using System.Text;

namespace AllieEntity
{
    public class Ledger
    {
        public int LedgerId { get; set; }
        public string LedgerName { get; set; }
        public DateTime LedgerPeriod{ get; set; }
        public int  JournalId { get; set; }
    }
}
