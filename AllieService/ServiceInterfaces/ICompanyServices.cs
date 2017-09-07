using AllieEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllieService.ServiceInterfaces
{
    public interface ICompanyServices
    {
        IEnumerable<Company> GetAll();
        Company Get(int id);
        void Insert(Company company);
        void Update(Company company);
        void Delete(int id);
    }
}
