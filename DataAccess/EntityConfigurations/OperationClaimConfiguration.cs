using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Name).HasColumnName("Name");
        builder.Property(p => p.Value).HasColumnName("Value");
        builder.HasIndex(p => p.Name, "UK_Users_Name").IsUnique();
        builder.HasIndex(p => p.Value, "UK_Users_Value").IsUnique();
        builder.HasMany(p => p.UserOperationClaims);

        OperationClaim[] operationClaimSeeds = { new(1, "Admin", "admin"), new(2, "User", "user") };
        builder.HasData(operationClaimSeeds);
    }
}