using System;
using System.Text.RegularExpressions;

namespace TddDemo
{
    public class IbanValidator
    {
        public bool Validate(string input)
        {
            return Regex.IsMatch(input, "^NL.*");
        }
    }
}