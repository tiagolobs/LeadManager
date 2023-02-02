using Domain.Leads;

namespace Application.Leads.GetLeads
{
    public class LeadDto
    {
        public string ContactFirstName { get; set; }
        public DateTime Date { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ContactFullName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }

        public LeadStatus LeadStatus { get; set; }
    }
}