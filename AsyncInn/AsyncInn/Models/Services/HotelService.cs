using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelService : IHotelManager
    {
        /// <summary>
        /// The DBContext for the AsyncInn DB.
        /// </summary>
        private AsyncInnDbContext _context;

        /// <summary>
        /// Constructor method for the service.
        /// </summary>
        /// <param name="context">The DBContext for the AsyncInn DB.</param>
        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insert a new Hotel object into the Hotels table.
        /// </summary>
        /// <param name="hotel">The data for the new Hotel object.</param>
        /// <returns>The newly created Hotel object.</returns>
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            // Adds the new Hotel to the DB.
            _context.Hotels.Add(hotel);

            // Saves the new Hotel in the DB.
            await _context.SaveChangesAsync();

            return hotel;
        }

        /// <summary>
        /// Retrieves all Hotel objects from the DB.
        /// </summary>
        /// <returns>A list of all Hotel objects.</returns>
        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        /// <summary>
        /// Retrieves a single Hotel object from the DB.
        /// </summary>
        /// <param name="HotelID">The ID of the Hotel object to retrieve.</param>
        /// <returns>A single Hotel object.</returns>
        public async Task<Hotel> GetHotelByID(int HotelID)
        {
            // Finds the Hotel object in the DB with a matching ID.
            Hotel hotel = await _context.Hotels.FindAsync(HotelID);
            hotel.HotelRooms = await GetHotelRooms(HotelID);

            return hotel;
        }

        /// <summary>
        /// Deletes a Hotel object from the DB.
        /// </summary>
        /// <param name="HotelID">The ID of the Hotel object to delete.</param>
        /// <returns>Nothing.</returns>
        public async Task RemoveHotel(int HotelID)
        {
            // Find the Hotel with the matching ID.
            Hotel hotel = await GetHotelByID(HotelID);

            // Delete the Hotel from the DB.
            _context.Hotels.Remove(hotel);

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update an existing Hotel object in the DB.
        /// </summary>
        /// <param name="HotelID">The ID of the Hotel object to update.</param>
        /// <param name="hotel">The updated data for the Hotel object.</param>
        /// <returns>Nothing.</returns>
        public async Task UpdateHotel(int HotelID, Hotel hotel)
        {
            // Modify the data in the existing Hotel object in the DB.
            _context.Entry(hotel).State = EntityState.Modified;

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }
        public async Task<List<HotelRoom>> GetHotelRooms(int HotelID)
        {
            var Result = await _context.HotelRooms.Where(x => x.HotelID == HotelID)
                                                  .Include(x => x.Room)
                                                  .ThenInclude(x => x.RoomAmenities)
                                                  .ThenInclude(x => x.Amenities)
                                                  .ToListAsync();
            return Result;
                
        }
    }
}
