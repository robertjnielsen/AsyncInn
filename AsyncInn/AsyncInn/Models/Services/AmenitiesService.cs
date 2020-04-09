using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenitiesService : IAmenitiesManager
    {
        /// <summary>
        /// The DBContext for the AsyncInn DB.
        /// </summary>
        private AsyncInnDbContext _context;

        /// <summary>
        /// Constructor method for the service.
        /// </summary>
        /// <param name="context">The DBContext for the AsyncInn DB.</param>
        public AmenitiesService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insert a new Amenities object into the Amenities table.
        /// </summary>
        /// <param name="amenities">The data for the new Amenities object.</param>
        /// <returns>The newly created Amenities object.</returns>
        public async Task<Amenities> CreateAmenities(Amenities amenities)
        {
            // Adds the new Room to the DB.
            _context.Amenities.Add(amenities);

            // Saves the new Room in the DB.
            await _context.SaveChangesAsync();

            return amenities;
        }

        /// <summary>
        /// Retrieves all Amenities objects from the DB.
        /// </summary>
        /// <returns>A list of all Amenities objects.</returns>
        public async Task<List<Amenities>> GetAllAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        /// <summary>
        /// Retrieves a single Amenities object from the DB.
        /// </summary>
        /// <param name="AmenitiesID">The ID of the Amenities object to retrieve.</param>
        /// <returns>A single Amenities object.</returns>
        public async Task<Amenities> GetAmenitiesByID(int AmenitiesID)
        {
            // Finds the Room object in the DB with a matching ID.
            Amenities amenities = await _context.Amenities.FindAsync(AmenitiesID);

            return amenities;
        }

        /// <summary>
        /// Deletes an Amenities object from the DB.
        /// </summary>
        /// <param name="AmenitiesID">The ID of the Amenities object to delete.</param>
        /// <returns>Nothing.</returns>
        public async Task RemoveAmenities(int AmenitiesID)
        {
            // Find the Room with the matching ID.
            Amenities amenities = await GetAmenitiesByID(AmenitiesID);

            // Delete the Hotel from the DB.
            _context.Amenities.Remove(amenities);

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update an existing Amenities object in the DB.
        /// </summary>
        /// <param name="AmenitiesID">The ID of the Amenities object to update.</param>
        /// <param name="amenities">The updated data for the Amenities object.</param>
        /// <returns>Nothing.</returns>
        public async Task UpdateAmenities(int AmenitiesID, Amenities amenities)
        {
            // Modify the data in the existing Room object in the DB.
            _context.Entry(amenities).State = EntityState.Modified;

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }
    }
}
