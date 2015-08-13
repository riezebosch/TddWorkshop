using System;

namespace TddDemo.Tests
{
    public class BankCodeProviderMock : IBankCodeProvider
    {
        private bool result;

        public BankCodeProviderMock(bool result)
        {
            this.result = result;
        }

        public bool IsThisInYourList(string code)
        {
            return result;
        }
    }
}