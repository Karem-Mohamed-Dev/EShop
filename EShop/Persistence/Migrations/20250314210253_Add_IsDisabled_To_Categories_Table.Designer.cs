﻿// <auto-generated />
using System;
using EShop.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EShop.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250314210253_Add_IsDisabled_To_Categories_Table")]
    partial class Add_IsDisabled_To_Categories_Table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EShop.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("Id", "UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("EShop.Entities.CartProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId", "CartId")
                        .IsUnique();

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("EShop.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EShop.Entities.Favorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId", "ProductId")
                        .IsUnique();

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("EShop.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("CoverImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<double>("Price")
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(2,1)");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.Property<Guid?>("SubCategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SellerId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EShop.Entities.ProductImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("EShop.Entities.ProductReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(2,1)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId", "ProductId")
                        .IsUnique();

                    b.ToTable("ProductReview");
                });

            modelBuilder.Entity("EShop.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("RevokedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("EShop.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8"),
                            ConcurrencyStamp = "CC0B5346-F8AD-4580-8B6C-E88F70D2A493",
                            IsDefault = false,
                            IsDisabled = false,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("01957b56-0791-7fb2-846a-d59ed8104780"),
                            ConcurrencyStamp = "9ADD3A9D-00D3-42DF-83FD-E8FAA10CA3DD",
                            IsDefault = true,
                            IsDisabled = false,
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        },
                        new
                        {
                            Id = new Guid("01957b56-0791-7fb2-846a-d59f359f3426"),
                            ConcurrencyStamp = "76CE33FE-E990-4DF4-A4B0-712609EE0A62",
                            IsDefault = false,
                            IsDisabled = false,
                            Name = "Seller",
                            NormalizedName = "SELLER"
                        });
                });

            modelBuilder.Entity("EShop.Entities.SoldProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Price")
                        .HasColumnType("decimal(7,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SellerId");

                    b.HasIndex("UserId");

                    b.ToTable("SoldProducts");
                });

            modelBuilder.Entity("EShop.Entities.SubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("EShop.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("01957b40-a60a-7413-ae16-6c4727049ca9"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "283AEB14-CE9F-4AE0-88F9-4C86FCEFA221",
                            CreatedAt = new DateTime(2025, 3, 9, 23, 38, 54, 579, DateTimeKind.Local).AddTicks(1940),
                            Email = "admin@eshop.com",
                            EmailConfirmed = true,
                            IsDisabled = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ESHOP.COM",
                            NormalizedUserName = "ADMIN_NAME",
                            PasswordHash = "AQAAAAIAAYagAAAAECmR5YUNa+8lm4NNTA5ONhy0jRto2LT7XAmS+CBwFwJ4Z6F5+4erVz4AVQ0ZLuC/fg==",
                            PhoneNumberConfirmed = false,
                            ProfileImageUrl = "",
                            SecurityStamp = "96ADA591-B04C-4D37-B57B-9FCBA8262C5B",
                            TwoFactorEnabled = false,
                            UserName = "Admin_Name"
                        },
                        new
                        {
                            Id = new Guid("01957b40-a60b-780d-b328-f9bf9c4aa691"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "303BE4AC-8A47-4B2F-91F2-2BB1B459470D",
                            CreatedAt = new DateTime(2025, 3, 9, 23, 38, 54, 579, DateTimeKind.Local).AddTicks(1940),
                            Email = "client@test.com",
                            EmailConfirmed = true,
                            IsDisabled = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "CLIENT@TEST.COM",
                            NormalizedUserName = "CLIENT_NAME",
                            PasswordHash = "AQAAAAIAAYagAAAAEMie4u7ffTRAMN7ZbSrikIwbANJmNMC/1n4oBXgFcrSo32sL0xcUG75XenUMNGFCig==",
                            PhoneNumberConfirmed = false,
                            ProfileImageUrl = "",
                            SecurityStamp = "19439CAF-856D-46A7-9903-6141810F446B",
                            TwoFactorEnabled = false,
                            UserName = "Client_Name"
                        },
                        new
                        {
                            Id = new Guid("01957b40-a60b-780d-b328-f9c0cd4b0d85"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1238F62D-0C73-4298-B0B5-F85FDFE9CDBB",
                            CreatedAt = new DateTime(2025, 3, 9, 23, 38, 54, 579, DateTimeKind.Local).AddTicks(1940),
                            Email = "seller@test.com",
                            EmailConfirmed = true,
                            IsDisabled = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "SELLER@TEST.COM",
                            NormalizedUserName = "SELLER_NAME",
                            PasswordHash = "AQAAAAIAAYagAAAAEEgeAgFomAVkZC8mbMWMscDo/z55UzNa4DfNUGSOlMThA2y5+JxkICCpDvnPH1Tp0A==",
                            PhoneNumberConfirmed = false,
                            ProfileImageUrl = "",
                            SecurityStamp = "B99E64F4-E3AC-449E-843D-5CC67A1FCAFF",
                            TwoFactorEnabled = false,
                            UserName = "Seller_Name"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "Permissions",
                            ClaimValue = "product:add",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "Permissions",
                            ClaimValue = "product:update",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "Permissions",
                            ClaimValue = "product:delete",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "Permissions",
                            ClaimValue = "review:add",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "Permissions",
                            ClaimValue = "review:update",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "Permissions",
                            ClaimValue = "review:delete",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "Permissions",
                            ClaimValue = "users:read",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "Permissions",
                            ClaimValue = "users:add",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            Id = 9,
                            ClaimType = "Permissions",
                            ClaimValue = "users:update",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            Id = 10,
                            ClaimType = "Permissions",
                            ClaimValue = "roles:read",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "Permissions",
                            ClaimValue = "roles:add",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "Permissions",
                            ClaimValue = "roles:update",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "Permissions",
                            ClaimValue = "roles:togglestatus",
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("01957b40-a60a-7413-ae16-6c4727049ca9"),
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59db7d302f8")
                        },
                        new
                        {
                            UserId = new Guid("01957b40-a60b-780d-b328-f9bf9c4aa691"),
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59ed8104780")
                        },
                        new
                        {
                            UserId = new Guid("01957b40-a60b-780d-b328-f9c0cd4b0d85"),
                            RoleId = new Guid("01957b56-0791-7fb2-846a-d59f359f3426")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EShop.Entities.Cart", b =>
                {
                    b.HasOne("EShop.Entities.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("EShop.Entities.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EShop.Entities.CartProduct", b =>
                {
                    b.HasOne("EShop.Entities.Cart", "Cart")
                        .WithMany("CartProducts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EShop.Entities.Favorite", b =>
                {
                    b.HasOne("EShop.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Entities.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EShop.Entities.Product", b =>
                {
                    b.HasOne("EShop.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("EShop.Entities.User", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Entities.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");

                    b.Navigation("Seller");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("EShop.Entities.ProductImage", b =>
                {
                    b.HasOne("EShop.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EShop.Entities.ProductReview", b =>
                {
                    b.HasOne("EShop.Entities.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Entities.User", "User")
                        .WithMany("ProductReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EShop.Entities.RefreshToken", b =>
                {
                    b.HasOne("EShop.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EShop.Entities.SoldProduct", b =>
                {
                    b.HasOne("EShop.Entities.Product", "Product")
                        .WithMany("Solds")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("EShop.Entities.User", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("EShop.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Seller");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EShop.Entities.SubCategory", b =>
                {
                    b.HasOne("EShop.Entities.Category", "Category")
                        .WithMany("SubCategorys")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("EShop.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("EShop.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("EShop.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("EShop.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("EShop.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EShop.Entities.Cart", b =>
                {
                    b.Navigation("CartProducts");
                });

            modelBuilder.Entity("EShop.Entities.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategorys");
                });

            modelBuilder.Entity("EShop.Entities.Product", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Reviews");

                    b.Navigation("Solds");
                });

            modelBuilder.Entity("EShop.Entities.SubCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EShop.Entities.User", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("Favorites");

                    b.Navigation("ProductReviews");

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
