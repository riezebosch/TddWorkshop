using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Moq;

namespace TddDemo.Tests
{
    [TestClass]
    public class IbanTests
    {
        [TestMethod]
        public void EenValideNederlandseIbanMetSpaties_BijValideren_GeeftAlsResultaatTrue()
        {
            // Arrange
            var input = "NL86 INGB 0002 4455 88";
            var iban = new Iban(input, new BankIdentifierCodeProviderMock(true));

            bool expected = true;

            // Act
            bool actual = iban.Validate();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EenValideNederlandseIbanZonderSpaties_BijValideren_GeeftTrueTerug()
        {
            // Arrange
            var input = "NL86INGB0002445588";
            var iban = new Iban(input, new BankIdentifierCodeProviderMock(true));

            bool expected = true;

            // Act
            bool actual = iban.Validate();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IbanMetLengteKleinerDan18_BijValideren_GeeftFalseTerug()
        {
            // Arrange
            var input = "NL86INGB000244558";
            var iban = new Iban(input, new BankIdentifierCodeProviderMock(true));

            bool expected = false;

            // Act
            bool actual = iban.Validate();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AndereValideIban_BijValideren_GeeftTrueTerug()
        {
            var input = "NL91ABNA0417164300";
            var iban = new Iban(input, new BankIdentifierCodeProviderMock(true));

            var actual = iban.Validate();

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateThrowsNullReferenceException330()
        {
            new Iban(null);
        }

        [TestMethod]
        public void IbanMetOngeldigeBankCode_BijValideren_GeeftFalseTerug()
        {
            var iban = new Iban("NL91XXXX0417164300", new BankIdentifierCodeProviderMock());

            Assert.IsFalse(iban.Validate());
        }

        [TestMethod]
        public void IbanMetOngeldigeBankCode_BijValideren_GeeftFalseTerug_MetMockingFramework()
        {
            var bic = new Mock<IBankIdentifierCodeProvider>();
            bic.
                Setup(m => m.ValidateBankCode(It.IsAny<string>())).
                Returns(false)
                .Verifiable();

            bic.Setup(m => m.ValidateBankCode("XXXX"));

            var iban = new Iban("NL91RABO0417164300", bic.Object);

            Assert.IsFalse(iban.Validate());
            bic.Verify();
        }

        [TestMethod]
        public void TestRetrieveBankCodeFromIban()
        {
            var iban = new Iban("NL91XXXX0417164300");
            Assert.AreEqual("XXXX", iban.BankCode);
        }

        [TestMethod]
        public void TestRetreiveBankCodeFromIbanWithSpaces()
        {
            var iban = new Iban("NL 91 XXXX 0417164300");

            // Hier gebruik ik het Shouldly framework
            // voor assertions, wat voor veel leesbare
            // validaties zorgt!
            iban.BankCode.ShouldBe("XXXX");
        }
    }
}
