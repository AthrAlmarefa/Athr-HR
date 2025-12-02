using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Users.Rules
{
    internal class PhoneNumberFormatRule : IBusinessRule
    {
        private readonly string _phoneNumber;

        public PhoneNumberFormatRule(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public Error Error => UserErrors.InvalidPhoneNumberFormat;

        public bool IsBroken()
        {
            if (string.IsNullOrWhiteSpace(_phoneNumber))
                return true;

            var phone = _phoneNumber.StartsWith("+")
                ? _phoneNumber.Substring(1)
                : _phoneNumber;

            return !phone.All(char.IsDigit) || phone.Length < 10 || phone.Length > 15;
        }
    }
}
