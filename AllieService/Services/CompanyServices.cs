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
            throw new NotImplementedException();
        }

        public Company Get(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
