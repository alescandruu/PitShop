﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PitShop.Data;

#nullable disable

namespace PitShop.Migrations
{
    [DbContext(typeof(PitShopContext))]
    [Migration("20230114194849_ReviewStructuralUpdates")]
    partial class ReviewStructuralUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PitShop.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MechanicId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("MechanicId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("PitShop.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EngineCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("PitShop.Models.Mechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Secondname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mechanic");
                });

            modelBuilder.Entity("PitShop.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MechanicId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("MechanicId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("PitShop.Models.Booking", b =>
                {
                    b.HasOne("PitShop.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("PitShop.Models.Mechanic", "Mechanic")
                        .WithMany()
                        .HasForeignKey("MechanicId");

                    b.Navigation("Car");

                    b.Navigation("Mechanic");
                });

            modelBuilder.Entity("PitShop.Models.Review", b =>
                {
                    b.HasOne("PitShop.Models.Booking", "Booking")
                        .WithMany()
                        .HasForeignKey("BookingId");

                    b.HasOne("PitShop.Models.Mechanic", "Mechanic")
                        .WithMany()
                        .HasForeignKey("MechanicId");

                    b.Navigation("Booking");

                    b.Navigation("Mechanic");
                });
#pragma warning restore 612, 618
        }
    }
}
