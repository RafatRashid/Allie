using System;
using AllieEntity;

namespace Allie.ValidationClasses
{
    class ValidateTransaction
    {
        public static string Message;

        internal static bool IsValid(Transaction transaction)
        {
            int valid = 0;

            if (transaction.TransactionDescription != null && transaction.TransactionDate != null)
            {
                if (transaction.TransactionDescription.Length >= 4)
                    valid++;
                else
                    Message += "Transaction description must be more than 3 chars long\n";
            }
            else
                Message += "All fields must be filled";

            if (valid == 1)
            {
                Message += "Transaction has been edited!";
                return true;
            }
            else
                return false;
        }
    }
}