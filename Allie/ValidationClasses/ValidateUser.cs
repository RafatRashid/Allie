using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AllieEntity;
using System.Text.RegularExpressions;

namespace Allie.ValidationClasses
{
    public class ValidateUser
    {
        public static string Message { get; private set; }

        internal static bool IsValid(User u)
        {
            int valid = 0;

            if (u.UserName != null && u.Email!= null && u.Password!= null && u.Address!= null && u.Phone != null)
            {
                if (u.UserName.Length > 3)
                    valid++;
                else
                    Message += "name must be more than 3chars long\n";
                if (u.Address.Length > 4)
                    valid++;
                else
                    Message += "location description must be more than 4 chars long\n";
                if (Regex.IsMatch(u.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                    valid++;
                else
                    Message += "someone@something.com\n";
                if (u.Password.Length >= 6)
                    valid++;
                else
                    Message += "Password must be at least 6 chars long\n";
                if (u.Phone.Length == 7 && u.Phone.All(char.IsDigit))
                    valid++;
                else
                    Message += "phone must be numeric and 7 digits long\n";
            }

            if (valid == 5)
            {
                Message = "";
                return true;
            }
            else
                return false;
        }
    }
}