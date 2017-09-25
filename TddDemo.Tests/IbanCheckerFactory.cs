using System;
using Xunit;

namespace TddDemo.Tests
{
    public class IbanCheckerFactoryTests
    {
        [Fact]
        public void NLIban_ReturnsIbanValidatorNL()
        {
            // Arrange
            string iban = "nl86ingb0002445588";
            Type expected = typeof(IbanCheckerNL); // IbanCheckerNL.class

            // Act
            IIbanChecker actual = IbanCheckerFactory.Create(iban);

            // Assert
            Assert.Equal(expected, actual.GetType()); // actual.getClass()
        }

        [Fact]
        public void BEIban_ReturnsIbanValidatorBE()
        {
            // Arrange
            string iban = "BE02 3751 1109 9940";
            Type expected = typeof(IbanCheckerBE); // IbanCheckerNL.class

            // Act
            IIbanChecker actual = IbanCheckerFactory.Create(iban);

            // Assert
            Assert.Equal(expected, actual.GetType()); // actual.getClass()
        }

        class IbanCheckerFactory
        {

            public static IIbanChecker Create(string iban)
            {
                if (iban.StartsWith("BE"))
                {
                    return new IbanCheckerBE();
                }
                return new IbanCheckerNL();
            }
        }
    }
}
