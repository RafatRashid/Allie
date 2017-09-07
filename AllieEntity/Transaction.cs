using System;
using System.Collections.Generic;
using System.Text;

namespace AllieEntity
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public double TransactionAmount { get; set; }
        public int TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public double PreviousBalance { get; set; }
        public double PresentBalance { get; set; }
        public int AccountId { get; set; }
        public int JournalId { get; set; }
    }
}
