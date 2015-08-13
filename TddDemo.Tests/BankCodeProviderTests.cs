using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDemo.Tests
{
    [TestClass]
    public class BankCodeProviderTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            BankCodeProvider provider = new BankCodeProvider();

            // Act
            bool result = provider.IsThisInYourList("ABNA");

            //Assert
            Assert.IsTrue(result);
        }
    }
}
