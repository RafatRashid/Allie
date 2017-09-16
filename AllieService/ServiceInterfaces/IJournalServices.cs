using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieService.ServiceInterfaces
{
    public interface IJournalServices
    {
        IEnumerable<Journal> GetAll();
        IEnumerable<Journal> GetAll(int companyId);
        Journal Get(int id);
        Journal Get(int companyId, DateTime period);
        Journal GetByLedger(int ledgerId);
        bool Insert(Journal journal);
        bool Update(Journal journal);
        bool Delete(int id);
    }
}
