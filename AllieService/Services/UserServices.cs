using AllieService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;
using AllieData.DataAccessorInterfaces;

namespace AllieService.Services
{
    class UserServices : IUserServices
    {
        IUserDataAccessor accessor;
        public UserServices(IUserDataAccessor accessor)
        {
            this.accessor = accessor;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(User user)
        {
            accessor.Insert(user);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
