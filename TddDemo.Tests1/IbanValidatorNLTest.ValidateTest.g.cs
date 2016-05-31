using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddDemo;
// <copyright file="IbanValidatorNLTest.ValidateTest.g.cs">Copyright ©  2015</copyright>
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
    public partial class IbanValidatorNLTest
    {

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorNLTest))]
[PexRaisedException(typeof(ArgumentNullException))]
public void ValidateTestThrowsArgumentNullException365()
{
    IbanValidatorNL ibanValidatorNL;
    bool b;
    ibanValidatorNL = new IbanValidatorNL((IBankCodeHelper)null);
    b = this.ValidateTest(ibanValidatorNL, (string)null);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorNLTest))]
public void ValidateTest273()
{
    IbanValidatorNL ibanValidatorNL;
    bool b;
    ibanValidatorNL = new IbanValidatorNL((IBankCodeHelper)null);
    b = this.ValidateTest(ibanValidatorNL, "");
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidatorNL);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorNLTest))]
public void ValidateTest817()
{
    IbanValidatorNL ibanValidatorNL;
    bool b;
    ibanValidatorNL = new IbanValidatorNL((IBankCodeHelper)null);
    b = this.ValidateTest(ibanValidatorNL, "NL");
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidatorNL);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorNLTest))]
public void ValidateTest466()
{
    IbanValidatorNL ibanValidatorNL;
    bool b;
    ibanValidatorNL = new IbanValidatorNL((IBankCodeHelper)null);
    b = this.ValidateTest(ibanValidatorNL, "NL\0\0");
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidatorNL);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorNLTest))]
public void ValidateTest7()
{
    IbanValidatorNL ibanValidatorNL;
    bool b;
    ibanValidatorNL = new IbanValidatorNL((IBankCodeHelper)null);
    b = this.ValidateTest(ibanValidatorNL, "NLĀ\0");
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidatorNL);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorNLTest))]
public void ValidateTest350()
{
    IbanValidatorNL ibanValidatorNL;
    bool b;
    ibanValidatorNL = new IbanValidatorNL((IBankCodeHelper)null);
    b = this.ValidateTest(ibanValidatorNL, "NL9\0");
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidatorNL);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorNLTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void ValidateTestThrowsNullReferenceException110()
{
    IbanValidatorNL ibanValidatorNL;
    bool b;
    ibanValidatorNL = new IbanValidatorNL((IBankCodeHelper)null);
    b = this.ValidateTest
            (ibanValidatorNL, "NL99\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0");
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorNLTest))]
public void ValidateTest572()
{
    IbanValidatorNL ibanValidatorNL;
    bool b;
    BankCodeHelper s0 = new BankCodeHelper();
    ibanValidatorNL = new IbanValidatorNL((IBankCodeHelper)s0);
    b = this.ValidateTest
            (ibanValidatorNL, "NL99\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0");
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidatorNL);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorNLTest))]
public void ValidateTest253()
{
    IbanValidatorNL ibanValidatorNL;
    bool b;
    ibanValidatorNL = new IbanValidatorNL((IBankCodeHelper)null);
    b = this.ValidateTest(ibanValidatorNL, "NL99B\0\0}L\0L\0");
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidatorNL);
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorNLTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void ValidateTestThrowsNullReferenceException207()
{
    IbanValidatorNL ibanValidatorNL;
    bool b;
    ibanValidatorNL = new IbanValidatorNL((IBankCodeHelper)null);
    b = this.ValidateTest(ibanValidatorNL, "NLĀNL59\0\0\0\0LLLLLLLLLLLLLLLLLLL");
}

[TestMethod]
[PexGeneratedBy(typeof(IbanValidatorNLTest))]
public void ValidateTest729()
{
    IbanValidatorNL ibanValidatorNL;
    bool b;
    ibanValidatorNL = new IbanValidatorNL((IBankCodeHelper)null);
    b = this.ValidateTest(ibanValidatorNL, "NLĀNLĀL");
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)ibanValidatorNL);
}
    }
}
