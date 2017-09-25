using System;
using Xunit;

namespace TddDemo.Tests
{
    public class IbanCheckerNLTests
    {
        [Fact]
        public void EmptyIban_TestIban_ReturnsFalse()
        {
            Execute("", false);
        }

        [Fact]
        public void ValidIban_TestIban_ReturnsTrue()
        {
            Execute("NL86 INGB 0002 4455 88", true);
        }

        [Fact]
        public void LandCodeNotStartWithN_TestIban_ReturnsFalse()
        {
            Execute("XX86 INGB 0002 4455 88", false);
        }

        [Fact]
        public void LandCodeNotStartWithNL_TestIban_ReturnsFalse()
        {
            Execute("NX86 INGB 0002 4455 88", false);
        }

        [Fact]
        public void LengthNot18_TestIban_ReturnsFalse()
        {
            Execute("NL86INGB000244558", false);
        }

        [Fact]
        public void ValidIbanWithoutSpaces_TestIban_ReturnsTrue()
        {
            Execute("NL86INGB0002445588", true);
        }

        private static void Execute(string iban, bool expected)
        {
            IbanCheckerNL target = new IbanCheckerNL();
            Assert.Equal(expected, target.TestIban(iban));
        }

        [Fact]
        public void ValidIbanWithLowerCase_TestIban_ReturnsTrue()
        {
            Execute("nl86ingb0002445588", true);
        }

        [Fact]
        public void ValidBelgianIban_TestIban_ReturnsFalse()
        {
            Execute("BE02 3751 1109 9940", false);
        }
    }
}
