using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieData.DataAccessorInterfaces
{
    public interface ITransactionTypeDataAccessor
    {
        IEnumerable<TransactionType> GetAll();
        TransactionType Get(int id);
        TransactionType Get(string type);
        void Insert(TransactionType tType);
        void Update(TransactionType tType);
        void Delete(int id);
    }
}
