using AllieData.DataAccessorInterfaces;
using AllieData.DataAccessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllieData
{
    public abstract class DataAccessorFactory
    {
        public static ICompanyDataAccessor GetCompanyAccessor()
        {
            return new CompanyDataAccessor(new AllieContext());
        }

        public static IUserTypeDataAccessor GetUserTypeAccessor()
        {
            return new UserTypeDataAccessor(new AllieContext());
        }

        public static IUserDataAccessor GetUserAccessor()
        {
            return new UserDataAccessor(new AllieContext());
        }

        public static IAccountDataAccessor GetAccountAccessor()
        {
            return new AccountDataAccessor(new AllieContext());
        }

        public static IAccountTypeDataAccessor GetAccountTypeAccessor()
        {
            return new AccountTypeDataAccessor(new AllieContext());
        }

        public static ITransactionTypeDataAccessor GetTransactionTypeAccessor()
        {
            return new TransactionTypeDataAccessor(new AllieContext());
        }

        public static ITransactionDataAccessor GetTransactionAccessor()
        {
            return new TransactionDataAccessor(new AllieContext());
        }

        public static ITransactionDetailDataAccessor GetTransactionDetailAccessor()
        {
            return new TransactionDetailDataAccessor(new AllieContext());
        }

        public static ILedgerDataAccessor GetLedgerDataAccessor()
        {
            return new LedgerDataAccessor(new AllieContext());
        }

        public static IJournalDataAccessor GetJournalDataAccessor()
        {
            return new JournalDataAccessor(new AllieContext());
        }

        public static IVoucherDataAccessor GetVoucherDataAccessor()
        {
            return new VoucherDataAccessor(new AllieContext());
        }

        public static IIncomeStatementDataAccessor GetIncomeStatementDataAccessor()
        {
            return new IncomeStatementDataAccessor(new AllieContext());
        }
    }
}
