using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieData.DataAccessorInterfaces
{
    public interface ILedgerDataAccessor
    {
        IEnumerable<Ledger> GetAll();
        IEnumerable<Ledger> GetAll(int companyId);
        Ledger Get(int id);
        void Insert(Ledger ledger);
        void Update(Ledger ledger);
        void Delete(int id);
    }
}
