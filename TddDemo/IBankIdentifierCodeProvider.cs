namespace TddDemo
{
    public interface IBankIdentifierCodeProvider
    {
        bool ValidateBankCode(string bankCode);
    }
}