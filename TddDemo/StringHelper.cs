using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo
{
    internal static class StringHelper
    {
        public static bool ContainsOnlyLettersAndNumbers(string input)
        {
            return !input.Contains("?");
        }
    }
}
