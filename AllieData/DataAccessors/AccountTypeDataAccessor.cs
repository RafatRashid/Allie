using AllieData.DataAccessorInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieData.DataAccessors
{
    class AccountTypeDataAccessor : IAccountTypeDataAccessor
    {
        AllieContext context;
        public AccountTypeDataAccessor(AllieContext context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            AccountType accType = context.AccountTypes.SingleOrDefault(x => x.Id == id);
            context.AccountTypes.Remove(accType);
            context.SaveChanges();
        }

        public AccountType Get(int id)
        {
            return context.AccountTypes.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<AccountType> GetAll()
        {
            return context.AccountTypes.ToList();
        }

        public void Insert(AccountType accType)
        {
            context.AccountTypes.Add(accType);
            context.SaveChanges();
        }

        public void Update(AccountType accType)
        {
            AccountType acc = context.AccountTypes.SingleOrDefault(x => x.Id == accType.Id);

            acc.Type = accType.Type;

            context.SaveChanges();
        }
    }
}
