using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class IbanValidatorTests
    {
        [TestMethod]
        public void ValidIbanShouldReturnTrue()
        {
            // Arrange
            string iban = "NL78RABO0162136188";
            bool expected = true;

            var validator = new IbanValidator();

            // Act
            bool result = validator.Validate(iban);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void EmptyIbanShouldReturnFalse()
        {
            string iban = "";
            var validator = new IbanValidator();

            bool result = validator.Validate(iban);

            Assert.IsFalse(result);
        }
    }
}
