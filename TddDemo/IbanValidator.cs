using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo
{
    class IbanValidator
    {
        private const int IBAN_LENGTH = 18;

        IBankCodeProvider _provider;

        public IbanValidator(IBankCodeProvider provider)
        {
            _provider = provider;
        }

        public bool ValidateIban(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            input = RemoveWhitespace(input);
            if (CheckLength(input) &&
                CheckLettersAndNumbers(input) &&
                CheckBankCode(input))
            {
                return true;
            }

            return false;
        }

        private static bool CheckLettersAndNumbers(string input)
        {
            return input.ContainsOnlyLettersAndNumbers();
        }

        private static bool CheckLength(string input)
        {
            return input.Length == IBAN_LENGTH;
        }

        private bool CheckBankCode(string input)
        {
            string[] codes = _provider.BankCodes();
            return codes.Contains(input.Substring(4, 4));
        }

        private static string RemoveWhitespace(string input)
        {
            return input.Replace(" ", "");
        }
    }
}
