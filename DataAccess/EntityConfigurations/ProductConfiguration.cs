using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId");
        builder.Property(p => p.Name).HasColumnName("Name");
        builder.Property(p => p.Description).HasColumnName("Description").IsRequired(false);
        builder.Property(p => p.UnitPrice).HasColumnName("UnitPrice");
        builder.Property(p => p.UnitsInStock).HasColumnName("UnitsInStock");
        builder.HasIndex(p => p.Name, "UK_Products_Name").IsUnique();
        builder.HasOne(p => p.Category);

        Product[] productSeeds =
        {
            new(1, 1, "MyLaptop", "A laptop.", new(1999.5), 5),
            new(2, 2, "MyPhone", "A mobile phone.", new(999.5), 15)
        };
        builder.HasData(productSeeds);
    }
}