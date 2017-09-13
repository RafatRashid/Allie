using AllieEntity;
using AllieService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieData;
using AllieData.DataAccessorInterfaces;

namespace AllieService.Services 
{
    class LedgerServices : ILedgerServices
    {
    ILedgerDataAccessor accessor;
    public LedgerServices(ILedgerDataAccessor accessor)
    {
        this.accessor = accessor;
    }

    public void Delete(int id)
    {
        accessor.Delete(id);
    }

    public Ledger Get(int id)
    {
        return accessor.Get(id);
    }

        public Ledger Get(string type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ledger> GetAll()
    {
        return accessor.GetAll();
    }

    public void Insert(Ledger ledger)
    {
        accessor.Insert(ledger);
    }



        public void Update(Ledger ledger)
    {
        accessor.Update(ledger);
    }


    }
}
