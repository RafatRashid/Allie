using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieService.ServiceInterfaces
{
    public interface ILedgerServices
    {
        IEnumerable<Ledger> GetAll();
        IEnumerable<Ledger> GetAll(int companyId);
        Ledger Get(int id);
        void Insert(Ledger uType);
        void Update(Ledger uType);
        void Delete(int id);
    }
}
