using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AllieEntity;

namespace Allie.ValidationClasses
{
    public class ValidateJournal
    {
        public static string Message { get; internal set; }

        internal static bool IsValid(Journal j)
        {
            int valid = 0;

            if (j.JournalDescription != null)
            {
                if (j.JournalDescription.Length > 3)
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