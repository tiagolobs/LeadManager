namespace Domain.Leads
{
    public interface ILeadRepository
    {
        Task<List<Lead>> GetAllAsync(LeadStatus? status);

        Task<Lead?> GetByIdAsync(int id);
    }
}