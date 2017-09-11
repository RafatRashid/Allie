using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieService.ServiceInterfaces
{
    public interface ITransactionTypeServices
    {
        IEnumerable<TransactionType> GetAll();
        TransactionType Get(int id);
        TransactionType Get(string type);
        TransactionType Get(int accId, bool isSource);
        void Insert(TransactionType tType);
        void Update(TransactionType tType);
        void Delete(int id);
    }
}
