using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

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

        [TestMethod]
        public void MSTestGeeftOnduidelijkeFoutmeldingenBijCollectionsAsserten()
        {
            int[] expected = { 1, 2, 3, 4 };
            int[] actual = { 4,5,6, 7 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldlyMaaktEenHoopGoedWatMSTestLaatLiggen()
        {
            int[] expected = { 1, 2, 3, 4 };
            int[] actual = { 4, 5, 6, 7 };

            expected.ShouldBe(actual);
        }
    }
}
