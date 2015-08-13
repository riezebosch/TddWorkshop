using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo
{
    class IbanValidatorBE : IIbanValidator
    {
        public bool Validate(string iban)
        {
            return iban.Length == 16;
        }
    }
}
