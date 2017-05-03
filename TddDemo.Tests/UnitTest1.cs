using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            string input = "NL74 INGB 0671 5336 65";
            bool expected = true;

            // Act
            bool actual = true;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
