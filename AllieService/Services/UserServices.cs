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
            accessor.Delete(id);
        }

        public User Get(string username, string password)
        {
            return accessor.Get(username, password);
        }

        public User Get(int username)
        {
            return accessor.Get(username);
        }

        public IEnumerable<User> GetAll()
        {
            return accessor.GetAll();
        }

        public void Insert(User user)
        {
            accessor.Insert(user);
        }

        public void Update(User user)
        {
            accessor.Update(user);
        }

        public void ChangePassword(int id, string password)
        {
            accessor.ChangePassword(id, password);
        }

        public IEnumerable<User> GetCompanyUsers(int companyId)
        {
            return accessor.GetCompanyUsers(companyId);
        }
        public IEnumerable<User> GetAll(string str, int companyId)
        {
            return accessor.GetAll(str, companyId);
        }

    }
}
