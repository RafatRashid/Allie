using AllieData;
using AllieService.ServiceInterfaces;
using AllieService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieService
{
    public class ServiceFactory
    {
        public static ICompanyServices GetCompanyServices()
        {
            return new CompanyServices(DataAccessorFactory.GetCompanyAccessor());
        }
    }
}
