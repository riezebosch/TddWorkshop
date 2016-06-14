using System;
using System.Numerics;
using System.Text;

namespace TddDemo
{
    public class ChecksumCalculator
    {
        public ChecksumCalculator()
        {
        }

        public string TransformIban(string iban)
        {
            return iban.Substring(4) + "NL00";

        }

        public string ToNumbers(string input)
        {
            var sb = new StringBuilder();
            foreach (var c in input)
            {
                if (char.IsLetter(c))
                {
                    sb.Append(c - 'A' + 10);
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public BigInteger ToNumber(string input)
        {
            return BigInteger.Parse(ToNumbers(TransformIban(input)));
        }

        public int Checksum(string iban)
        {
            return 98 - (int)(ToNumber(iban) % new BigInteger(97));
        }
    }
}