using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace TddDemo.Tests
{
    [Binding]
    public class BelgianIbanSteps
    {
        private string iban;
        private IbanValidator validator;
        private bool result;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(string p0)
        {
            validator = new IbanValidator();
            iban = p0;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            result = validator.Validate(iban);
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(bool p0)
        {
            Assert.AreEqual(p0, result);
        }
    }
}
