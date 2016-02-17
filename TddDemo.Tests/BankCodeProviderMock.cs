using System;
using System.Collections.Generic;

namespace TddDemo.Tests
{
    internal class BankCodeProviderMock : IBankCodeProvider
    {
        public IList<string> BankCodes => new List<string>();
    }
}