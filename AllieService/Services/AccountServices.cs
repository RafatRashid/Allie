using AllieData.DataAccessorInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieService.Services
{
    class AccountServices : IAccountServices
    {
        IAccountDataAccessor accessor;
        public AccountServices(IAccountDataAccessor accessor)
        {
            this.accessor = accessor;
        }

        public void CashIn(int id, double amount)
        {
            accessor.CashIn(id, amount);
        }

        public bool CashOut(int id, double amount)
        {
            return accessor.CashOut(id, amount);
        }

        public void Delete(int id)
        {
            accessor.Delete(id);
        }

        public Account Get(int id)
        {
            return accessor.Get(id);
        }

        public IEnumerable<Account> Get(AccountType type)
        {
            return accessor.Get(type);
        }

        public IEnumerable<Account> GetAll()
        {
            return accessor.GetAll();
        }

        public void Insert(Account acc)
        {
            accessor.Insert(acc);
        }

        public void Update(Account acc)
        {
            accessor.Update(acc);
        }
    }
}
