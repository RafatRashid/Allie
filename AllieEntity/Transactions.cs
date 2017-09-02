using System;
using System.Collections.Generic;
using System.Text;

namespace AllieEntity
{
    public class Transactions
    {
        public int TransactionID { get; set; }
        public float TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionCategory { get; set; }
    }
}
