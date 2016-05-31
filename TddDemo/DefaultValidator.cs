using System.Text.RegularExpressions;

namespace TddDemo
{
    class DefaultValidator : IIbanValidator
    {
        public bool Validate(string iban)
        {
            return Regex.IsMatch(iban, "[A-Z]{2}.*");
        }
    }
}