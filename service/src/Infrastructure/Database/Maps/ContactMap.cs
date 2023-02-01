using Domain.Leads.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Maps
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder
                .ToTable("Contact")
                .HasKey(x => x.Id)
                .HasName("contact_id");

            builder.OwnsOne(x => x.PhoneNumber, valueObject =>
            {
                valueObject.Property(x => x.Number).HasColumnName("number");
                valueObject.Property(x => x.DDD).HasColumnName("ddd");
            });

            builder.OwnsOne(x => x.Name, valueObject =>
            {
                valueObject.Property(x => x.FirstName).HasColumnName("first_name");
                valueObject.Property(x => x.LastName).HasColumnName("last_name");
            });

            builder.OwnsOne(x => x.Email);
        }
    }
}