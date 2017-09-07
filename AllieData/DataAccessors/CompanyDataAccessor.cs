using AllieData.DataAccessorInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieData.DataAccessors
{
    // for the time being only getall and insert is done...
    class CompanyDataAccessor : ICompanyDataAccessor
    {
        private AllieContext context;
        public CompanyDataAccessor(AllieContext context)
        {
            this.context = context;
        }

        public void Insert(Company company)
        {
            context.Companies.Add(company);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Company company)
        {
            throw new NotImplementedException();
        }

        public Company Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAll()
        {
            return context.Companies.ToList();
        }
    }
}
