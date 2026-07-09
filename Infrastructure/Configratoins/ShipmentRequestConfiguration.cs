using Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticSystem.Infrastructure.Data.Configurations;

public class ShipmentRequestConfiguration : IEntityTypeConfiguration<ShipmentRequest>
{
    public void Configure(EntityTypeBuilder<ShipmentRequest> builder)
    {
        builder.HasKey(x => x.ShipmentRequestId);
        
        builder.Property(x => x.City).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Notes).HasMaxLength(500);
        builder.Property(x => x.TotalWeight).HasColumnType("decimal(10,2)");
        
        builder.Property(x => x.Status).HasColumnType("tinyint");
        builder.Property(x => x.Priority).HasColumnType("tinyint");

        builder.Property(x => x.CreatedBy).HasMaxLength(100);
        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasIndex(x => x.SenderClientId);
        builder.HasIndex(x => x.ReceiverClientId);

        builder.HasMany(x => x.Packages)
            .WithOne(p => p.ShipmentRequest)
            .HasForeignKey(p => p.ShipmentRequestId)
            .OnDelete(DeleteBehavior.Restrict);

        // 1-to-1 ShipmentRequest - Shipment
        builder.HasOne(x => x.Shipment)
            .WithOne(s => s.ShipmentRequest)
            .HasForeignKey<Shipment>(s => s.ShipmentRequestId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
