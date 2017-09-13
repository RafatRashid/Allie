using AllieData.DataAccessorInterfaces;
using AllieService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieService.Services
{
    class TransactionDetailServices: ITransactionDetailServices
    {
        ITransactionDetailDataAccessor accessor;
        public TransactionDetailServices(ITransactionDetailDataAccessor accessor)
        {
            this.accessor = accessor;
        }

        public IEnumerable<int> GetDistinctAccount(int journalId)
        {
            return accessor.GetDistinctAccount(journalId);
        }

        public void Delete(int id)
        {
            accessor.Delete(id);
        }

        public TransactionDetail Get(int id)
        {
            return accessor.Get(id);
        }

        public IEnumerable<TransactionDetail> GetAll()
        {
            return accessor.GetAll();
        }

        public IEnumerable<TransactionDetail> GetAll(int transactionId)
        {
            return accessor.GetAll(transactionId);
        }

        public double GetAmount(int id)
        {
            return accessor.GetAmount(id);
        }

        public void Insert(TransactionDetail detail)
        {
            accessor.Insert(detail);
        }

        public void Update(TransactionDetail detail)
        {
            accessor.Update(detail);
        }

        public IEnumerable<TransactionDetail> GetByAccount_Journal(int journalId, int accountId)
        {
            return accessor.GetByAccount_Journal(journalId, accountId);
        }

        public IEnumerable<TransactionDetail> GetByAccount_Transaction(int transactionId, int accountId, int journalId)
        {
            return accessor.GetByAccount_Transaction(transactionId, accountId, journalId);
        }
    }
}
