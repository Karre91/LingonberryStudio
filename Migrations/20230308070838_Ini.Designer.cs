﻿// <auto-generated />
using System;
using LingonberryStudio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LingonberryStudio.Migrations
{
    [DbContext(typeof(LingonberryDbContext))]
    [Migration("20230308070838_Ini")]
    partial class Ini
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LingonberryStudio.Data.Entities.Advert", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Artist")
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

                    b.Property<bool>("Offering")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialMedia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudioType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkPlaceID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("WorkPlaceID");

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

                    b.Property<bool>("AirCondition")
                        .HasColumnType("bit");

                    b.Property<bool>("CeramicOven")
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

                    b.Property<bool>("Shower")
                        .HasColumnType("bit");

                    b.Property<bool>("Storage")
                        .HasColumnType("bit");

                    b.Property<bool>("Toilet")
                        .HasColumnType("bit");

                    b.HasKey("AmenityID");

                    b.ToTable("AmenityTypes");
                });

            modelBuilder.Entity("LingonberryStudio.Data.Entities.TimeFrame", b =>
                {
                    b.Property<int>("DatesAndTimeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DatesAndTimeID"));

                    b.Property<DateTime?>("ClosingTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Friday")
                        .HasColumnType("bit");

                    b.Property<bool>("Monday")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("OpeningTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Saturday")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Sunday")
                        .HasColumnType("bit");

                    b.Property<bool>("Thursday")
                        .HasColumnType("bit");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("bit");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("bit");

                    b.HasKey("DatesAndTimeID");

                    b.ToTable("TimeFrames");
                });

            modelBuilder.Entity("LingonberryStudio.Data.Entities.WorkPlace", b =>
                {
                    b.Property<int>("WorkPlaceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkPlaceID"));

                    b.Property<int>("AmenityID")
                        .HasColumnType("int");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MeasurementNumber")
                        .HasColumnType("int");

                    b.Property<string>("MeasurementType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Pounds")
                        .HasColumnType("int");

                    b.Property<int>("TimeFrameID")
                        .HasColumnType("int");

                    b.HasKey("WorkPlaceID");

                    b.HasIndex("AmenityID");

                    b.HasIndex("TimeFrameID");

                    b.ToTable("WorkPlace");
                });

            modelBuilder.Entity("LingonberryStudio.Data.Entities.Advert", b =>
                {
                    b.HasOne("LingonberryStudio.Data.Entities.WorkPlace", "WorkPlace")
                        .WithMany()
                        .HasForeignKey("WorkPlaceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkPlace");
                });

            modelBuilder.Entity("LingonberryStudio.Data.Entities.WorkPlace", b =>
                {
                    b.HasOne("LingonberryStudio.Data.Entities.Amenity", "AmenityTypes")
                        .WithMany()
                        .HasForeignKey("AmenityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LingonberryStudio.Data.Entities.TimeFrame", "TimeFrames")
                        .WithMany()
                        .HasForeignKey("TimeFrameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AmenityTypes");

                    b.Navigation("TimeFrames");
                });
#pragma warning restore 612, 618
        }
    }
}
