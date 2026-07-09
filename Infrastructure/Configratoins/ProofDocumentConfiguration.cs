using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticSystem.Infrastructure.Data.Configurations;

public class ProofDocumentConfiguration : IEntityTypeConfiguration<ProofDocument>
{
    public void Configure(EntityTypeBuilder<ProofDocument> builder)
    {
        builder.HasKey(x => x.ProofDocumentId);
        
        builder.Property(x => x.Photo).IsRequired().HasMaxLength(500);
        builder.Property(x => x.UploadedBy).IsRequired().HasMaxLength(100);
        
        builder.Property(x => x.Type).HasColumnType("tinyint");

        builder.Property(x => x.CreatedBy).HasMaxLength(100);
        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasIndex(x => x.ShipmentId);
    }
}
