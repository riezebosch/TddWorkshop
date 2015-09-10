using System;
using System.IdentityModel.Selectors;

namespace TddDemo.Tests
{
    internal class CustomUserNamePasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != "Manuel" || password != "P2ssw0rd")
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
}