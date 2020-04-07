using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// 
/// </summary>
namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        /// <summary>
        /// DBContext constructor method.
        /// </summary>
        /// <param name="options">Options passed to the constructor.</param>
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {
            
        }
        /// <summary>
        /// creates composite keys for join tables
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(e => new { e.HotelID, e.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(e => new { e.RoomID, e.AmenitiesID });

            // Seed data.
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "The Wyatt",
                    StreetAddress = "123 Fake Street",
                    City = "Alabama",
                    State = "Alabama",
                    Phone = "(555) 867-5309"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Murder House",
                    StreetAddress = "Cutthroat Lane",
                    City = "Los Angeles",
                    State = "Alabama",
                    Phone = "(666) 666-6660"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Bunny Ranch",
                    StreetAddress = "69 Moonlight Road",
                    City = "Carson",
                    State = "Nevada",
                    Phone = "(069) 069-6969"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Dolphin Hotel",
                    StreetAddress = "666 Devils Court",
                    City = "New York City",
                    State = "New York",
                    Phone = "(666) 666-1408"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Hotel California",
                    StreetAddress = "420 Neverending Avenue",
                    City = "Black Hole",
                    State = "California",
                    Phone = "(000) 000-0000"
                });

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Frabjous Day",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 2,
                    Name = "Horunvendush Day",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 3,
                    Name = "Toomalie Day",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 4,
                    Name = "Griblig Day",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 5,
                    Name = "Kebek Day",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 6,
                    Name = "Faldifal Day",
                    Layout = Layout.OneBedroom
                }
                );

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Looking Glass"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Painted Rose"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Mushroom"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Tea Party"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Unbirthday"
                }
                );
        }
        /// <summary>
        /// Creates at table for each model
        /// </summary>
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }

    }
}
