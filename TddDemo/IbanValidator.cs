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
        private IBankCodeHelper helper;

        public IbanValidator(IBankCodeHelper helper)
        {
            this.helper = helper;
        }

        public IbanValidator() : this (new BankCodeHelper())
        {
        }

        public bool ValidateIban(string iban)
        {
            if (iban.StartsWith("NL"))
            {
                var match = Regex.Match(iban, @"NL\d{2}(?<bankcode>.{4}).{10}");
                if (!match.Success)
                {
                    return false;
                }

                var bankcode = match.Groups["bankcode"].Value;
                return helper.CheckBankcode(bankcode);
            }
            else
            {
                return Regex.IsMatch(iban, "[A-Z]{2}.*");
            }
        }

        
    }
}
