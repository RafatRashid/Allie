using AllieService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;
using AllieData.DataAccessorInterfaces;

namespace AllieService.Services
{
    class IncomeStatementServices : IIncomeStatementServices
    {
        IIncomeStatementDataAccessor accessor;
        public IncomeStatementServices(IIncomeStatementDataAccessor accessor)
        {
            this.accessor = accessor;
        }

        public void Delete(int id)
        {
            accessor.Delete(id);
        }

        public IncomeStatement Get(int id)
        {
            return accessor.Get(id);
        }

        public IEnumerable<IncomeStatement> GetAll()
        {
            return accessor.GetAll();
        }

        public void Insert(IncomeStatement statement)
        {
            accessor.Insert(statement);
        }

        public void Update(IncomeStatement statement)
        {
            accessor.Update(statement);
        }
    }
}
