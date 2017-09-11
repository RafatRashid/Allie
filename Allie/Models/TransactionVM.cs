using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Allie.Models
{
    public class TransactionVM
    {
        public int AccountId { get; set; }
        public int TransactionType { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}