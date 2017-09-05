using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Allie.Models
{
    public class LogIn
    {
        public string UserMail { get; set; }
        public string Password { get; set; }

        public static bool Validate(LogIn log)
        {
            int valid = 0;
            if (log.UserMail != null && log.Password != null)
            {
                if (Regex.IsMatch(log.UserMail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                    valid++;
                if (log.Password.Length >= 7)
                    valid++;
            }
            
            if (valid == 2)
                return true;
            else
                return false;
        }
    }
}