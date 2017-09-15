using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieService.ServiceInterfaces
{
    public interface IIncomeStatementServices
    {
        IEnumerable<IncomeStatement> GetAll();
        IncomeStatement Get(int id);
        void Insert(IncomeStatement statement);
        void Update(IncomeStatement statement);
        void Delete(int id);
    }
}
