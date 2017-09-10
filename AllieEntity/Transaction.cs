using System;
using System.Collections.Generic;
using System.Text;

namespace AllieEntity
{
    public class Transaction
    {
        public int Id { get; set; }
        public string TransactionDescription { get; set; }
        public double TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int JournalId { get; set; }
    }
}
