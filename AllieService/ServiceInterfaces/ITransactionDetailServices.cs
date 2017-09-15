using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieService.ServiceInterfaces
{
    public interface ITransactionDetailServices
    {
        IEnumerable<TransactionDetail> GetAll();
        IEnumerable<TransactionDetail> GetAll(int transactionId);
        IEnumerable<TransactionDetail> GetByAccount_IncomeType(int incomeTypeId, int transactionId);
        IEnumerable<TransactionDetail> GetByAccount_ExpenseType(int expenseTypeId, int transactionId);
        IEnumerable<TransactionDetail> GetByAccount_Journal(int journalId, int accountId);
        IEnumerable<TransactionDetail> GetByAccount_Transaction(int transactionId, int accountId, int journalId);
        TransactionDetail Get(int id);
        IEnumerable<int> GetDistinctAccount(int journalId);
        double GetAmount(int id);
        void Insert(TransactionDetail detail);
        void Update(TransactionDetail detail);
        void Delete(int id);
    }
}
