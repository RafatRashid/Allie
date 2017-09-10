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

        public TransactionType Get(int accountType, bool isSource)
        {
            if (isSource)
            {
                string tranType = Decrease(ServiceFactory.GetAccountTypeServices().Get(accountType).Type);
                return this.Get(tranType);
            }
            else
            {
                string tranType = Increase(ServiceFactory.GetAccountTypeServices().Get(accountType).Type);
                return this.Get(tranType);
            }
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

        private string Increase(string accType)
        {
            const string credit = "Credit";
            const string debit = "Debit";

            switch (accType)
            {
                case "Capital":
                    return credit;
                case "Expense":
                    return debit;
                case "Income":
                    return credit;
                case "Liability":
                    return credit;
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
                case "Capital":
                    return debit;
                case "Expense":
                    return credit;
                case "Income":
                    return debit;
                case "Liability":
                    return debit;
                case "Asset":
                    return credit;
            }
            return null;
        }
    }
}
