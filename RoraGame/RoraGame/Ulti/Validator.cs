using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoraGame.Ulti
{
    public static class Validator
    {
        public static bool isValidEmail(this string mail)
        {
            try
            {
                if (string.IsNullOrEmpty(mail))
                    return false;
                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

                System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(mail);

                return regex.IsMatch(mail);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                return false;

            //return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
            return Regex.Match(number, @"^([0-9]{10})$").Success;
        }
    }
}
