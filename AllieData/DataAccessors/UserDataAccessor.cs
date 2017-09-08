using AllieData.DataAccessorInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieData.DataAccessors
{
    class UserDataAccessor : IUserDataAccessor
    {
        AllieContext context;

        public UserDataAccessor(AllieContext context)
        {
            this.context = context;
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
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
