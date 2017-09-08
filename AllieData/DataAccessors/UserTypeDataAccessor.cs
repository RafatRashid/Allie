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
            throw new NotImplementedException();
        }

        public UserType Get(string type)
        {
            return context.UserTypes.Single(x => x.Type == type);
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
