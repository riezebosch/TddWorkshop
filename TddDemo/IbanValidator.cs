using System;

namespace TddDemo
{
    public class IbanValidator
    {
        public IbanValidator()
        {
        }

        public bool Validate(string iban)
        {
            return (iban != "");
        }
    }
}