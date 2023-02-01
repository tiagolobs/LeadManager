using Domain.Common;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Email : ValueObject
    {
        private readonly string _emailAddress;

        public Email(string emailAddress)
        {
            if (!IsValid(emailAddress))
            {
                throw new ArgumentException("Email inválido");
            }

            _emailAddress = emailAddress;
        }

        public static bool IsValid(string email)
        {
            var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }

        protected Email()
        { }

        public static implicit operator string(Email email) => email._emailAddress;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _emailAddress;
        }
    }
}