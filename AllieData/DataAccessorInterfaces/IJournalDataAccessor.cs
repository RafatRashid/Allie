using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieData.DataAccessorInterfaces
{
    public interface IJournalDataAccessor
    {

        IEnumerable<Journal> GetAll();
        IEnumerable<Journal> GetAll(int companyId);
        Journal Get(int id);
        bool Insert(Journal journal);
        bool Update(Journal journal);
        bool Delete(int id);
    }
}
