using System;
using System.Collections.Generic;

namespace TddDemo
{
    public class IbanValidator
    {
        Dictionary<string, IIbanValidator> validators = new Dictionary<string, IIbanValidator>();

        public IbanValidator() 
            : this(new BankCodeProvider())
        {
        }

        public IbanValidator(IBankCodeProvider provider)
        {
            validators["BE"] = new IbanValidatorBE();
            validators["NL"] = new IbanValidatorNL(provider);

        }

        public bool Validate(string iban)
        {
            string countryCode = iban.Substring(0, 2);
            if (validators.ContainsKey(countryCode))
            {
                IIbanValidator validator = validators[countryCode];
                return validator.Validate(iban);
            }


            //IIbanValidator validator;
            //if (validators.TryGetValue(countryCode, out validator))
            //{
            //    return validator.Validate(iban);
            //}
           
            return false;
        }

        

        
    }
}