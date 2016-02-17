using System.Collections.Generic;

namespace TddDemo
{
    public interface IBankCodeProvider
    {
        IList<string> BankCodes { get; }
    }
}