using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticSystem.Infrastructure.Data.Configurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(x => x.DriverId);
        
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.NationalId).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LicenseId).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LicenseNumber).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Rate).HasColumnType("decimal(18,2)");
        
        builder.Property(x => x.Status).HasColumnType("tinyint");

        builder.Property(x => x.CreatedBy).HasMaxLength(100);
        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasIndex(x => x.UserId).IsUnique();
        builder.HasIndex(x => x.NationalId).IsUnique();

        builder.HasMany(x => x.ShipmentAssignments)
            .WithOne(sa => sa.Driver)
            .HasForeignKey(sa => sa.DriverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
