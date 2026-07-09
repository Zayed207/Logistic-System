using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticSystem.Infrastructure.Data.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.VehicleId);
        
        builder.Property(x => x.Lot).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Type).IsRequired().HasMaxLength(50);
        builder.Property(x => x.PlateNumber).IsRequired().HasMaxLength(20);
        builder.Property(x => x.MaxWeight).HasColumnType("decimal(10,2)");
        
        builder.Property(x => x.Status).HasColumnType("tinyint");

        builder.Property(x => x.CreatedBy).HasMaxLength(100);
        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasIndex(x => x.PlateNumber).IsUnique();

        builder.HasMany(x => x.ShipmentAssignments)
            .WithOne(sa => sa.Vehicle)
            .HasForeignKey(sa => sa.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
