using AllieData.DataAccessorInterfaces;
using AllieData.DataAccessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieData
{
    public abstract class DataAccessorFactory
    {
        public static ICompanyDataAccessor GetCompanyAccessor()
        {
            return new CompanyDataAccessor(new AllieContext());
        }
    }
}
