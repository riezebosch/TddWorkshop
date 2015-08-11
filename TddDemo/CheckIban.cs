using System;

namespace TddDemo
{
    public class CheckIban
    {
        public CheckIban()
        {
        }

        public IbanValidationResult Validate(string iban)
        {
            if (!iban.ToUpper().StartsWith("NL"))
            {
                return IbanValidationResult.InvalidCountryCode;
            }

            if(!char.IsDigit(iban[2]) ||
                !char.IsDigit(iban[3]))
            {
                return IbanValidationResult.InvalidCheckDigits;
            }

            if (!char.IsLetter(iban[4]) ||
                !char.IsLetter(iban[5]) ||
                !char.IsLetter(iban[6]) ||
                !char.IsLetter(iban[7]))
            {
                return IbanValidationResult.InvalidBankCode;
            }

            return IbanValidationResult.OK;
        }
    }
}