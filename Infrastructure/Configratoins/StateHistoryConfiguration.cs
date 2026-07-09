using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticSystem.Infrastructure.Data.Configurations;

public class StateHistoryConfiguration : IEntityTypeConfiguration<StateHistory>
{
    public void Configure(EntityTypeBuilder<StateHistory> builder)
    {
        builder.HasKey(x => x.StateHistoryId);
        
        builder.Property(x => x.State).HasColumnType("tinyint");

        builder.Property(x => x.CreatedBy).HasMaxLength(100);
        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasIndex(x => x.ShipmentId);
    }
}
