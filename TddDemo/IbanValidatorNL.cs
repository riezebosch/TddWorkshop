using System;

namespace TddDemo
{
    public class IbanValidatorNL
    {
        private IBankCodeValidator bcv = new BankCodeValidator();

        public IbanValidatorNL(IBankCodeValidator bcv)
        {
            this.bcv = bcv;
        }

        public IbanValidatorNL()
        {
        }

        public bool Validate(string iban)
        {
            if (HasValidCountryCode(iban) &&
                HasCheckDigits(iban) && 
                HasValidBankCode(iban))
            {
                return true;
            }

            return false;
        }

        private bool HasValidBankCode(string iban)
        {
            return bcv.IsValidBankCode(iban.Substring(4, 4));
        }

        
        private static bool HasValidCountryCode(string iban)
        {
            return iban.StartsWith("NL");
        }

        private static bool HasCheckDigits(string iban)
        {
            return char.IsNumber(iban[2]) && char.IsNumber(iban[3]);
        }
    }
}