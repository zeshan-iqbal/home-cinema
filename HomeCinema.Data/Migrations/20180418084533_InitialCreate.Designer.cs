﻿// <auto-generated />
using HomeCinema.Core.Domain;
using HomeCinema.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HomeCinema.Data.Migrations
{
    [DbContext(typeof(HomeCinemaContext))]
    [Migration("20180418084533_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeCinema.Core.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 4, 18, 8, 45, 33, 795, DateTimeKind.Utc));

                    b.Property<DateTime?>("DateOfBirth")
                        .IsRequired();

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Mobile")
                        .HasMaxLength(10);

                    b.Property<string>("RegistrationDate");

                    b.Property<Guid>("UniqueKey");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("HomeCinema.Core.Domain.Error", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 4, 18, 8, 45, 33, 802, DateTimeKind.Utc));

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedDate");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.ToTable("Error");
                });

            modelBuilder.Entity("HomeCinema.Core.Domain.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 4, 18, 8, 45, 33, 804, DateTimeKind.Utc));

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("HomeCinema.Core.Domain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 4, 18, 8, 45, 33, 811, DateTimeKind.Utc));

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("GenreId");

                    b.Property<string>("Image");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedDate");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte>("Rating");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("TrailerUrl")
                        .HasMaxLength(200);

                    b.Property<string>("Writer")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("HomeCinema.Core.Domain.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 4, 18, 8, 45, 33, 816, DateTimeKind.Utc));

                    b.Property<int>("CustomerId");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedDate");

                    b.Property<DateTime>("RentalDate");

                    b.Property<DateTime?>("ReturnedDate");

                    b.Property<int>("Status")
                        .HasMaxLength(10);

                    b.Property<int>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StockId");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("HomeCinema.Core.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 4, 18, 8, 45, 33, 818, DateTimeKind.Utc));

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("HomeCinema.Core.Domain.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 4, 18, 8, 45, 33, 822, DateTimeKind.Utc));

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedDate");

                    b.Property<int>("MovieId");

                    b.Property<Guid>("UniqueKey");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("HomeCinema.Core.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 4, 18, 8, 45, 33, 826, DateTimeKind.Utc));

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsLocked");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedDate");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HomeCinema.Core.Domain.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 4, 18, 8, 45, 33, 827, DateTimeKind.Utc));

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedDate");

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("HomeCinema.Core.Domain.Movie", b =>
                {
                    b.HasOne("HomeCinema.Core.Domain.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeCinema.Core.Domain.Rental", b =>
                {
                    b.HasOne("HomeCinema.Core.Domain.Customer")
                        .WithMany("Rentals")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeCinema.Core.Domain.Stock", "Stock")
                        .WithMany("Rentals")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeCinema.Core.Domain.Stock", b =>
                {
                    b.HasOne("HomeCinema.Core.Domain.Movie", "Movie")
                        .WithMany("Stocks")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeCinema.Core.Domain.UserRole", b =>
                {
                    b.HasOne("HomeCinema.Core.Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeCinema.Core.Domain.User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
