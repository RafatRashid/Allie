using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieData.DataAccessorInterfaces
{
    public interface IAccountDataAccessor
    {
        IEnumerable<Account> GetAll();
        IEnumerable<Account> GetAll(int companyId);
        Account Get(int id);
        IEnumerable<Account> Get(AccountType type);
        void Insert(Account acc);
        void Update(Account acc);
        void Delete(int id);
        void CashIn(int id, double amount);
        void CashOut(int id, double amount);
    }
}
