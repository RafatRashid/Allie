using System;
using System.Collections.Generic;
using System.Text;

namespace AllieEntity
{
    public class Journal
    {
        public int Id { get; set; }
        public string JournalDescription { get; set; }
        public DateTime JournalPeriod { get; set; }
        public int LedgerId { get; set; }
        public int CompanyId { get; set; }
    }
}
