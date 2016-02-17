using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GeldigeIbanGeeftTrueTerug()
        {
            // Arrange
            string rekeningnummer = "NL78RABO0162136188";
            bool expected = true;

            var validator = new IbanValidator();

            // Act
            bool actual = validator.Validate(rekeningnummer);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LegeIbanGeeftFalseTerug()
        {
            string rekeningnummer = "";
            var validator = new IbanValidator();

            var result = validator.Validate(rekeningnummer);

            Assert.AreEqual(false, result);
        }
    }
}
