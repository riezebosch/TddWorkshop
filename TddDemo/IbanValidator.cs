using System;

namespace TddDemo
{
    public class IbanValidator
    {
        public bool Validate(string rekeningnummer)
        {
            Console.WriteLine(rekeningnummer.Length);

            if (rekeningnummer != null && rekeningnummer.Length > 8)
            {
                Console.WriteLine(rekeningnummer[0]);
            }

            return true;
        }
    }
}