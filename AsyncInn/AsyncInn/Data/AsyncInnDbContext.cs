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
