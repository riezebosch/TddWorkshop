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

        private static void ExecuteValidate(string iban, bool expected)
        {
            Assert.AreEqual(expected, IbanValidator.ValidateIban(iban));
        }

        [TestMethod]
        public void GivenInvalidIban_WhenValidate_ThenResultIsFalse()
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
    }
}
