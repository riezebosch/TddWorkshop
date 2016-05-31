using System.Text.RegularExpressions;

namespace TddDemo
{
    class IbanValidatorNL : IIbanValidator
    {
        private IBankCodeHelper helper;
        public IbanValidatorNL(IBankCodeHelper helper)
        {
            this.helper = helper;
        }

        public bool Validate(string iban)
        {
            var match = Regex.Match(iban, @"NL\d{2}(?<bankcode>.{4}).{10}");
            if (!match.Success)
            {
                return false;
            }

            var bankcode = match.Groups["bankcode"].Value;
            return helper.CheckBankcode(bankcode);
        }
    }
}