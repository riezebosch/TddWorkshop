using System;
using Xunit;

namespace TddDemo.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyIban_Reject()
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
        public void ValidIban_Accepted()
        {
            ValidateIban("NL76 ABNA 0473 4087 59", true);
        }

        [Fact]
        public void InvalidIban_Reject()
        {
            ValidateIban("NL76 ABNA 0473 4087 5", false);
        }

        [Fact]
        public void ValidIbanWithoutSpaces_Accepted()
        {
            ValidateIban("NL76ABNA0473408759", true);
        }

        [Fact]
        public void NullIban_Reject()
        {
            ValidateIban(null, false);
        }

        [Fact]
        public void InvalidBankCode_Rejected()
        {
            ValidateIban("NL76 ABNB 0473 4087 59", false);
        }

    }
}
