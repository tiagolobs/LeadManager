using Domain.Leads;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Leads
{
    public class LeadRepository : ILeadRepository
    {
        protected readonly LeadDbContext _context;

        public LeadRepository(LeadDbContext context)
        {
            _context = context;
        }

        public async Task<List<Lead>> GetAllAsync(LeadStatus? status)
        {
            if (status == null) return await _context.Leads.Include(x => x.Contact).ToListAsync();
            return await _context.Leads.Where(x => x.LeadStatus == status).Include(x => x.Contact).ToListAsync();
        }

        public async Task<Lead?> GetByIdAsync(int id)
        {
            return await _context.Leads.Where(x => x.Id == id).Include(x => x.Contact).FirstOrDefaultAsync();
        }
    }
}