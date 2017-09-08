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

        public static IUserTypeDataAccessor GetUserTypeAccessor()
        {
            return new UserTypeDataAccessor(new AllieContext());
        }

        public static IUserDataAccessor GetUserAccessor()
        {
            return new UserDataAccessor(new AllieContext());
        }

        public static IAccountDataAccessor GetAccountAccessor()
        {
            return new AccountDataAccessor(new AllieContext());
        }

        public static IAccountTypeDataAccessor GetAccountTypeAccessor()
        {
            return new AccountTypeDataAccessor(new AllieContext());
        }
    }
}
