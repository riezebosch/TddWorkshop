using System;

namespace TddDemo
{
    public class IbanValidator
    {
        public bool Validate(string input)
        {
            return (input != string.Empty);
        }
    }
}