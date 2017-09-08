using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieData.DataAccessorInterfaces
{
    public interface IUserTypeDataAccessor
    {
        IEnumerable<UserType> GetAll();
        UserType Get(string type);
        UserType Get(int id);
        void Insert(UserType uType);
        void Update(UserType uType);
        void Delete(int id);
    }
}
