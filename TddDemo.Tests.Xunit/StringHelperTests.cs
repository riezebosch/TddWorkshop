using System;
using Xunit;

namespace TddDemo.Tests
{
    public class StringHelperTests
    {
        [Fact]
        public void GivenInputIsALetter_WhenContainsOnlyLetters_ThenResultIsTrue()
        {
            Assert.True(StringHelper.ContainsOnlyLettersAndNumbers("A"));
        }

        [Fact]
        public void XunitGeeftDuidelijkeFoutmeldingenBijCollectionsAsserten()
        {
            int[] expected = { 1, 2, 3, 4 };
            int[] actual = { 4, 5, 6 };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenInputIsNull_WhenValidate_ThenArgumentNullExpection()
        {
            Assert.Throws<ArgumentNullException>(() => StringHelper.ContainsOnlyLettersAndNumbers(null));
        }
    }
}
