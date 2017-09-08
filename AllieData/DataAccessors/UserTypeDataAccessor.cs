using AllieData.DataAccessorInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieData.DataAccessors
{
    class UserTypeDataAccessor : IUserTypeDataAccessor
    {
        AllieContext context;
        public UserTypeDataAccessor(AllieContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            UserType u = context.UserTypes.SingleOrDefault(x => x.Id == id);
            context.UserTypes.Remove(u);
            context.SaveChanges();
        }

        public UserType Get(string type)
        {
            return context.UserTypes.Single(x => x.Type == type);
        }

        public UserType Get(int id)
        {
            return context.UserTypes.Single(x => x.Id == id);
        }

        public IEnumerable<UserType> GetAll()
        {
            return context.UserTypes.ToList();
        }

        public void Insert(UserType uType)
        {
            context.UserTypes.Add(uType);
            context.SaveChanges();
        }

        public void Update(UserType uType)
        {
            UserType u = context.UserTypes.SingleOrDefault(x => x.Id == uType.Id);

            u.Type = uType.Type;

            context.SaveChanges();
        }
    }
}
