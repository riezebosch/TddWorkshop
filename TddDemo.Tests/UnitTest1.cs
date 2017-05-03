using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenValidIban_WhenValidate_ThenResultIsTrue()
        {
            // Arrange
            string input = "NL74 INGB 0671 5336 65";
            bool expected = true;

            // Act
            bool actual = ValidateIban(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static bool ValidateIban(string input)
        {
            if (input.Replace(" ", "").Length != 18)
            {
                return false;
            }

            return true;
        }

        [TestMethod]
        public void GivenInvalidIban_WhenValidate_ThenResultIsFalse()
        {
            // Arrange
            string input = "NL74 INGB 0671 5336 6";
            bool expected = false;

            // Act
            bool actual = ValidateIban(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenValidIbanWithoutWhitespace_WhenValidate_ThenResultIsTrue()
        {
            // Arrange
            string input = "NL74INGB0671533665";
            bool expected = true;

            // Act
            bool actual = ValidateIban(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
