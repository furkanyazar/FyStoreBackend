using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class FeaturedProductConfiguration : IEntityTypeConfiguration<FeaturedProduct>
{
    public void Configure(EntityTypeBuilder<FeaturedProduct> builder)
    {
        builder.ToTable("FeaturedProducts").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.ProductId).HasColumnName("ProductId");
        builder.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
        builder.HasIndex(p => p.ProductId, "UK_FeaturedProducts_ProductId").IsUnique();
        builder.HasOne(p => p.Product);
    }
}