using System;

namespace TddDemo.Tests
{
    internal class BankIdentifierCodeValidatorMock : 
        IBankIdentifierCodeValidator
    {
        private bool result;

        public BankIdentifierCodeValidatorMock()
        {
        }

        public BankIdentifierCodeValidatorMock(bool result = false)
        {
            this.result = result;
        }

        public bool Validate(string bic)
        {
            return result;
        }
    }
}