using System;

namespace TddDemo.Tests
{
    internal class BankCodeValidatorMock : IBankCodeValidator
    {
        public bool IsValidBankCode(string iban)
        {
            return false;
        }
    }
}