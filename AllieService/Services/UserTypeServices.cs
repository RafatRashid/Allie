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
            accessor.Delete(id);
        }

        public UserType Get(string type)
        {
            return accessor.Get(type);
        }

        public UserType Get(int id)
        {
            return accessor.Get(id);
        }

        public IEnumerable<UserType> GetAll()
        {
            return accessor.GetAll();
        }

        public void Insert(UserType uType)
        {
            accessor.Insert(uType);
        }

        public void Update(UserType uType)
        {
            accessor.Update(uType);
        }
    }
}
