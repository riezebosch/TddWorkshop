using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo
{
    public class BankIdentifierCodeValidator : IBankIdentifierCodeValidator
    {
        public bool Validate(string bic)
        {
            return bic != "XXXX";
        }
    }
}
