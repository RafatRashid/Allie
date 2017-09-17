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

        public IEnumerable<Transaction> GetAll(int companyId, DateTime period)
        {
            return context.Transactions.Where
                (x => x.CompanyId == companyId 
                && x.TransactionDate.Month == period.Month 
                && x.TransactionDate.Year == period.Year)
                .ToList();
        }

        public IEnumerable<Transaction> GetAllByPeriodInterval(int companyId, DateTime startPeriod, DateTime endPeriod)
        {
            return context.Transactions.Where(x => (x.CompanyId == companyId) &&
                        (x.TransactionDate.Month >= startPeriod.Month && x.TransactionDate.Month <= endPeriod.Month) &&
                        (x.TransactionDate.Year >= startPeriod.Year && x.TransactionDate.Year <= endPeriod.Year)).ToList();
        }

        public IEnumerable<Transaction> GetByJournal(int journalId)
        {
            return context.Transactions.Where(x => x.JournalId == journalId).ToList();
        }

        public IEnumerable<DateTime> GetDistinctDates(int companyId)
        {
            List<Transaction> t = context.Transactions.Where(x => x.CompanyId == companyId).ToList();

            List<DateTime> DistinctYearMonths = t
                                .Select(p => new { p.TransactionDate.Year, p.TransactionDate.Month })
                                .Distinct()
                                .ToList()
                                .Select(x => new DateTime(x.Year, x.Month, 1)).ToList();
            return DistinctYearMonths;
        }

        public void Insert(Transaction tran)
        {
            context.Transactions.Add(tran);
            context.SaveChanges();
        }

        public void Update(Transaction tran)
        {
            Transaction t = context.Transactions.SingleOrDefault(x => x.Id == tran.Id);
            
            t.TransactionDescription = tran.TransactionDescription;
            t.JournalId = tran.JournalId;

            context.SaveChanges();
        }
    }
}
