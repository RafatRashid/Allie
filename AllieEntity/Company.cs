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
        public double TotalRevenue { get; set; }
        public double TotalExpense { get; set; }
        public double Profit { get; set; }
    }
}
