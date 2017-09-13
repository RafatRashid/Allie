using System;
using System.Collections.Generic;
using System.Text;

namespace AllieEntity
{
    public class Ledger
    {
        public int Id { get; set; }
        public string LedgerDescription { get; set; }
        public DateTime LedgerPeriod{ get; set; }
        public int CompanyId { get; set; }
    }
}
