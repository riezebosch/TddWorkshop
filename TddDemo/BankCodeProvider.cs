using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo
{
    class BankCodeProvider : IBankCodeProvider
    {
        public string[] BankCodes()
        {
            return new[] { "INGB", "ZZZZ" };
        }
    }
}
