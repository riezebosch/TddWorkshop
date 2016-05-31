using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            bool result = IbanValidator.ValidateIban(iban);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidIbanReturnsTrueWhenValidating()
        {
            string iban = "NL78RABO0162136188";
            Assert.IsTrue(IbanValidator.ValidateIban(iban));
        }

        [TestMethod]
        public void GeenNederlandseIbanReturnsAltijdTrue()
        {
            string iban = "BE61310126985517";
            Assert.IsTrue(IbanValidator.ValidateIban(iban));
        }

        [TestMethod]
        public void TeKorteNederlandseIbanGeeftFalseTerug()
        {
            string iban = "NL78RABO016213618";
            Assert.IsFalse(IbanValidator.ValidateIban(iban));
        }

        [TestMethod]
        public void GeenControleCijfersInNederlandseIbanGeeftFalseTerug()
        {
            string iban = "NLX8RABO0162136188";
            Assert.IsFalse(IbanValidator.ValidateIban(iban));
        }
    }
}
