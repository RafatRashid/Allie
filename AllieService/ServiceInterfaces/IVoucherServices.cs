using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieService.ServiceInterfaces
{
    public interface IVoucherServices
    {
        IEnumerable<Voucher> GetAll();
        Voucher Get(int id);
        bool Insert(Voucher Voucher);
        bool Update(Voucher Voucher);
        bool Delete(int id);
    }
}
