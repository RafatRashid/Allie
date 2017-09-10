using AllieData.DataAccessorInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieData.DataAccessors
{
    public class TransactionTypeDataAccessor : ITransactionTypeDataAccessor
    {
        AllieContext context;
        public TransactionTypeDataAccessor(AllieContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            TransactionType type = context.TransactionTypes.SingleOrDefault(x => x.Id == id);
            context.TransactionTypes.Remove(type);
        }

        public TransactionType Get(int id)
        {
            return context.TransactionTypes.SingleOrDefault(x => x.Id == id);
        }

        public TransactionType Get(string type)
        {
            return context.TransactionTypes.SingleOrDefault(x => x.Type == type);
        }

        public IEnumerable<TransactionType> GetAll()
        {
            return context.TransactionTypes.ToList();
        }

        public void Insert(TransactionType tType)
        {
            context.TransactionTypes.Add(tType);
            context.SaveChanges();
        }

        public void Update(TransactionType tType)
        {
            TransactionType a = context.TransactionTypes.SingleOrDefault(x => x.Id == tType.Id);

            a.Type = tType.Type;

            context.SaveChanges();
        }
    }
}
