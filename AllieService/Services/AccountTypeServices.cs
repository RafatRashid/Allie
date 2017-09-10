using AllieData.DataAccessorInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;
using AllieService.ServiceInterfaces;

namespace AllieService.Services
{
    class AccountTypeServices : IAccountTypeServices
    {
        IAccountTypeDataAccessor accessor;
        public AccountTypeServices(IAccountTypeDataAccessor accessor)
        {
            this.accessor = accessor;
        }

        public void Delete(int id)
        {
            accessor.Delete(id);
        }

        public AccountType Get(int id)
        {
            return accessor.Get(id);
        }

        public IEnumerable<AccountType> GetAll()
        {
            return accessor.GetAll();
        }

        public void Insert(AccountType accType)
        {
            accessor.Insert(accType);
        }

        public void Update(AccountType accType)
        {
            accessor.Update(accType);
        }
    }
}
