using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace TddDemo.Tests
{
    [TestClass]
    public class ChecksumCalculatorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string iban = "NL76INGB0006384065";
            var calculator = new ChecksumCalculator();

            string result = calculator.TransformIban(iban);

            Assert.AreEqual("INGB0006384065NL00", result);
        }

        [TestMethod]
        public void ConvertBTo11()
        {
            string input = "B";
            var calculator = new ChecksumCalculator();

            string result = calculator.ToNumbers(input);

            Assert.AreEqual("11", result);
        }

        [TestMethod]
        public void ConvertATo10()
        {
            string input = "A";
            var calculator = new ChecksumCalculator();

            string result = calculator.ToNumbers(input);

            Assert.AreEqual("10", result);
        }

        [TestMethod]
        public void ConvertABTo1011()
        {
            string input = "AB";
            var calculator = new ChecksumCalculator();

            string result = calculator.ToNumbers(input);

            Assert.AreEqual("1011", result);
        }

        [TestMethod]
        public void ConvertAB9To10119()
        {
            string input = "AB9";
            var calculator = new ChecksumCalculator();

            string result = calculator.ToNumbers(input);

            Assert.AreEqual("10119", result);
        }

        [TestMethod]
        public void WetenWeNogNiet()
        {
            string input = "NL76INGB0006384065";
            var calculator = new ChecksumCalculator();

            BigInteger result = calculator.ToNumber(input);
            var expected = BigInteger.Parse("182316110006384065232100");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestChecksum()
        {
            string iban = "NLXXINGB0006384065";
            var calculator = new ChecksumCalculator();

            int result = calculator.Checksum(iban);

            Assert.AreEqual(76, result);
        }

        [TestMethod]
        public void TestOtherChecksum()
        {
            string iban = "NLXXINGB0004963507";
            var calculator = new ChecksumCalculator();

            int result = calculator.Checksum(iban);

            Assert.AreEqual(81, result);
        }
    }
}
