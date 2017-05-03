using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class IbanValidatorTests
    {
        [TestMethod]
        public void GivenValidIban_WhenValidate_ThenResultIsTrue()
        {
            ExecuteValidate(iban: "NL74 INGB 0671 5336 65", expected: true);
        }

        private static void ExecuteValidate(string iban, bool expected, IBankCodeProvider provider = null)
        {
            Assert.AreEqual(expected, new IbanValidator(provider ?? new BankCodeProvider()).ValidateIban(iban));
        }

        [TestMethod]
        public void GivenIbanInvalidLength_WhenValidate_ThenResultIsFalse()
        {
            ExecuteValidate("NL74 INGB 0671 5336 6", false);
        }

        [TestMethod]
        public void GivenValidIbanWithoutWhitespace_WhenValidate_ThenResultIsTrue()
        {
            ExecuteValidate("NL74INGB0671533665", true);
        }

        [TestMethod]
        public void GivenIbanWithInvalidCharachters_WhenValidate_ThenResultIsFalse()
        {
            ExecuteValidate("NL74INGB?671533665", false);
        }

        [TestMethod]
        public void GivenIbanWithInvalidBankCode_WhenValidate_ThenResultIsFalse()
        {
            var provider = new BankCodeProviderDummy();
            ExecuteValidate("NL74ZZZZ0671533665", false, provider);
        }

        private class BankCodeProviderDummy : IBankCodeProvider
        {
            public string[] BankCodes()
            {
                return new string[] { };
            }
        }
    }
}
