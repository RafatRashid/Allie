using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieEntity
{
    public class TransactionDetail
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public int TransactionType { get; set; }
        public double Amount { get; set; }
    }
}
