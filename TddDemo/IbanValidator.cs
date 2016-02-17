using System;
using System.Collections.Generic;
using System.Linq;

using System.Text.RegularExpressions;

namespace TddDemo
{
    public class IbanValidator
    {
        IBankCodeProvider bankCodeProvider;

        public IbanValidator() 
            : this(new BankCodeProvider())
        {
        }

        internal IbanValidator(IBankCodeProvider bankCodeProvider)
        {
            this.bankCodeProvider = bankCodeProvider;
        }

        public bool Validate(string input)
        {
            var match = Regex.Match(input, @"^NL\d{2}(?<bc>.{4}).*");
            if (match.Success)
            {
                var code = match.Groups["bc"].Value;
                return IsValidBankCode(code);
            }
            return match.Success;
        }

        private  bool IsValidBankCode(string code)
        {
            
            return bankCodeProvider.BankCodes.Contains(code);
        }
    }
}