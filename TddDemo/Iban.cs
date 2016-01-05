using System;

namespace TddDemo
{
    public class Iban
    {
        private readonly IBankIdentifierCodeProvider _bic;
        private string _iban;
        private string _originalIban;
        private string input;

        public string BankCode
        {
            get
            {
                return _iban.Substring(4, 4);
            }
        }

        /// <summary>
        /// Commentaar op de constructor
        /// </summary>
        /// <param name = "iban">Het hoeft nog niet per se een valide iban te zijn, dat fixen we later.</param>
        public Iban(string iban, 
            IBankIdentifierCodeProvider bic)
        {
            if (iban == null)
            {
                throw new ArgumentNullException("iban");
            }

            _originalIban = iban;
            _iban = RemoveWhitespace(iban);
            _bic = bic;
        }

        public Iban(string input) :
            this (input, new BankIdentifierCodeProvider())
        {
            
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
       
            //NL91ABNA0417164300
            //NL86INGB0002445588
            if (ValidateLandCode(_iban) && 
                ValidateLength(_iban) 
                && _bic.ValidateBankCode(BankCode)
                )
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