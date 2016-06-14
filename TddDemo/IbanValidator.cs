using System.Collections.Generic;

namespace TddDemo
{
    public class IbanValidator
    {
        private IDictionary<string, IIbanValidator> validators;
        public IbanValidator(IBankCodeHelper helper)
        {
            validators = new Dictionary<string, IIbanValidator>();
            validators["NL"] = new IbanValidatorNL(helper);
        }

        public IbanValidator(): this (new BankCodeHelper())
        {
        }

        public bool ValidateIban(string iban)
        {
            if (iban == null || iban.Length < 2)
            {
                return false;
            }

            var land = iban.Substring(0, 2);
            IIbanValidator validator;

            if (!validators.TryGetValue(land, out validator))
            {
                validator = new DefaultValidator();
            }

            return validator.Validate(iban);
        }
    }
}