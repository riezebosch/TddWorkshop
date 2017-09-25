namespace TddDemo.Tests
{
    class IbanCheckerNL : IIbanChecker
    {
        public bool TestIban(string iban)
        {
            iban = Normalize(iban);

            return IsNotEmpty(iban) &&
                StartsWithLandCode(iban) &&
                HasCorrectLength(iban);
        }

        private static string Normalize(string iban)
        {
            return iban
                .Replace(" ", "")
                .ToUpper();
        }

        private static bool HasCorrectLength(string iban)
        {
            return iban.Length == 18;
        }

        private static bool StartsWithLandCode(string iban)
        {
            return iban.StartsWith("NL");
        }

        private static bool IsNotEmpty(string iban)
        {
            return !iban.Equals("");
        }
    }
}
