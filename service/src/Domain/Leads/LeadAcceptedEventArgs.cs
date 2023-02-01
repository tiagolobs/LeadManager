namespace Domain.Leads
{
    public class LeadAcceptedEventArgs : EventArgs
    {
        public Lead Lead { get; set; }

        public LeadAcceptedEventArgs(Lead lead)
        {
            Lead = lead;
        }
    }

    public delegate void LeadAcceptedEventHandler(object sender, LeadAcceptedEventArgs e);
}