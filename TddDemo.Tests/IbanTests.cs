using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class IbanTests
    {
        [TestMethod]
        public void EenValideNederlandseIbanMetSpaties_BijValideren_GeeftAlsResultaatTrue()
        {
            // Arrange
            var input = "NL86 INGB 0002 4455 88";
            var iban = new Iban(input);

            bool expected = true;

            // Act
            bool actual = iban.Validate();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EenValideNederlandseIbanZonderSpaties_BijValideren_GeeftTrueTerug()
        {
            // Arrange
            var input = "NL86INGB0002445588";
            var iban = new Iban(input);

            bool expected = true;

            // Act
            bool actual = iban.Validate();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IbanMetLengteKleinerDan18_BijValideren_GeeftFalseTerug()
        {
            // Arrange
            var input = "NL86INGB000244558";
            var iban = new Iban(input);

            bool expected = false;

            // Act
            bool actual = iban.Validate();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AndereValideIban_BijValideren_GeeftTrueTerug()
        {
            var input = "NL91ABNA0417164300";
            var iban = new Iban(input);

            var actual = iban.Validate();

            Assert.AreEqual(true, actual);
        }
    }
}
