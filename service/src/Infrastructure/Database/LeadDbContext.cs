using Domain.Leads;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class LeadDbContext : DbContext
    {
        public LeadDbContext(DbContextOptions<LeadDbContext> options)
            : base(options) { }

        public DbSet<Lead> Leads => Set<Lead>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
                throw new ArgumentNullException(nameof(modelBuilder));
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeadDbContext).Assembly);
        }
    }
}