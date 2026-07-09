using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticSystem.Infrastructure.Data.Configurations;

public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.HasKey(x => x.ShipmentId);
        
        builder.Property(x => x.Notes).HasMaxLength(500);
        builder.Property(x => x.Tags).HasMaxLength(255);
        builder.Property(x => x.Fees).HasColumnType("decimal(18,2)");
        
        builder.Property(x => x.CurrentState).HasColumnType("tinyint");

        builder.Property(x => x.CreatedBy).HasMaxLength(100);
        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasIndex(x => x.ShipmentRequestId).IsUnique();

        builder.HasMany(x => x.ShipmentAssignments)
            .WithOne(sa => sa.Shipment)
            .HasForeignKey(sa => sa.ShipmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.StateHistories)
            .WithOne(sh => sh.Shipment)
            .HasForeignKey(sh => sh.ShipmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ProofDocuments)
            .WithOne(pd => pd.Shipment)
            .HasForeignKey(pd => pd.ShipmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Notifications)
            .WithOne(n => n.Shipment)
            .HasForeignKey(n => n.ShipmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
