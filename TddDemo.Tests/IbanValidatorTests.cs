using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class IbanValidatorTests
    {
        private IbanValidator target;

        [TestInitialize]
        public void Init()
        {
            target = new IbanValidator();
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
    }
}
