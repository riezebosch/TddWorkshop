using System;

namespace TddDemo
{
    public class Iban
    {
        private string _iban;

        /// <summary>
        /// Commentaar op de constructor
        /// </summary>
        /// <param name="iban">Het hoeft nog niet per se een valide iban te zijn, dat fixen we later.</param>
        public Iban(string iban)
        {
            _iban = iban;
        }

        private static string RemoveWhitespace(string iban)
        {
            return iban.Replace(" ", "");
        }

        /// <summary>
        /// Valideert een Nederlandse IBAN volgens ISO.....
        /// </summary>
        /// <returns>True voor een valide Nederlandse IBAN en false voor een invalide of niet Nederlands. </returns>
        public bool Validate()
        {
            var iban = RemoveWhitespace(_iban);
            //NL91ABNA0417164300
            //NL86INGB0002445588
            if (ValidateLandCode(iban) &&
                ValidateLength(iban))
            {
                return true;
            }

            return false;
        }

        private static bool ValidateLength(string iban)
        {
            return iban.Length == 18;
        }

        private static bool ValidateLandCode(string iban)
        {
            return iban.StartsWith("NL");
        }
    }
}