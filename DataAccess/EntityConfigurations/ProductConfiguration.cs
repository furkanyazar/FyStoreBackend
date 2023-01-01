﻿using Entities.Concrete;
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
        builder.HasIndex(p => p.Name, "UK_CProducts_Name").IsUnique();
        builder.Property(p => p.UnitPrice).HasColumnName("UnitPrice");
        builder.Property(p => p.UnitsInStock).HasColumnName("UnitsInStock");
        builder.HasOne(p => p.Category);
    }
}