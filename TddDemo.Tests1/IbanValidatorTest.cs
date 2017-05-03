// <copyright file="IbanValidatorTest.cs">Copyright ©  2015</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddDemo;

namespace TddDemo.Tests
{
    /// <summary>This class contains parameterized unit tests for IbanValidator</summary>
    [PexClass(typeof(IbanValidator))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class IbanValidatorTest
    {
        /// <summary>Test stub for ValidateIban(String)</summary>
        [PexMethod]
        internal bool ValidateIbanTest([PexAssumeUnderTest]IbanValidator target, string input)
        {
            bool result = target.ValidateIban(input);
            return result;
            // TODO: add assertions to method IbanValidatorTest.ValidateIbanTest(IbanValidator, String)
        }
    }
}
