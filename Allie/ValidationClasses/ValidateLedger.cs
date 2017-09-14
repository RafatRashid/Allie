using AllieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Allie.ValidationClasses
{
    public class ValidateLedger
    {
        public static string Message { get; internal set; }

        internal static bool IsValid(Ledger led)
        {
            int valid = 0;

            if (led.LedgerDescription != null)
            {
                if (led.LedgerDescription.Length > 3)
                    valid++;
                else
                    Message += "description must be more than 3 chars long\n";
            }
            else
                Message += "description must not be null";

            if (valid == 1)
            {
                Message += "Journal has been generated!";
                return true;
            }
            else
                return false;
        }
    }
}