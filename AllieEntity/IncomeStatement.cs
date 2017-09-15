using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieEntity
{
    public class IncomeStatement
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Total { get; set; }
        public int CompanyId { get; set; }
    }
}
