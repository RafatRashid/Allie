using AllieData.DataAccessorInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieData.DataAccessors
{
    class AccountDataAccessor: IAccountDataAccessor
    {
        AllieContext context;
        public AccountDataAccessor(AllieContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Account acc = context.Accounts.SingleOrDefault(x => x.AccountId == id);
            context.Accounts.Remove(acc);
            context.SaveChanges();
        }

        public Account Get(int id)
        {
            return context.Accounts.SingleOrDefault(x => x.AccountId == id);
        }

        public IEnumerable<Account> Get(AccountType type)
        {
            return context.Accounts.Where(x => x.AccountType == type.Id).ToList();
        }

        public IEnumerable<Account> GetAll()
        {
            return context.Accounts.ToList();
        }

        public void Insert(Account acc)
        {
            context.Accounts.Add(acc);
            context.SaveChanges();
        }

        public void Update(Account acc)
        {
            Account a = context.Accounts.SingleOrDefault(x => x.AccountId == acc.AccountId);

            a.AccountDescription = acc.AccountDescription;
            a.AccountNumber = acc.AccountNumber;

            context.SaveChanges();
        }
        public void CashIn(int id, double amount)
        {
            context.Accounts.SingleOrDefault(x => x.AccountId == id).Amount += amount;
        }

        public bool CashOut(int id, double amount)
        {
            Account acc = context.Accounts.SingleOrDefault(x => x.AccountId == id);
            if (acc.Amount - amount > 0)
            { 
                acc.Amount -= amount;
                return true;
            }
            else
                return false;
        }

    }
}
