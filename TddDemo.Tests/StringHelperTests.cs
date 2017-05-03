using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class StringHelperTests
    {
        [TestMethod]
        public void GivenInputIsALetter_WhenContainsOnlyLetters_ThenResultIsTrue()
        {
            Assert.IsTrue(StringHelper.ContainsOnlyLettersAndNumbers("A"));
        }
    }
}
