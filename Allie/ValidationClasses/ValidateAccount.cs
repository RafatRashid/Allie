using System;
using AllieEntity;

namespace Allie.ValidationClasses
{
    public class ValidateAccount
    {
        public static string Message { get; private set; }

        internal static bool IsValid(Account acc)
        {
            int valid = 0;

            if (acc.AccountDescription != null && acc.AccountNumber != null && acc.Amount != null)
            {
                if (acc.AccountDescription.Length >= 4)
                    valid++;
                else
                    Message += "Account description must be more than 3chars long\n";

                if (acc.AccountNumber.Length == 7)
                    valid++;
                else
                    Message += "Account number must be 7 digits long\n";

                if (acc.Amount >= 0)
                    valid++;
                else
                    Message += "Amount must not be negative\n";
            }
            else
                Message += "All fields must be filled";

            if (valid == 3)
            {
                Message += "Your Account has been added!";
                return true;
            }
            else
                return false;
        }
    }
}