using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IbanNotStartingWithNLShouldReturnInvalidCountryCodeWhenValidated()
        {
            string iban = "XX71INGB0448927934";
            CheckIban checker = new CheckIban();

            IbanValidationResult result = checker.Validate(iban);

            Assert.AreEqual(IbanValidationResult.InvalidCountryCode, result);

        }

        [TestMethod]
        public void CorrectIbanShouldReturnTrueWhenValidated()
        {
            string iban = "NL71INGB0448927934";
            CheckIban checker = new CheckIban();

            IbanValidationResult result = checker.Validate(iban);

            Assert.AreEqual(IbanValidationResult.OK, result);
        }

        [TestMethod]
        public void IbanWithIncorrectCheckDigitsShouldReturnFalseWhenValidated()
        {
            string iban = "NLABINGB0448927934";
            CheckIban checker = new CheckIban();

            IbanValidationResult result = checker.Validate(iban);

            Assert.AreEqual(IbanValidationResult.InvalidCheckDigits, result);
        }

        [TestMethod]
        public void IbanWithLowerCaseCountryCodeShouldReturnOkayWhenValidated()
        {
            string iban = "nl71INGB0448927934";
            CheckIban checker = new CheckIban();

            IbanValidationResult result = checker.Validate(iban);

            Assert.AreEqual(IbanValidationResult.OK, result);

        }
    }
}
