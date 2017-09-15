using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieData.DataAccessorInterfaces;
using AllieEntity;

namespace AllieData.DataAccessors
{
    class TransactionDetailDataAccessor : ITransactionDetailDataAccessor
    {
        AllieContext context;
        public TransactionDetailDataAccessor(AllieContext context)
        {
            this.context = context;
        }

        public IEnumerable<int> GetDistinctAccount(int journalId)
        {
            return context.TransactionDetails.Where(x => x.JournalId == journalId).Select(x => x.AccountId).Distinct().ToList();
        }
        
        public void Delete(int id)
        {
            TransactionDetail detail = context.TransactionDetails.SingleOrDefault(x => x.Id == id);
            context.TransactionDetails.Remove(detail);
            context.SaveChanges();
        }

        public TransactionDetail Get(int id)
        {
            return context.TransactionDetails.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<TransactionDetail> GetAll()
        {
            return context.TransactionDetails.ToList();
        }

        public IEnumerable<TransactionDetail> GetAll(int transactionId)
        {
            return context.TransactionDetails.Where(x => x.TransactionId == transactionId).ToList();
        }

        public double GetAmount(int id)
        {
            return context.TransactionDetails.SingleOrDefault(x => x.Id == id).Amount;
        }

        public void Insert(TransactionDetail detail)
        {
            context.TransactionDetails.Add(detail);
            context.SaveChanges();
        }

        public void Update(TransactionDetail detail)
        {
            TransactionDetail a = context.TransactionDetails.SingleOrDefault(x => x.Id == detail.Id);

            a.TransactionId = detail.TransactionId;
            a.TransactionType = detail.TransactionType;
            a.Amount = detail.Amount;
            a.AccountId = detail.AccountId;
            a.JournalId = detail.JournalId;

            context.SaveChanges();
        }

        public IEnumerable<TransactionDetail> GetByAccount_Journal(int journalId, int accountId)
        {
            return context.TransactionDetails.Where(x => x.JournalId == journalId && x.AccountId == accountId).ToList();
        }

        public IEnumerable<TransactionDetail> GetByAccount_Transaction(int transactionId, int accountId, int journalId)
        {
            return context.TransactionDetails.Where(x => x.TransactionId == transactionId && x.AccountId == accountId && x.JournalId == journalId).ToList();
        }

        public IEnumerable<TransactionDetail> GetByAccount_IncomeType(int incomeTypeId, int transactionId)
        {
            List<TransactionDetail> detailList = new List<TransactionDetail>();
            List<TransactionDetail> returnList = new List<TransactionDetail>();

            detailList =  context.TransactionDetails.Where(x => x.TransactionId == transactionId).ToList();
            
            foreach(TransactionDetail d in detailList)
            {
                Account a = context.Accounts.SingleOrDefault(x => (x.AccountType == incomeTypeId) &&
                                                             x.Id == d.AccountId);
                if (a != null)
                    returnList.Add(d);
            }
            return returnList;
        }

        public IEnumerable<TransactionDetail> GetByAccount_ExpenseType(int expenseTypeId, int transactionId)
        {
            List<TransactionDetail> detailList = new List<TransactionDetail>();
            List<TransactionDetail> returnList = new List<TransactionDetail>();

            detailList = context.TransactionDetails.Where(x => x.TransactionId == transactionId).ToList();

            foreach (TransactionDetail d in detailList)
            {
                Account a = context.Accounts.SingleOrDefault(x => (x.AccountType == expenseTypeId) &&
                                                             x.Id == d.AccountId);
                if (a != null)
                    returnList.Add(d);
            }
            return returnList;
        }
    }
}
