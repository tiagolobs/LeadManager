using Domain.Common;
using Domain.Leads.Contacts;

namespace Domain.Leads
{
    public class Lead : BaseEntity
    {
        public Contact Contact { get; set; }
        public DateTime Date { get; set; }
        public string Suburb { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public JobCategory JobCategory { get; set; }
        public LeadStatus LeadStatus { get; set; }

        private const int PriceLimit = 500;

        private const decimal PriceLimitDiscount = 0.9M;

        public event LeadAcceptedEventHandler LeadAccepted;

        public Lead(Contact contact, DateTime date, string suburb, string description, decimal price, JobCategory jobCategory)
        {
            Contact = contact;
            Date = date;
            Suburb = suburb;
            Description = description;
            Price = price;
            JobCategory = jobCategory;
            LeadStatus = LeadStatus.Invited;
        }

        public Lead()
        { }

        public void UpdateInitialStatus(bool accepted)
        {
            if (accepted)
            {
                if (Price > PriceLimit)
                {
                    Price = Price * PriceLimitDiscount;
                }
                LeadStatus = LeadStatus.Accepted;
                var eventArg = new LeadAcceptedEventArgs(this);
                LeadAccepted?.Invoke(this, eventArg);
            }
            else LeadStatus = LeadStatus.Declined;
        }
    }
}