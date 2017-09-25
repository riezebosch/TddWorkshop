using System;
using Xunit;

namespace TddDemo.Tests
{
    public class IbanCheckerBETests
    {
        private static void Execute(string iban, bool expected)
        {
            IbanCheckerBE target = new IbanCheckerBE();
            Assert.Equal(expected, target.TestIban(iban));
        }
        
        [Fact]
        public void ValidIban_TestIban_ReturnsTrue()
        {
            Execute("BE02 3751 1109 9940", true);
        }
    }
}
