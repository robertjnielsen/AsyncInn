﻿// <auto-generated />
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20200407003931_addedNewEntities")]
    partial class addedNewEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("HotelID", "RoomNumber");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.Property<int>("AmenitiesID")
                        .HasColumnType("int");

                    b.HasKey("RoomID", "AmenitiesID");

                    b.HasIndex("AmenitiesID")
                        .IsUnique();

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInn.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("HotelRooms")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenities", "Amenities")
                        .WithOne("RoomAmenities")
                        .HasForeignKey("AsyncInn.Models.RoomAmenities", "AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
