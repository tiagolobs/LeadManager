using Domain.Common;

namespace Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly LeadDbContext _context;

        public UnitOfWork(LeadDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}