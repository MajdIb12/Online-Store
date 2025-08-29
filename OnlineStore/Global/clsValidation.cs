using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineStore.Global
{
    internal static class clsValidation
    {
        public static bool EmailValidation(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            return false;
        }
            public static bool IsValidPhone(string Phone)
        {
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                var r = new Regex(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$");
                return r.IsMatch(Phone);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    
}
