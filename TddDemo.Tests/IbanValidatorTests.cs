using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class IbanValidatorTests
    {
        [TestMethod]
        public void GivenGarbageInWhenValidateThenReturnFalse()
        {
           Assert.IsFalse(new IbanValidator(new BankIdentifierCodeValidatorMock()).Validate("ONZIN"));
        }

        [TestMethod]
        public void GivenAValidIbanWhenValidateThenReturnTrue()
        {
            Assert.IsTrue(new IbanValidator(
                new BankIdentifierCodeValidatorMock(true))
                .Validate("NL74RABO0162136188"));
        }

        [TestMethod]
        public void GivenAnIbanNotStartingWithNLWhenValidateThenReturnFalse()
        {
            Assert.IsFalse(
                new IbanValidator(new BankIdentifierCodeValidatorMock())
                .Validate("DE74RABO0162136188"));
        }

        [TestMethod]
        public void GivenNullForIbanWhenValidateThenException()
        {
            try
            {
                new IbanValidator(new BankIdentifierCodeValidatorMock()).Validate(null);

                // Dit punt mag de test nooit komen!
                Assert.Fail("Dit punt had de test nooit mogen komen.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("Input parameter IBAN is null en dat mag niet."));
            }
        }

        [TestMethod]
        public void GivenInvalidCheckDigitsWhenValidateThenReturnFalse()
        {
            Assert.IsFalse(new IbanValidator(new BankIdentifierCodeValidatorMock())
               .Validate("NLXXRABO0162136188"));
        }

        [TestMethod]
        public void GivenInvalidSecondCheckDigitWhenValidateReturnFalse()
        {
            Assert.IsFalse(new IbanValidator(new BankIdentifierCodeValidatorMock())
               .Validate("NL7XRABO0162136188"));
        }

        [TestMethod]
        public void GivenInvalidBankIdentifierdCodeWhenValidateThenReturnFalse()
        {
             Assert.IsFalse(new IbanValidator(new BankIdentifierCodeValidatorMock())
                .Validate("NL74XXXX0162136188"));
        }

        [TestMethod]
        public void GivenBankIdentifierCodeValidatorRejectBankCodeWhenValidateThenReturnFalse()
        {
            IBankIdentifierCodeValidator mock = 
                new BankIdentifierCodeValidatorMock();

            var validator = new IbanValidator(mock);

             Assert.IsFalse(validator
                .Validate("NL74RABO0162136188"));
        }

        [TestMethod]
        [TestCategory("integration-test")]
        public void IbanValidatorAndBankCodeValidatorShouldWorkTogether()
        {
            var bic = new BankIdentifierCodeValidator();
            var validator = new IbanValidator(bic);

            Assert.IsTrue(validator.Validate("NL74RABO0162136188"));
        }
    }
}
