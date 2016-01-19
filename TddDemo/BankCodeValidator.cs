using System.Linq;

namespace TddDemo
{
    class BankCodeValidator : IBankCodeValidator
    {
        public bool IsValidBankCode(string iban)
        {
            var bankcode = iban.Substring(4, 4);
            string[] codes = {"RABO"};
            return codes.Contains(bankcode);
        }
    }
}