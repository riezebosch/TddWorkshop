using System;

namespace TddDemo
{
    public class IbanValidator
    {
        public bool Validate(string iban)
        {
            if (HasCountryCode(iban) &&
                HasCheckDigits(iban))
            {
                return true;
            }

            return false;
        }

        private static bool HasCountryCode(string iban)
        {
            return iban.StartsWith("NL");
        }

        private static bool HasCheckDigits(string iban)
        {
            return char.IsNumber(iban[2]) && char.IsNumber(iban[3]);
        }
    }
}