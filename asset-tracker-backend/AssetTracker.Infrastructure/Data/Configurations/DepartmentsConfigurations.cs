using AssetTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetTracker.Infrastructure.Data.Configurations
{
    public class DepartmentsConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.DeptName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(d => d.DeptName)
                .IsUnique();


        }
    }
}
