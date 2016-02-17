using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class IbanValidatorTests
    {
        [TestMethod]
        public void TestValidIban()
        {
            // Arrange
            string input = "NL78RABO0162136188";
            var validator = new IbanValidator();

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEmptyIban()
        {
            // Arrange
            string input = "";
            var validator = new IbanValidator();

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenCountryCodeNotNL_WhenValidate_ThenResultFalse()
        {
            // Arrange
            string input = "XX78RABO0162136188";
            var validator = new IbanValidator();

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
