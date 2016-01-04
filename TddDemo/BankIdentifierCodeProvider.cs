namespace TddDemo
{
    public class BankIdentifierCodeProvider 
        : IBankIdentifierCodeProvider
    {
        public bool ValidateBankCode(string bankCode)
        {
            return bankCode == "RABO" || bankCode == "INGB" || bankCode == "ABNA";
        }
    }
}