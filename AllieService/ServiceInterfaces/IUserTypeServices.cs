using AllieEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllieService.ServiceInterfaces
{
    public interface IUserTypeServices
    {
        IEnumerable<UserType> GetAll();
        UserType Get(string type);
        void Insert(UserType uType);
        void Update(UserType uType);
        void Delete(int id);
    }
}
