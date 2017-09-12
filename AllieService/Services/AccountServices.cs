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

        public void CashOut(int id, double amount)
        {
            accessor.CashOut(id, amount);
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

        public IEnumerable<Account> GetAll(int companyId)
        {
            return accessor.GetAll(companyId);
        }

        public string GetRollBackAction(int accId, string tranType)
        {
            Account acc = this.Get(accId);
            string accType = ServiceFactory.GetAccountTypeServices().Get(acc.AccountType).Type;
            
            if (tranType == "Credit")
            {
                return GetAction_Credit(accType);
            }
            else
                return GetAction_Debit(accType);
        }

        private string GetAction_Debit(string accType)
        {
            const string increase = "Increase";
            const string decrease = "Decrease";
            switch (accType)
            {
                case "Cash":
                    return decrease;
                case "Capital":
                    return increase;
                case "Expense":
                    return decrease;
                case "Income":
                    return increase;
                case "Liability":
                    return increase;
                case "Asset":
                    return decrease;
            }
            return null;
        }

        private string GetAction_Credit(string accType)
        {
            const string increase = "Increase";
            const string decrease = "Decrease";
            switch (accType)
            {
                case "Cash":
                    return increase;
                case "Capital":
                    return decrease;
                case "Expense":
                    return increase;
                case "Income":
                    return decrease;
                case "Liability":
                    return decrease;
                case "Asset":
                    return increase;
            }
            return null;
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
