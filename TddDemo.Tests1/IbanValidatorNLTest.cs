// <copyright file="IbanValidatorNLTest.cs">Copyright ©  2015</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddDemo;

namespace TddDemo.Tests
{
    /// <summary>This class contains parameterized unit tests for IbanValidatorNL</summary>
    [PexClass(typeof(IbanValidatorNL))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class IbanValidatorNLTest
    {
        /// <summary>Test stub for Validate(String)</summary>
        [PexMethod]
        internal bool ValidateTest([PexAssumeUnderTest]IbanValidatorNL target, string iban)
        {
            bool result = target.Validate(iban);
            return result;
            // TODO: add assertions to method IbanValidatorNLTest.ValidateTest(IbanValidatorNL, String)
        }
    }
}
