using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenAnInvalidIbanWhenValidateThenResultIsFalse()
        {
            string iban = "WHY";
            IbanValidator validator = new IbanValidator();

            bool result = validator.Validate(iban);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAValidIbanWhenValidateThenResultIsTrue()
        {
            string iban = "NL48ABNA0534307124";
            BankCodeProviderMock mock = new BankCodeProviderMock(true);
            IbanValidator validator = new IbanValidator(mock);

            bool result = validator.Validate(iban);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIbanWithInvalidCountryCodeWhenValidateThenFalse()
        {
            // Arrange
            string iban = "IE48ABNA0534307124";
            IbanValidator validator = new IbanValidator();

            // Act
            bool result = validator.Validate(iban);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAValidIbanWithLowerCaseCountryCodeWhenValidateThenResultIsFalse()
        {
            string iban = "nl48ABNA0534307124";
            IbanValidator validator = new IbanValidator();

            bool result = validator.Validate(iban);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAnIbanWithInvalidCheckDigitsWhenValidateThenFalse()
        {
            string iban = "NLN8ABNA0534307124";
            IbanValidator validator = new IbanValidator();

            bool result = validator.Validate(iban);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAnIbanWithInvalidSecondCheckDigitWhenValidateThenFalse()
        {
            string iban = "NL4LABNA0534307124";
            IbanValidator validator = new IbanValidator();

            bool result = validator.Validate(iban);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAnInvalidBankCodeWhenValidateThenFalse()
        {
             string iban = "NL48ABNA0534307124";
            IBankCodeProvider provider = new BankCodeProviderMock(false);
            IbanValidator validator = new IbanValidator(provider);

            bool result = validator.Validate(iban);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenValidBelgiumIbanWhenValidateThenTrue()
        {
            string iban = "BE11000123456789";
            IbanValidator validator = new IbanValidator(new BankCodeProviderMock(true));

            bool result = validator.Validate(iban);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenBelgiumIbanWithIncorrectLengthWhenValidateThenFalse()
        {
            string iban = "IE11000123456789";
            IbanValidator validator = new IbanValidator(new BankCodeProviderMock(true));

            bool result = validator.Validate(iban);

            Assert.IsFalse(result);
        }
    }
}
