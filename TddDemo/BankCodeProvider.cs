using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo
{
    class BankCodeProvider : IBankCodeProvider
    {
        public IList<string> BankCodes => new string[] { "RABO", "INGB" };
    }
}
