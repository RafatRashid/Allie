using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieData.DataAccessorInterfaces
{
    public interface ITransactionDetailDataAccessor
    {
        IEnumerable<TransactionDetail> GetAll();
        IEnumerable<TransactionDetail> GetAll(int transactionId);
        TransactionDetail Get(int id);
        double GetAmount(int id);
        void Insert(TransactionDetail detail);
        void Update(TransactionDetail detail);
        void Delete(int id);
    }
}
