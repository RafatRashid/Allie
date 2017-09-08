using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieData.DataAccessorInterfaces
{
    public interface IAccountTypeServices
    {
        IEnumerable<AccountType> GetAll();
        AccountType Get(int id);
        void Insert(AccountType accType);
        void Update(AccountType accType);
        void Delete(int id);
    }
}
