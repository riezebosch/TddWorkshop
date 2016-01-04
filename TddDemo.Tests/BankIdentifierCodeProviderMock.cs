using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo.Tests
{
    class BankIdentifierCodeProviderMock 
        : IBankIdentifierCodeProvider
    {
        private bool result;

        public BankIdentifierCodeProviderMock(bool result = false)
        {
            this.result = result;
        }

        public bool ValidateBankCode(string bankCode)
        {
            return result;
        }
    }
}
