using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieData.DataAccessorInterfaces
{
    public interface ICompanyDataAccessor
    {
        IEnumerable<Company> GetAll();
        Company Get(int id);
        void Insert(Company company);
        void Update(Company company);
        void Delete(int id);
    }
}
