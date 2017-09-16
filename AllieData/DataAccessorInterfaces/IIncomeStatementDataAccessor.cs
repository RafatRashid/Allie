using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieData.DataAccessorInterfaces
{
    public interface IIncomeStatementDataAccessor
    {
        IEnumerable<IncomeStatement> GetAll();
        IEnumerable<IncomeStatement> GetAll(int companyId);
        IncomeStatement Get(int id);
        IncomeStatement Get(DateTime start, DateTime end);
        void Insert(IncomeStatement statement);
        void Update(IncomeStatement statement);
        void Delete(int id);
    }
}
