﻿// <auto-generated />
using System;
using EatZ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EatZ.Infra.Data.Migrations
{
    [DbContext(typeof(EatzDbContext))]
    [Migration("20230326131048_AddStoreOffersTable")]
    partial class AddStoreOffersTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EatZ.Domain.Entities.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision")
                        .HasColumnName("LATITUDE");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision")
                        .HasColumnName("LONGITUDE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("NAME");

                    b.Property<long>("StateId")
                        .HasColumnType("bigint")
                        .HasColumnName("STATE_ID");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("CITIES", (string)null);
                });

            modelBuilder.Entity("EatZ.Domain.Entities.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("ACRONYM");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("COUNTRIES", (string)null);
                });

            modelBuilder.Entity("EatZ.Domain.Entities.State", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("ACRONYM");

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint")
                        .HasColumnName("COUNTRY_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("STATES", (string)null);
                });

            modelBuilder.Entity("EatZ.Domain.Entities.Store", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("ID");

                    b.Property<string>("AdminId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ADMIN_ID");

                    b.Property<long>("CityId")
                        .HasColumnType("bigint")
                        .HasColumnName("CITY_ID");

                    b.Property<string>("Complement")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("COMPLEMENT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CREATED_AT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("DOCUMENT_NUMBER");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision")
                        .HasColumnName("LATITUDE");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision")
                        .HasColumnName("LONGITUDE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("NAME");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("NEIGHBORHOOD");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("PHONE");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("STREET");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("integer")
                        .HasColumnName("STREET_NUMBER");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("ZIP_CODE");

                    b.HasKey("Id");

                    b.HasIndex("AdminId")
                        .IsUnique();

                    b.HasIndex("CityId");

                    b.ToTable("STORES", (string)null);
                });

            modelBuilder.Entity("EatZ.Domain.Entities.StoreImages", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("ID");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("CONTENT");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("STORE_ID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("TITLE");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("STORE_IMAGES", (string)null);
                });

            modelBuilder.Entity("EatZ.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

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

                    b.ToTable("USERS", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

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

                    b.ToTable("ROLES", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("USER_ROLES", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StoreOffers", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CREATION_DATE");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("EXPIRATION_DATE");

                    b.Property<decimal>("GrossUnitPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("GROSS_UNIT_PRICE");

                    b.Property<decimal>("NetUnitPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("NET_UNIT_PRICE");

                    b.Property<DateTime>("PickUpDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("PICK_UP_DATE");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("QUANTITY");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("STORE_ID");

                    b.Property<int>("Taste")
                        .HasColumnType("integer")
                        .HasColumnName("TASTE");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("STORE_OFFERS", (string)null);
                });

            modelBuilder.Entity("EatZ.Domain.Entities.City", b =>
                {
                    b.HasOne("EatZ.Domain.Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CITY_STATE");

                    b.Navigation("State");
                });

            modelBuilder.Entity("EatZ.Domain.Entities.State", b =>
                {
                    b.HasOne("EatZ.Domain.Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_STATE_COUNTRY");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("EatZ.Domain.Entities.Store", b =>
                {
                    b.HasOne("EatZ.Domain.Entities.User", "Admin")
                        .WithOne()
                        .HasForeignKey("EatZ.Domain.Entities.Store", "AdminId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_USERS_STORE_ID");

                    b.HasOne("EatZ.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_CITIES_STORE_ID");

                    b.Navigation("Admin");

                    b.Navigation("City");
                });

            modelBuilder.Entity("EatZ.Domain.Entities.StoreImages", b =>
                {
                    b.HasOne("EatZ.Domain.Entities.Store", "Store")
                        .WithMany("Images")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_STORE_IMAGES");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EatZ.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EatZ.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EatZ.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EatZ.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreOffers", b =>
                {
                    b.HasOne("EatZ.Domain.Entities.Store", "Store")
                        .WithMany("Offers")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_STORE_OFFERS");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("EatZ.Domain.Entities.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("EatZ.Domain.Entities.State", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("EatZ.Domain.Entities.Store", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Offers");
                });
#pragma warning restore 612, 618
        }
    }
}
