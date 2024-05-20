﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaHutApp.Contexts;

#nullable disable

namespace PizzaHutApp.Migrations
{
    [DbContext(typeof(PizzaHutContext))]
    partial class PizzaHutContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PizzaHutApp.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Address = "Tamilnadu",
                            DateOfBirth = new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ramu@gmail,com",
                            Name = "Ramu",
                            Phone = "9876543321",
                            Role = "User"
                        },
                        new
                        {
                            Id = 102,
                            Address = "Tamilnadu",
                            DateOfBirth = new DateTime(2002, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "somu@gmail.com",
                            Name = "Somu",
                            Phone = "9988776655",
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("PizzaHutApp.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PizzaId"), 1L, 1);

                    b.Property<int>("DiameterInches")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVeg")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            PizzaId = 110,
                            DiameterInches = 5,
                            IsAvailable = true,
                            IsVeg = false,
                            Name = "Pizza1",
                            Price = 300
                        },
                        new
                        {
                            PizzaId = 120,
                            DiameterInches = 5,
                            IsAvailable = true,
                            IsVeg = false,
                            Name = "Pizza2",
                            Price = 400
                        });
                });

            modelBuilder.Entity("PizzaHutApp.Models.User", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordHashKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PizzaHutApp.Models.User", b =>
                {
                    b.HasOne("PizzaHutApp.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
