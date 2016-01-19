using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.QualityTools.Testing.Fakes;
using Shouldly;

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

        [TestMethod]
        public void IbanNotStartingWithNLShouldReturnFalse()
        {
            // Arrange
            string iban = "XX78RABO0162136188";
            bool expected = false;

            var validator = new IbanValidator();

            // Act
            bool result = validator.Validate(iban);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CheckDigitsNotNumbersShouldReturnFalse()
        {
            // Arrange
            string iban = "NLXXRABO0162136188";
            bool expected = false;

            var validator = new IbanValidator();

            // Act
            bool result = validator.Validate(iban);

            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void IbanWithInvalidBankCodeShouldReturnFalse()
        {
            // Arrange
            IBankCodeValidator bcv = new BankCodeValidatorMock();

            string iban = "NL78RABO0162136188";
            bool expected = false;

            var validator = new IbanValidator(bcv);

            // Act
            bool result = validator.Validate(iban);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IbanWithInvalidBankCodeShouldReturnFalseUsingAMockingFramework()
        {
            // Arrange
            var bcv = new Mock<IBankCodeValidator>();
            bcv.Setup(m => m.IsValidBankCode(It.IsAny<string>())).Returns(false).Verifiable();

            string iban = "NL78RABO0162136188";
            bool expected = false;

            var validator = new IbanValidator(bcv.Object);

            // Act
            bool result = validator.Validate(iban);

            // Assert
            Assert.AreEqual(expected, result);
            result.ShouldBe(expected);

            bcv.Verify();
        }

        [TestMethod]
        public void TestWithHardDependencies()
        {

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.TodayGet = () =>  new DateTime(2016, 04, 06);

                int result = CalcAge(new DateTime(1982, 04, 05));
                Assert.AreEqual(result, 34);
            }
        }

        private int CalcAge(DateTime dateTime)
        {
            return DateTime.Today.Year - dateTime.Year;
        }
    }
}
