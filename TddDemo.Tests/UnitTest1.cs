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
            return true;
        }
    }
}
