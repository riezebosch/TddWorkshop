using System.Collections.Generic;

namespace TddDemo
{
    class BankCodeResolver : IBankCodeResolver
    {
        public IEnumerable<string> Resolve()
        {
            return new string[] { "ABNA", "INGB", "ABNB" };
        }
    }
}
