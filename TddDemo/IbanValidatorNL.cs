using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo
{
    class IbanValidatorNL : IIbanValidator
    {
        private IBankCodeProvider provider;

        public IbanValidatorNL(IBankCodeProvider provider)
        {
            this.provider = provider;
        }
        public bool Validate(string iban)
        {
            return iban.Length == 18 &&
                char.IsNumber(iban[2]) &&
                char.IsNumber(iban[3]) &&
                provider.IsThisInYourList(iban.Substring(4, 4));
        }
    }
}
