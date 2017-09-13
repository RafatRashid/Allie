using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieData.DataAccessors
{
    class VoucherDataAccessor : DataAccessorInterfaces.IVoucherDataAccessor
    {
        private AllieContext Context;

        public VoucherDataAccessor(AllieContext Context)
        {
            this.Context = Context;
        }

        public bool Delete(int id)
        {
            Voucher c = Context.Vouchers.SingleOrDefault(x => x.Id == id);
            Context.Vouchers.Remove(c);
            Context.SaveChanges();
            return true;
        }

        public Voucher Get(int id)
        {
            return Context.Vouchers.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Voucher> GetAll()
        {
            return Context.Vouchers.ToList();
        }

        public bool Insert(Voucher voucher)
        {
            Context.Vouchers.Add(voucher);
            Context.SaveChanges();
            return true;
        }

        public bool Update(Voucher voucher)
        {
            this.Delete(voucher.Id);
            this.Insert(voucher);
            Context.SaveChanges();
            return true;
        }
    }
}
