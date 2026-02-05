using AssetTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetTracker.Infrastructure.Data.Configurations
{
    public class AssetsConfigurations : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {

            builder.ToTable("Assets");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.AssetName)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(a => a.SerialNumber)
                .IsRequired()
                .HasMaxLength(20);
            
            builder.Property(a => a.AssetType)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(a => a.PurchaseDate)
                .IsRequired();

            builder.HasIndex(a => a.SerialNumber)
                .IsUnique();

            builder.HasOne(a => a.Employee)
                .WithMany(e => e.Assets)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
                



        }
    }
}
