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
            ExecuteValidate("NL74 INGB 0671 5336 65", true);
        }

        private static void ExecuteValidate(string input, bool expected)
        {
            Assert.AreEqual(expected, ValidateIban(input));
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
            ExecuteValidate("NL74 INGB 0671 5336 6", false);
        }

        [TestMethod]
        public void GivenValidIbanWithoutWhitespace_WhenValidate_ThenResultIsTrue()
        {
            ExecuteValidate("NL74INGB0671533665", true);
        }
    }
}
