using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TddDemo
{
    public class IbanValidator
    {
        public static bool ValidateIban(string iban)
        {
            if (iban.StartsWith("NL"))
            {
                return Regex.IsMatch(iban, @"NL\d{2}.{14}");
            }
            else
            {
                return Regex.IsMatch(iban, "[A-Z]{2}.*");
            }
        }
    }
}
