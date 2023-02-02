using Domain.Leads;

namespace Application.Leads.GetLeads
{
    public static class LeadExtension
    {
        public static LeadDto ToDto(this Lead lead)
        {
            return new LeadDto
            {
                Id = lead.Id,
                LeadStatus = lead.LeadStatus,
                Category = Enum.GetName(typeof(JobCategory), lead.JobCategory),
                ContactEmail = lead.Contact.Email,
                ContactFirstName = lead.Contact.Name.FirstName,
                ContactFullName = lead.Contact.Name,
                ContactPhoneNumber = lead.Contact.PhoneNumber,
                Date = lead.Date,
                Description = lead.Description,
                Price = lead.Price,
                Suburb = lead.Suburb
            };
        }
    }
}