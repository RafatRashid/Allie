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
    class TransactionServices : ITransactionServices
    {
        ITransactionDataAccessor accessor;
        public TransactionServices(ITransactionDataAccessor accessor)
        {
            this.accessor = accessor;
        }

        public void Delete(int id)
        {
            accessor.Delete(id);
        }

        public Transaction Get(int id)
        {
            return accessor.Get(id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return accessor.GetAll();
        }

        public void Insert(Transaction tran)
        {
            accessor.Insert(tran);
        }

        public void Update(Transaction tran)
        {
            accessor.Update(tran);
        }
    }
}
