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
            User u = context.Users.SingleOrDefault(x => x.UserId == id);
            context.Users.Remove(u);
            context.SaveChanges();
        }

        public User Get(int id)
        {
            return context.Users.SingleOrDefault(x => x.UserId == id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Insert(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Update(User user)
        {
            User u = context.Users.SingleOrDefault(x => x.UserId == user.UserId);

            u.UserName = user.UserName;
            u.Phone = user.Phone;
            u.Email = user.Email;
            u.Address = user.Address;

            context.SaveChanges();
        }

        public void ChangePassword(int id, string password)
        {
            User u = context.Users.SingleOrDefault(x => x.UserId == id);
            u.Password = password;

            context.SaveChanges();
        }
    }
}
