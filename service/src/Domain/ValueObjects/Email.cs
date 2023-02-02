using Domain.Common;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string EmailAddress { get; set; }

        public Email(string emailAddress)
        {
            if (!IsValid(emailAddress))
            {
                throw new ArgumentException("Email inválido");
            }

            EmailAddress = emailAddress;
        }

        public static bool IsValid(string email)
        {
            var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }

        protected Email()
        { }

        public static implicit operator string(Email email) => email.EmailAddress;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailAddress;
        }
    }
}