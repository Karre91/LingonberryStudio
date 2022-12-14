﻿// <auto-generated />
using System;
using LingonberryStudio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LingonberryStudio.Migrations
{
    [DbContext(typeof(LingonberryDbContext))]
    partial class LingonberryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LingonberryStudio.Data.Entities.Advert", b =>
                {
                    b.Property<int>("AdvertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdvertId"));

                    b.Property<int>("AmenityID")
                        .HasColumnType("int");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<int>("DatesAndTimeID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeasurementID")
                        .HasColumnType("int");

                    b.Property<string>("OfferingLooking")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkspaceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdvertId");

                    b.HasIndex("AmenityID");

                    b.HasIndex("DatesAndTimeID");

                    b.HasIndex("MeasurementID");

                    b.ToTable("Adverts");
                });

            modelBuilder.Entity("LingonberryStudio.Data.Entities.Amenity", b =>
                {
                    b.Property<int>("AmenityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AmenityID"));

                    b.Property<bool>("AcousticTreatment")
                        .HasColumnType("bit");

                    b.Property<bool>("AirCon")
                        .HasColumnType("bit");

                    b.Property<bool>("Kitchen")
                        .HasColumnType("bit");

                    b.Property<bool>("NaturalLight")
                        .HasColumnType("bit");

                    b.Property<string>("Other")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Parking")
                        .HasColumnType("bit");

                    b.Property<bool>("RunningWater")
                        .HasColumnType("bit");

                    b.Property<bool>("Storage")
                        .HasColumnType("bit");

                    b.HasKey("AmenityID");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("LingonberryStudio.Data.Entities.DatesAndTime", b =>
                {
                    b.Property<int>("DatesAndTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DatesAndTimeId"));

                    b.Property<DateTime>("ClosingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OpeningTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DatesAndTimeId");

                    b.HasIndex("DayID");

                    b.ToTable("DatesAndTimes");
                });

            modelBuilder.Entity("LingonberryStudio.Data.Entities.Day", b =>
                {
                    b.Property<int>("DayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DayId"));

                    b.Property<bool>("Friday")
                        .HasColumnType("bit");

                    b.Property<bool>("Monday")
                        .HasColumnType("bit");

                    b.Property<bool>("Saturday")
                        .HasColumnType("bit");

                    b.Property<bool>("Sunday")
                        .HasColumnType("bit");

                    b.Property<bool>("Thursday")
                        .HasColumnType("bit");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("bit");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("bit");

                    b.HasKey("DayId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("LingonberryStudio.Data.Entities.Measurement", b =>
                {
                    b.Property<int>("MeasurementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeasurementId"));

                    b.Property<string>("FeetOrMeters")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("MeasurementId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("LingonberryStudio.Data.Entities.Advert", b =>
                {
                    b.HasOne("LingonberryStudio.Data.Entities.Amenity", "Amenities")
                        .WithMany()
                        .HasForeignKey("AmenityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LingonberryStudio.Data.Entities.DatesAndTime", "DatesAndTimes")
                        .WithMany()
                        .HasForeignKey("DatesAndTimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LingonberryStudio.Data.Entities.Measurement", "Measurements")
                        .WithMany()
                        .HasForeignKey("MeasurementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenities");

                    b.Navigation("DatesAndTimes");

                    b.Navigation("Measurements");
                });

            modelBuilder.Entity("LingonberryStudio.Data.Entities.DatesAndTime", b =>
                {
                    b.HasOne("LingonberryStudio.Data.Entities.Day", "Days")
                        .WithMany()
                        .HasForeignKey("DayID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Days");
                });
#pragma warning restore 612, 618
        }
    }
}
