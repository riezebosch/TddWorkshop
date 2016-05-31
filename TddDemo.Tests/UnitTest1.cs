using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TddDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InvalidEmptyIban()
        {
            // Arrange
            string iban = string.Empty;

            // Act
            var mock = new BankCodeHelperMock();
            bool result = new IbanValidator(mock).ValidateIban(iban);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidIbanReturnsTrueWhenValidating()
        {
            string iban = "NL78RABO0162136188";
            var mock = new BankCodeHelperMock(true);

            Assert.IsTrue(new IbanValidator(mock).ValidateIban(iban));
        }

        [TestMethod]
        public void GeenNederlandseIbanReturnsAltijdTrue()
        {
            string iban = "BE61310126985517";
            Assert.IsTrue(new IbanValidator(new BankCodeHelperMock(true)).ValidateIban(iban));
        }

        [TestMethod]
        public void TeKorteNederlandseIbanGeeftFalseTerug()
        {
            string iban = "NL78RABO016213618";
            Assert.IsFalse(new IbanValidator(new BankCodeHelperMock(true)).ValidateIban(iban));
        }

        [TestMethod]
        public void GeenControleCijfersInNederlandseIbanGeeftFalseTerug()
        {
            string iban = "NLX8RABO0162136188";
            Assert.IsFalse(new IbanValidator(new BankCodeHelperMock(true)).ValidateIban(iban));
        }

        [TestMethod]
        public void OngeldigeIbanGeeftBijValiderenFalseTerug()
        {
            string iban = "NL78INGA0162136188";
            var mock = new BankCodeHelperMock();

            Assert.IsFalse(new IbanValidator(mock).ValidateIban(iban));

        }

        [TestMethod]
        public void GeldigeBankCodeMetINGMoetOokWordenGoedGekeurd()
        {
            string iban = "NL78INGB0162136188";
            Assert.IsTrue(new IbanValidator(new BankCodeHelperMock(true)).ValidateIban(iban));
        }

        [TestMethod]
        public void IntegratieTestTussenIbanValidatorEnBankCodeHelper()
        {
            string iban = "NL78RABO0162136188";
            var mock = new BankCodeHelperMock();

            new IbanValidator(mock).ValidateIban(iban);

            Assert.IsTrue(mock.IsCalled);

        }

        class BankCodeHelperMock : IBankCodeHelper
        {
            private bool result;

            public BankCodeHelperMock(bool result = false)
            {
                this.result = result;
            }

            public bool IsCalled { get; internal set; }

            public bool CheckBankcode(string bankcode)
            {
                IsCalled = true;
                return result;
            }
        }

        [TestMethod]
        public void IntegratieTestTussenIbanValidatorEnBankCodeHelperMetBehulpVanMockingFramework()
        {
            string iban = "NL78RABO0162136188";
            var mock = new Mock<IBankCodeHelper>();
            mock
                .Setup(m => m.CheckBankcode(It.IsAny<string>()))
                .Returns(true)
                .Verifiable();

            new IbanValidator(mock.Object).ValidateIban(iban);

            mock.VerifyAll();
        }
    }
}
