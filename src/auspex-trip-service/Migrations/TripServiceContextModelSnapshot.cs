using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace auspextripservice.Migrations
{
    [DbContext(typeof(TripServiceContext))]
    partial class TripServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Auspex.TripService.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LicensePlate");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Auspex.TripService.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Auspex.TripService.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CarId");

                    b.Property<int?>("EndLocationId");

                    b.Property<int>("EndMileage");

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("ExtraDistance");

                    b.Property<string>("Remarks");

                    b.Property<int?>("StartLocationId");

                    b.Property<int>("StartMileage");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("TripType");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("EndLocationId");

                    b.HasIndex("StartLocationId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Auspex.TripService.Models.Trip", b =>
                {
                    b.HasOne("Auspex.TripService.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("Auspex.TripService.Models.Location", "EndLocation")
                        .WithMany()
                        .HasForeignKey("EndLocationId");

                    b.HasOne("Auspex.TripService.Models.Location", "StartLocation")
                        .WithMany()
                        .HasForeignKey("StartLocationId");
                });
        }
    }
}
