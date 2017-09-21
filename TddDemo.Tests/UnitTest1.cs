using System;
using Xunit;

namespace TddDemo.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyIban_Validating_Reject()
        {
            // Arrange
            var iban = "";
            var expected = false;

            // Act
            var result = Validate(iban);

            // Assert
            Assert.Equal(expected, result);
        }

        private static bool Validate(string iban)
        {
            return false;
        }
    }
}
