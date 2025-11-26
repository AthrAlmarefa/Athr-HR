using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Users.Rules
{
    internal class EmailFormatRule : IBusinessRule
    {
        private readonly string _email;

        public EmailFormatRule(string email)
        {
            _email = email;
        }
        public Error Error => new(
        "User.EmailFormat",
        "Email must be in a valid format (e.g., user@example.com)");
        public bool IsBroken()
        {
            if (string.IsNullOrWhiteSpace(_email))
                return true;

            try
            {
                return !Regex.IsMatch(_email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            }
            catch (RegexMatchTimeoutException)
            {
                return true;
            }
        }
    }
}
