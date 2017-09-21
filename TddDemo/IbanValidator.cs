﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TddDemo
{
    internal class IbanValidator
    {
        IBankCodeResolver resolver = new BankCodeResolver();

        public IbanValidator(IBankCodeResolver resolver)
        {
            this.resolver = resolver;
        }

        public bool Validate(string iban)
        {
            iban = Normalize(iban);

            return CheckNotEmpty(iban)
                && CheckLength(iban)
                && CheckBankCode(iban);
        }

        private bool CheckBankCode(string iban)
        {
            try
            {
                return resolver.Resolve().Contains(ExtractBankCode(iban));
            }
            catch (Exception ex)
            {
                throw new BankCodeResolverNotAvailableException("", ex);
            }
        }

        private static string ExtractBankCode(string iban)
        {
            return iban.Substring(4, 4);
        }

        private static string Normalize(string iban)
        {
            return iban?.Replace(" ", "");
        }

        private static bool CheckNotEmpty(string iban)
        {
            return !string.IsNullOrEmpty(iban);
        }

        private static bool CheckLength(string iban)
        {
            const int ibanLength = 18;
            return iban.Length == ibanLength;
        }
    }
}
