﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo
{
    internal class IbanValidator
    {
        public bool Validate(string iban)
        {
            return CheckNotEmpty(iban)
                && CheckLength(iban);
        }

        private static bool CheckNotEmpty(string iban)
        {
            return !string.IsNullOrEmpty(iban);
        }

        private static bool CheckLength(string iban)
        {
            const int ibanLength = 22;
            return iban.Length == ibanLength;
        }
    }
}
