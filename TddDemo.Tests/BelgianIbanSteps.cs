using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace TddDemo.Tests
{
    [Binding]
    public class BelgianIbanSteps
    {
        private IbanValidator validator;
        private string input;
        private bool result;

        [Given(@"I have entered ""(.*)""")]
        public void GivenIHaveEntered(string p0)
        {
            validator = new IbanValidator();
            input = p0;
        }
        
        [When(@"I validate")]
        public void WhenIValidate()
        {
            result = validator.Validate(input);
        }
        
        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(bool expected)
        {
            Assert.AreEqual(expected, result);
        }
    }
}
