using System;
using Xunit;

namespace TddDemo.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyIban_Validating_Reject()
        {
            ValidateIban("", false);
        }

        private static void ValidateIban(string iban, bool expected)
        {
            var validator = new IbanValidator();

            // Act
            var result = validator.Validate(iban);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ValidIban_Validating_Accepted()
        {
            ValidateIban("NL76 ABNA 0473 4087 59", true);
        }

        [Fact]
        public void InvalidIban_Validating_Reject()
        {
            ValidateIban("NL76 ABNA 0473 4087 5", false);
        }
    }
}
