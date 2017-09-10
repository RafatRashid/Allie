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
    }
}
