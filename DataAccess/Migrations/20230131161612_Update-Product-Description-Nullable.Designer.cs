﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(FyStoreDbContext))]
    [Migration("20230131161612_Update-Product-Description-Nullable")]
    partial class UpdateProductDescriptionNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfLastUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UK_Users_Name")
                        .IsUnique();

                    b.HasIndex(new[] { "Value" }, "UK_Users_Value")
                        .IsUnique();

                    b.ToTable("OperationClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            Value = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User",
                            Value = "user"
                        });
                });

            modelBuilder.Entity("Core.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfLastUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("PasswordSalt");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "UK_Users_Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfLastUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("integer")
                        .HasColumnName("OperationClaimId");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex(new[] { "UserId", "OperationClaimId" }, "UK_UserOperationClaims_UserId_OperationClaimId")
                        .IsUnique();

                    b.ToTable("UserOperationClaims", (string)null);
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfLastUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UK_Categories_Name")
                        .IsUnique();

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Computer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Phone"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.FeaturedProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfLastUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ImageUrl");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("ProductId");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProductId" }, "UK_FeaturedProducts_ProductId")
                        .IsUnique();

                    b.ToTable("FeaturedProducts", (string)null);
                });

            modelBuilder.Entity("Entities.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("CategoryId");

                    b.Property<DateTime?>("DateOfCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfLastUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("UnitPrice");

                    b.Property<short>("UnitsInStock")
                        .HasColumnType("smallint")
                        .HasColumnName("UnitsInStock");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex(new[] { "Name" }, "UK_Products_Name")
                        .IsUnique();

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "A laptop.",
                            Name = "MyLaptop",
                            UnitPrice = 1999.5m,
                            UnitsInStock = (short)5
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "A mobile phone.",
                            Name = "MyPhone",
                            UnitPrice = 999.5m,
                            UnitsInStock = (short)15
                        });
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.HasOne("Core.Entities.Concrete.OperationClaim", "OperationClaim")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Concrete.User", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concrete.FeaturedProduct", b =>
                {
                    b.HasOne("Entities.Concrete.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Concrete.Product", b =>
                {
                    b.HasOne("Entities.Concrete.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("Core.Entities.Concrete.User", b =>
                {
                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
