using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Leads.Contacts
{
    public class Contact : BaseEntity
    {
        public Name Name { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Email Email { get; set; }

        public virtual List<Lead> Leads { get; private set; }
    }
}