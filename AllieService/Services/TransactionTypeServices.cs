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
    class TransactionTypeServices : ITransactionTypeServices
    {
        ITransactionTypeDataAccessor accessor;
        public TransactionTypeServices(ITransactionTypeDataAccessor accessor)
        {
            this.accessor = accessor;
        }

        public void Delete(int id)
        {
            accessor.Delete(id);
        }

        public TransactionType Get(int id)
        {
            return accessor.Get(id);
        }

        public TransactionType Get(string type)
        {
            return accessor.Get(type);
        }
        
        public IEnumerable<TransactionType> GetAll()
        {
            return accessor.GetAll();
        }

        public void Insert(TransactionType tType)
        {
            accessor.Insert(tType);
        }

        public void Update(TransactionType tType)
        {
            accessor.Update(tType);
        }
        
        public TransactionType Get(int accId, bool isSource)
        {
            if (isSource)
            {
                Account acc = ServiceFactory.GetAccountServices().Get(accId);
                AccountType accType = ServiceFactory.GetAccountTypeServices().Get(acc.AccountType);
                string tranType = Decrease(accType.Type);
                return this.Get(tranType);
            }
            else
            {
                Account acc = ServiceFactory.GetAccountServices().Get(accId);
                AccountType accType = ServiceFactory.GetAccountTypeServices().Get(acc.AccountType);
                string tranType = Increase(accType.Type);
                return this.Get(tranType);
            }
            
        }

        private string Increase(string accType)
        {
            const string credit = "Credit";
            const string debit = "Debit";
            switch (accType)
            {
                case "Cash":
                    return debit;
                case "Capital":
                    return credit;
                case "Expense":
                    return debit;
                case "Income":
                    return credit;
                case "Liability":
                    return debit;
                case "Asset":
                    return debit;
            }
            return null;
        }
        private string Decrease(string accType)
        {
            const string credit = "Credit";
            const string debit = "Debit";
            switch (accType)
            {
                case "Cash":
                    return credit;
                case "Capital":
                    return debit;
                case "Expense":
                    return credit;
                case "Income":
                    return debit;
                case "Liability":
                    return credit;
                case "Asset":
                    return credit;
            }
            return null;
        }
    }
}
