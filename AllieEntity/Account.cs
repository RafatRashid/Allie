using System;
using System.Collections.Generic;
using System.Text;

namespace AllieEntity
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountDescription { get; set; }
        public float Amount { get; set; }
        public int AccountType { get; set; }
        public int CompanyId { get; set; }
    }
}