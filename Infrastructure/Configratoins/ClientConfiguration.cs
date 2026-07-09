using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticSystem.Infrastructure.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.ClientId);
        
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        
        builder.Property(x => x.CreatedBy).HasMaxLength(100);
        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasIndex(x => x.UserId).IsUnique();

        builder.HasMany(x => x.CustomerContacts)
            .WithOne(c => c.Client)
            .HasForeignKey(c => c.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.SentRequests)
            .WithOne(r => r.Sender)
            .HasForeignKey(r => r.SenderClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ReceivedRequests)
            .WithOne(r => r.Receiver)
            .HasForeignKey(r => r.ReceiverClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
