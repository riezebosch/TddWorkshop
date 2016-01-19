using System.Text.RegularExpressions;

namespace TddDemo
{
    public class IbanValidator
    {
        private IBankCodeValidator bcv;

        public IbanValidator() : this(new BankCodeValidator())
        {
        }

        internal IbanValidator(IBankCodeValidator bcv)
        {
            this.bcv = bcv;
        }

        public bool Validate(string iban)
        {
            if (string.IsNullOrEmpty(iban))
            {
                return false;
            }

            if (iban.StartsWith("BE"))
            {
                return true;
            }

            return Regex.IsMatch(iban, @"^NL\d{2}") && bcv.IsValidBankCode(iban);
        }
    }
}