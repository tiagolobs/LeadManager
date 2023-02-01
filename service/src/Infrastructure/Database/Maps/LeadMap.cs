using Domain.Leads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Maps
{
    public class LeadMap : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder
                .ToTable("Lead")
                .HasKey(x => x.Id)
                .HasName("lead_id");

            builder
               .Property(x => x.Description)
               .HasColumnName("description");

            builder
               .Property(x => x.Price)
               .HasColumnName("price");

            builder
               .Property(x => x.Suburb)
               .HasColumnName("suburb");

            builder
               .Property(x => x.JobCategory)
               .HasColumnName("jobCategory");

            builder
               .Property(x => x.LeadStatus)
               .HasColumnName("leadStatus");

            builder
               .Property(x => x.Date)
               .HasColumnName("date");

            builder
                .HasOne(x => x.Contact)
                .WithMany(x => x.Leads);
        }
    }
}