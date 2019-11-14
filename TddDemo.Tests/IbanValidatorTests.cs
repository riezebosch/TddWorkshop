using System;
using Xunit;

namespace TddDemo.Tests
{
    public class IbanValidatorTests
    {
        [Fact]
        public void InputIsEmpty_IsValid_False()
        {
            // Arrange
            const string input = "";
            const bool expected = false;

            // Act
            bool actual = IbanValidator.IsValid(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
