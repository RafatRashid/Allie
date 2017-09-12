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
            Account acc = context.Accounts.SingleOrDefault(x => x.Id == id);
            context.Accounts.Remove(acc);
            context.SaveChanges();
        }

        public Account Get(int id)
        {
            return context.Accounts.SingleOrDefault(x => x.Id == id);
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
            Account a = context.Accounts.SingleOrDefault(x => x.Id == acc.Id);

            a.AccountDescription = acc.AccountDescription;
            a.AccountNumber = acc.AccountNumber;
            a.AccountType = acc.AccountType;
            a.Amount = acc.Amount;

            context.SaveChanges();
        }
        public void CashIn(int id, double amount)
        {
            context.Accounts.SingleOrDefault(x => x.Id == id).Amount += amount;
            context.SaveChanges();
        }

        public void CashOut(int id, double amount)
        {
            context.Accounts.SingleOrDefault(x => x.Id == id).Amount -= amount;
            context.SaveChanges();
        }

        public IEnumerable<Account> GetAll(int companyId)
        {
            return context.Accounts.Where(x => x.CompanyId == companyId).ToList();
        }
    }
}
