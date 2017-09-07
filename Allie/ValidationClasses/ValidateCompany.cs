using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AllieEntity;
using System.Text.RegularExpressions;

namespace Allie.ValidationClasses
{
    public class ValidateCompany
    {
        public static string Message { get; private set; }

        internal static bool IsValid(Company c)
        {
            int valid = 0;
            

            if(c.CompanyName!=null && c.Location!=null && c.Mail!=null && c.Phone!= null)
            {
                if (c.CompanyName.Length > 3)
                    valid++;
                else
                    Message += "name must be more than 3chars long\n";
                if (c.Location.Length > 4)
                    valid++;
                else
                    Message += "location description must be more than 4 chars long\n";
                if (Regex.IsMatch(c.Mail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                    valid++;
                else
                    Message += "someone@something.com\n";
                if (c.Phone.Length == 7 && c.Phone.All(char.IsDigit))
                    valid++;
                else
                    Message += "phone must be numeric and 7 digits long\n";
            }

            if (valid == 4)
            {
                Message += "Your company has been added!";
                return true;
            }
            else
                return false;
        }
    }
}