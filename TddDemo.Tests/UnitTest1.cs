using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Text;
using System.IO;
using Microsoft.QualityTools.Testing.Fakes;

namespace TddDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InvalidEmptyIban()
        {
            // Arrange
            string iban = string.Empty;

            // Act
            var mock = new BankCodeHelperMock();
            bool result = new IbanValidator(mock).ValidateIban(iban);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidIbanReturnsTrueWhenValidating()
        {
            string iban = "NL78RABO0162136188";
            var mock = new BankCodeHelperMock(true);

            Assert.IsTrue(new IbanValidator(mock).ValidateIban(iban));
        }

        [TestMethod]
        public void GeenNederlandseIbanReturnsAltijdTrue()
        {
            string iban = "BE61310126985517";
            Assert.IsTrue(new IbanValidator(new BankCodeHelperMock(true)).ValidateIban(iban));
        }

        [TestMethod]
        public void TeKorteNederlandseIbanGeeftFalseTerug()
        {
            string iban = "NL78RABO016213618";
            Assert.IsFalse(new IbanValidator(new BankCodeHelperMock(true)).ValidateIban(iban));
        }

        [TestMethod]
        public void GeenControleCijfersInNederlandseIbanGeeftFalseTerug()
        {
            string iban = "NLX8RABO0162136188";
            Assert.IsFalse(new IbanValidator(new BankCodeHelperMock(true)).ValidateIban(iban));
        }

        [TestMethod]
        public void OngeldigeIbanGeeftBijValiderenFalseTerug()
        {
            string iban = "NL78INGA0162136188";
            var mock = new BankCodeHelperMock();

            Assert.IsFalse(new IbanValidator(mock).ValidateIban(iban));

        }

        [TestMethod]
        public void GeldigeBankCodeMetINGMoetOokWordenGoedGekeurd()
        {
            string iban = "NL78INGB0162136188";
            Assert.IsTrue(new IbanValidator(new BankCodeHelperMock(true)).ValidateIban(iban));
        }

        [TestMethod]
        public void IntegratieTestTussenIbanValidatorEnBankCodeHelper()
        {
            string iban = "NL78RABO0162136188";
            var mock = new BankCodeHelperMock();

            new IbanValidator(mock).ValidateIban(iban);

            Assert.IsTrue(mock.IsCalled);

        }

        class BankCodeHelperMock : IBankCodeHelper
        {
            private bool result;

            public BankCodeHelperMock(bool result = false)
            {
                this.result = result;
            }

            public bool IsCalled { get; internal set; }

            public bool CheckBankcode(string bankcode)
            {
                IsCalled = true;
                return result;
            }
        }

        [TestMethod]
        public void IntegratieTestTussenIbanValidatorEnBankCodeHelperMetBehulpVanMockingFramework()
        {
            string iban = "NL78RABO0162136188";
            var mock = new Mock<IBankCodeHelper>();
            mock
                .Setup(m => m.CheckBankcode(It.IsAny<string>()))
                .Returns(true)
                .Verifiable();

            new IbanValidator(mock.Object).ValidateIban(iban);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestDat10ConsoleLogIsAangeroepenMetExtraInterface()
        {
            var logger = new MockLogger();
            PrintFizzBuzz(logger);

            Assert.AreEqual(10, logger.Count);
        }

        interface ILogger
        {
            void Write(int i);
        }

        class MockLogger : ILogger
        {
            public int Count { get; private set; }

            public void Write(int i)
            {
                Count++;
            }
        }

        class ConsoleLogger : ILogger
        {
            public void Write(int i)
            {
                Console.Write(i);
            }
        }

        private void PrintFizzBuzz(ILogger logger)
        {
            for (int i = 0; i < 10; i++)
            {
                logger.Write(i);
            }
        }

        [TestMethod]
        public void TestDat10xConsoleLogIsAangeroepen()
        {
            var mock = new StringBuilder();
            Console.SetOut(new StringWriter(mock));

            PrintFizzBuzz();
            Assert.AreEqual("0123456789", mock.ToString());
        }

        private void PrintFizzBuzz()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i);
            }
        }

        [TestMethod]
        public void TestDat10xConsoleLogIsAangeroepen2()
        {
            int i = 0;
            Action<object> mock = (m) => i++;

            PrintFizzBuzz(mock);
            //PrintFizzBuzz(Console.Write);

            Assert.AreEqual(10, i);
        }

        private void PrintFizzBuzz(Action<object> mock)
        {
            for (int i = 0; i < 10; i++)
            {
                mock(i);
            }
        }


        [TestMethod]
        public void TestMetFakes()
        {
            Console.WriteLine(DateTime.Today);
            using (ShimsContext.Create())
            {
                Console.WriteLine(DateTime.Today);
                System.Fakes.ShimDateTime.TodayGet = () => new DateTime(2015, 04, 05);
                Console.WriteLine(DateTime.Today);

                int age = Calc(new DateTime(1982, 04, 05));
                Assert.AreEqual(33, age); 
            }
            Console.WriteLine(DateTime.Today);
        }

        private int Calc(DateTime birth)
        {
            return DateTime.Today.Year - birth.Year;
        }
    }
}
