using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddDemo;
// <copyright file="IbanValidatorTest.ValidateIbanTest.g.cs">Copyright ©  2015</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace TddDemo.Tests
{
    public partial class IbanValidatorTest
    {

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void ValidateIbanTestThrowsNullReferenceException346()
{
    IbanValidator ibanValidator;
    bool b;
    ibanValidator = new IbanValidator((IBankCodeProvider)null);
    b = this.ValidateIbanTest(ibanValidator, (string)null);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorTest))]
public void ValidateIbanTest789()
{
    IbanValidator ibanValidator;
    bool b;
    ibanValidator = new IbanValidator((IBankCodeProvider)null);
    b = this.ValidateIbanTest(ibanValidator, "");
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidator);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorTest))]
public void ValidateIbanTest971()
{
    IbanValidator ibanValidator;
    bool b;
    ibanValidator = new IbanValidator((IBankCodeProvider)null);
    b = this.ValidateIbanTest(ibanValidator, "\0");
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidator);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void ValidateIbanTestThrowsNullReferenceException38()
{
    IbanValidator ibanValidator;
    bool b;
    ibanValidator = new IbanValidator((IBankCodeProvider)null);
    b = this.ValidateIbanTest(ibanValidator, new string('\0', 18));
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorTest))]
public void ValidateIbanTest36()
{
    IbanValidator ibanValidator;
    bool b;
    ibanValidator = new IbanValidator((IBankCodeProvider)null);
    b = this.ValidateIbanTest(ibanValidator, new string('?', 18));
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidator);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorTest))]
public void ValidateIbanTest578()
{
    IbanValidator ibanValidator;
    bool b;
    BankCodeProvider s0 = new BankCodeProvider();
    ibanValidator = new IbanValidator((IBankCodeProvider)s0);
    b = this.ValidateIbanTest(ibanValidator, new string('\0', 18));
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidator);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorTest))]
public void ValidateIbanTest107()
{
    IbanValidator ibanValidator;
    bool b;
    BankCodeProvider s0 = new BankCodeProvider();
    ibanValidator = new IbanValidator((IBankCodeProvider)s0);
    b = this.ValidateIbanTest(ibanValidator, "\0\0\0\0INGB\0\0\0\0\0\0\0\0\0\0");
    Assert.AreEqual<bool>(true, b);
    Assert.IsNotNull((object)ibanValidator);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorTest))]
public void ValidateIbanTest338()
{
    IbanValidator ibanValidator;
    bool b;
    ibanValidator = new IbanValidator((IBankCodeProvider)null);
    b = this.ValidateIbanTest(ibanValidator, " ");
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidator);
}
    }
}
