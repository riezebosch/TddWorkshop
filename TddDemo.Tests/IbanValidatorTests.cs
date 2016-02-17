using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Shouldly;

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

        [TestMethod]
        public void GivenCheckDigitsNotNumbers_WhenValidate_ThenResultFalse()
        {
            // Arrange
            string input = "NLXXRABO0162136188";
            var validator = new IbanValidator();

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenInvalidBankCode_WhenValidate_ThenResultFalse()
        {
            // Arrange
            string input = "NL78XXXX0162136188";
            var validator = new IbanValidator();

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAnotherValidBankCode_WhenValidate_ThenResultTrue()
        {
            // Arrange
            string input = "NL35INGB0008804468";
            var validator = new IbanValidator();

            // Act
            bool result = validator.Validate(input);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void GivenBankCodeDeniedByProvider_WhenValidate_ThenResultFalse()
        {
            // Arrange
            string input = "NL78RABO0162136188";
            var validator = new IbanValidator(new BankCodeProviderMock());

            // Act
            bool result = validator.Validate(input);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void GivenBankCodeDeniedByProviderCreatedWithMoq_WhenValidate_ThenResultFalse()
        {
            // Arrange
            string input = "NL78RABO0162136188";

            var mock = new Mock<IBankCodeProvider>();
            mock
                .Setup(m => m.BankCodes)
                .Returns(new List<string>())
                .Verifiable();

            var validator = new IbanValidator(mock.Object);

            // Act
            bool result = validator.Validate(input);

            // Assert
            result.ShouldBeFalse();
            mock.Verify();
        }
    }
}
