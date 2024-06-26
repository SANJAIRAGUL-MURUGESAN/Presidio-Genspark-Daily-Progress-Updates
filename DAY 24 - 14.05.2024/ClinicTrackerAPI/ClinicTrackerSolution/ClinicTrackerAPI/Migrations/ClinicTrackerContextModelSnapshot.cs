﻿// <auto-generated />
using System;
using ClinicTrackerAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicTrackerAPI.Migrations
{
    [DbContext(typeof(ClinicTrackerContext))]
    partial class ClinicTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClinicTrackerAPI.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Experience")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            DateOfBirth = new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Designation = "MD",
                            Email = "ramu@gmail.com",
                            Experience = 12f,
                            Name = "Ramu",
                            Phone = "9876543321",
                            Specialization = "Heart"
                        },
                        new
                        {
                            Id = 102,
                            DateOfBirth = new DateTime(2002, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Designation = "MBBS",
                            Email = "somu@gmail.com",
                            Experience = 8f,
                            Name = "Somu",
                            Phone = "9988776655",
                            Specialization = "Sugar"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
