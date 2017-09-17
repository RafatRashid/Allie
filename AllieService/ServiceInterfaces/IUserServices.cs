using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieService.ServiceInterfaces
{
    public interface IUserServices
    {
        IEnumerable<User> GetAll();
        User Get(string username, string password);
        User Get(int id);
        void Insert(User user);
        void Update(User user);
        void Delete(int id);
        void ChangePassword(int id, string password);
        IEnumerable<User> GetCompanyUsers(int companyId);
        IEnumerable<User> GetAll(string str, int companyId);
    }
}
