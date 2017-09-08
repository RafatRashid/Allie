using AllieService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AllieEntity;
using AllieData.DataAccessorInterfaces;

namespace AllieService.Services
{
    class CompanyServices : ICompanyServices
    {
        private ICompanyDataAccessor accessor;
        public CompanyServices(ICompanyDataAccessor accessor)
        {
            this.accessor = accessor;
        }


        public void Delete(int id)
        {
            accessor.Delete(id);
        }

        public Company Get(int id)
        {
            return accessor.Get(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return accessor.GetAll();
        }

        public void Insert(Company company)
        {
            accessor.Insert(company);
        }

        public void Update(Company company)
        {
            accessor.Update(company);
        }
    }
}
