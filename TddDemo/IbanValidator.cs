﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo
{
    class IbanValidator
    {
        private const int IBAN_LENGTH = 18;

        public static bool ValidateIban(string input)
        {
            input = RemoveWhitespace(input);
            if (input.Length != IBAN_LENGTH)
            {
                return false;
            }

            if (!input.ContainsOnlyLettersAndNumbers())
            {
                return false;
            }

            if (!ContainsValidBankCode(input))
            {
                return false;
            }

            return true;
        }

        private static bool ContainsValidBankCode(string input)
        {
            return input.Substring(4, 4) == "INGB";
        }

        private static string RemoveWhitespace(string input)
        {
            return input.Replace(" ", "");
        }
    }
}
