using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class IbanValidatorTests
    {
        private IbanValidatorNL target;

        [TestInitialize]
        public void Init()
        {
            target = new IbanValidatorNL();
        }

        [TestMethod]
        public void GivenAnEmptyIbanWhenValidateThenResultIsFalse()
        {
            bool result = target.Validate("");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAValidIbanWhenValidateThenResultIsTrue()
        {
            bool result = target.Validate("NL76INGB0006384065");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenAnIbanNotStartingWithNLWhenValidateResultIsFalse()
        {
            bool result = target.Validate("XX76INGB0006384065");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAnotherValidIbanStartingWithNLWhenValidateThenResultIsTrue()
        {
            bool result = target.Validate("NL81INGB0004963507");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenAnIbanStartingWithNOWhenValidateThenResultIsFalse()
        {
            bool result = target.Validate("NO9386011117947");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenInvalidCheckDigitsWhenValidateThenResultIsFalse()
        {
            bool result = target.Validate("NL8AINGB0004963507");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenInvalidFirstCheckDigitWhenValidateThenResultIsFalse()
        {
            bool result = target.Validate("NLA1INGB0004963507");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenInvalidBankCodeWhenValidateThenResultIsFalse()
        {
            bool result = target.Validate("NL81XXXX0004963507");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenValidIbanWithAbnBankCodeWhenValidateThenResultIsTrue()
        {
            bool result = target.Validate("NL23ABNA0409519596");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenValidBankCodeWrongPositionWhenValidateThenResultIsFalse()
        {
            bool result = target.Validate("NL23XXXXINGB19596");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAValidIbanButConsideredInvalidForBankCodeByBankCodeProviderStubWhenValidateThenResultIsFalse()
        {
            IBankCodeValidator bcv = new BankCodeValidatorMock();
            var target = new IbanValidatorNL(bcv);
            bool result = target.Validate("NL76INGB0006384065");
            Assert.IsFalse(result);
        }



    }

    internal class BankCodeValidatorMock : IBankCodeValidator
    {
        public BankCodeValidatorMock()
        {
        }

        public bool IsValidBankCode(string bankCode)
        {
            return false;
        }
    }
}
