using System;
using System.Text.RegularExpressions;

namespace TddDemo
{
    public class IbanValidator
    {
        public IbanValidator()
        {
        }

        public bool Validate(string iban)
        {
            return Regex.IsMatch(iban, @"^NL\d{2}");
        }
    }
}