using AllieService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;
using AllieData;
using AllieData.DataAccessorInterfaces;

namespace AllieService.Services
{
    class UserTypeServices : IUserTypeServices
    {
        IUserTypeDataAccessor accessor;
        public UserTypeServices(IUserTypeDataAccessor accessor)
        {
            this.accessor = accessor;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserType Get(string type)
        {
            return accessor.Get(type);
        }

        public IEnumerable<UserType> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(UserType uType)
        {
            throw new NotImplementedException();
        }

        public void Update(UserType uType)
        {
            throw new NotImplementedException();
        }
    }
}
