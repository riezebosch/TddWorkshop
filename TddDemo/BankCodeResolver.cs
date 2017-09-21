namespace TddDemo
{
    internal partial class IbanValidator
    {
        class BankCodeResolver
        {
            public string[] Resolve()
            {
                return new string[] { "ABNA", "INGB" };
            }
        }
    }
}
