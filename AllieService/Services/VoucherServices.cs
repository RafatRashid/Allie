using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;
using AllieData.DataAccessorInterfaces;

namespace AllieService.Services
{
    class VoucherServices : ServiceInterfaces.IVoucherServices
    {
        private IVoucherDataAccessor accessor;

        public VoucherServices(IVoucherDataAccessor accessor)
        {
            this.accessor = accessor;
        }

        public bool Delete(int id)
        {
            return accessor.Delete(id);
        }

        public Voucher Get(int id)
        {
            return accessor.Get(id);
        }

        public IEnumerable<Voucher> GetAll()
        {
            return accessor.GetAll();
        }

        public bool Insert(Voucher Voucher)
        {
            return accessor.Insert(Voucher);
        }

        public bool Update(Voucher Voucher)
        {
            return accessor.Update(Voucher);
        }
    }
}
