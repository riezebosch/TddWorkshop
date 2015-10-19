using System;
using System.Text.RegularExpressions;

namespace TddDemo
{
    public class IbanValidator
    {
        private IBankIdentifierCodeValidator bic;

        public IbanValidator(IBankIdentifierCodeValidator bic)
        {
            this.bic = bic;
        }

        public bool Validate(string iban)
        {
            if (iban == null)
            {
                throw new ArgumentNullException("iban", "Input parameter IBAN is null en dat mag niet.");
            }

            /*
                NL: Land code
                \d{2}: check digit
                (?<bic>.{4}): BIC
            */
            var match = Regex.Match(iban, @"NL\d{2}(?<bic>.{4}).*");
            var bic = match.Groups["bic"].Value;

            if (!this.bic.Validate(bic))
            {
                return false;
            }

            return match.Success;
        }

        
    }
}