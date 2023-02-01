using Domain.Common;

namespace Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public PhoneNumber(string ddd, string number)
        {
            Number = number;
            DDD = ddd;
        }

        protected PhoneNumber()
        { }

        public string Number { get; set; }

        public string DDD { get; set; }

        public string FullNumber { get => $"{DDD}{Number}"; }

        public string FormatedNumber { get => $"({DDD}){Number}"; }

        public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.FullNumber;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
            yield return DDD;
        }
    }
}