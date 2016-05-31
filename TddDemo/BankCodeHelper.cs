using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo
{
    class BankCodeHelper : IBankCodeHelper
    {
        public bool CheckBankcode(string bankcode)
        {
            var bankcodes = new List<string> { "RABO", "INGB", "INGA" };
            return bankcodes.Contains(bankcode);
        }
    }
}
