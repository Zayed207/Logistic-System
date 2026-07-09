using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticSystem.Infrastructure.Data.Configurations;

public class ShipmentAssignmentConfiguration : IEntityTypeConfiguration<ShipmentAssignment>
{
    public void Configure(EntityTypeBuilder<ShipmentAssignment> builder)
    {
        builder.HasKey(x => x.ShipmentAssignmentId);
        
        builder.Property(x => x.Reason).HasMaxLength(255);
        
        builder.Property(x => x.Status).HasColumnType("tinyint");

        builder.Property(x => x.CreatedBy).HasMaxLength(100);
        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasIndex(x => x.ShipmentId);
        builder.HasIndex(x => x.DriverId);
        builder.HasIndex(x => x.VehicleId);
        builder.HasIndex(x => x.AssignedByUserId);

        builder.HasOne(x => x.AssignedByUser)
            .WithMany()
            .HasForeignKey(x => x.AssignedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
