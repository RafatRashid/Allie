using System;
using System.Collections.Generic;
using System.Text;

namespace AllieEntity
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public float TotalRevenue { get; set; }
        public float TotalExpense { get; set; }
        public float Profit { get; set; }
    }
}
