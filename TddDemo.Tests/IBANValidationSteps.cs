using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using TechTalk.SpecFlow;

namespace TddDemo.Tests
{
    [Binding]
    public class IBANValidationSteps
    {
        [Given(@"I have entered ""(.*)"" into the validator")]
        public void GivenIHaveEnteredIntoTheValidator(string iban)
        {
            ScenarioContext.Current.Set(iban, "iban");
        }

        [When(@"I execute Validate")]
        public void WhenIExecuteValidate()
        {
            var iban = ScenarioContext.Current.Get<string>("iban");

            var mock = Substitute.For<IBankCodeProvider>();
            mock.BankCodes().Returns(new[] { "INGB" });

            var validator = new IbanValidator(mock);

            var result = validator.ValidateIban(iban);
            ScenarioContext.Current.Set(result, "result");
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBeTrue(bool expected)
        {
            var result = ScenarioContext.Current.Get<bool>("result");
            Assert.AreEqual(expected, result);
        }
    }
}
