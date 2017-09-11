using AllieData.DataAccessorInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieData.DataAccessors
{
    class TransactionDataAccessor : ITransactionDataAccessor
    {
        AllieContext context;
        public TransactionDataAccessor(AllieContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Transaction t = context.Transactions.SingleOrDefault(x => x.Id == id);
            context.Transactions.Remove(t);
            context.SaveChanges();
        }

        public Transaction Get(int id)
        {
            return context.Transactions.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return context.Transactions.ToList();
        }

        public IEnumerable<Transaction> GetAll(int companyId)
        {
            return context.Transactions.Where(x => x.CompanyId == companyId).ToList();
        }

        public void Insert(Transaction tran)
        {
            context.Transactions.Add(tran);
            context.SaveChanges();
        }

        public void Update(Transaction tran)
        {
            Transaction t = context.Transactions.SingleOrDefault(x => x.Id == tran.Id);

            t.TransactionAmount = tran.TransactionAmount;
            t.TransactionDate = tran.TransactionDate;
            t.TransactionDescription = tran.TransactionDescription;
            t.JournalId = tran.JournalId;

            context.SaveChanges();
        }
    }
}
