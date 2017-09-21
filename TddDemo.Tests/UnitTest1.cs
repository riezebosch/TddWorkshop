using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
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

        private static void ValidateIban(string iban, bool expected, IBankCodeResolver resolver = null)
        {
            var validator = new IbanValidator(resolver ?? new BankCodeResolverMock("ABNA", "INGB"));

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
        
        [Fact]
        public void DifferentBankCode_Accepted()
        {
            ValidateIban("NL86 INGB 0002 4455 88", true);
        }

        [Fact]
        public void BankCodeRejectedByMockData()
        {
            ValidateIban("NL76ABNA0473408759", false, new BankCodeResolverMock());
        }

        [Fact]
        public void TestingBankCodesWithMockingFramework()
        {
            var resolver = Substitute.For<IBankCodeResolver>();
            resolver.Resolve().Returns(new string[] { "ABNA" });

            var sut = new IbanValidator(resolver);

            Assert.True(sut.Validate("NL76ABNA0473408759"));
        }

        [Fact]
        public void ExceptionFromResolverWrappedInBankCodeResolverNotAvailableException()
        {
            var resolver = Substitute.For<IBankCodeResolver>();
            resolver.Resolve().Throws<Exception>();

            var sut = new IbanValidator(resolver);

            var ex = Assert.Throws<BankCodeResolverNotAvailableException>(() => sut.Validate("NL76ABNA0473408759"));
            Assert.IsType<Exception>(ex.InnerException);
        }
    }

    internal class BankCodeResolverMock : IBankCodeResolver
    {
        private string[] codes;

        public BankCodeResolverMock(params string[] codes)
        {
            this.codes = codes;
        }

        public IEnumerable<string> Resolve()
        {
            return codes;
        }
    }
}
