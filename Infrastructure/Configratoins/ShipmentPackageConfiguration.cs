using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticSystem.Infrastructure.Data.Configurations;

public class ShipmentPackageConfiguration : IEntityTypeConfiguration<ShipmentPackage>
{
    public void Configure(EntityTypeBuilder<ShipmentPackage> builder)
    {
        builder.HasKey(x => x.ShipmentPackageId);
        
        builder.Property(x => x.Volume).HasColumnType("decimal(10,2)");
        builder.Property(x => x.Weight).HasColumnType("decimal(10,2)");
        builder.Property(x => x.Description).HasMaxLength(255);
        
        builder.Property(x => x.Category).HasColumnType("tinyint");

        builder.Property(x => x.CreatedBy).HasMaxLength(100);
        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasIndex(x => x.ShipmentRequestId);
    }
}
