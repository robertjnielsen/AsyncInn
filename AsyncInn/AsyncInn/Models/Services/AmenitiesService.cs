using AsyncInn.Data;
using AsyncInn.Models.DTO;
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
            // Add the Amenities object to the DB.
            _context.Amenities.Add(amenities);
            
            // Save the state of the DB.
            await _context.SaveChangesAsync();

            return amenities;
        }

        /// <summary>
        /// Retrieves all Amenities objects from the DB.
        /// </summary>
        /// <returns>A list of all Amenities objects.</returns>
        public async Task<List<AmenityDTO>> GetAllAmenities()
        {
            // Grab all Amenities objects from the DB.
            var result = await _context.Amenities.ToListAsync();

            List<AmenityDTO> amenities = new List<AmenityDTO>();

            // Enumarate through the items in result and convert them to AmenityDTO objects, then add them to the list.
            foreach (var amenity in result)
            {
                AmenityDTO amenityDTO = ConvertAmenitiesObjectToAmenityDTO(amenity);
                amenities.Add(amenityDTO);
            }

            return amenities;
        }

        /// <summary>
        /// Retrieves a single Amenities object from the DB.
        /// </summary>
        /// <param name="amenitiesID">The ID of the Amenities object to retrieve.</param>
        /// <returns>A single Amenities object.</returns>
        public async Task<AmenityDTO> GetAmenitiesByID(int amenitiesID)
        {
            // Finds the Amenities object in the DB with a matching ID.
            Amenities result = await _context.Amenities.FindAsync(amenitiesID);

            // Convert the Amenities object to an AmenityDTO object.
            AmenityDTO amenity = ConvertAmenitiesObjectToAmenityDTO(result);

            return amenity;
        }

        /// <summary>
        /// Update an existing Amenities object in the DB.
        /// </summary>
        /// <param name="amenities">The updated data for the Amenities object.</param>
        /// <returns>Nothing.</returns>
        public async Task UpdateAmenities(Amenities amenities)
        {
            // Modify the data in the existing Room object in the DB.
            _context.Update(amenities);

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an Amenities object from the DB.
        /// </summary>
        /// <param name="amenitiesID">The ID of the Amenities object to delete.</param>
        /// <returns>Nothing.</returns>
        public async Task RemoveAmenities(int amenitiesID)
        {
            // Find the Room with the matching ID.
            Amenities amenities = await _context.Amenities.FindAsync(amenitiesID);

            // Delete the Hotel from the DB.
            _context.Amenities.Remove(amenities);

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Converts an Amenities object to an AmenityDTO object.
        /// </summary>
        /// <param name="amenity">The Amenities object to convert.</param>
        /// <returns>An AmenityDTO object.</returns>
        public AmenityDTO ConvertAmenitiesObjectToAmenityDTO(Amenities amenity)
        {
            AmenityDTO result = new AmenityDTO()
            {
                ID = amenity.ID,
                Name = amenity.Name
            };

            return result;
        }
    }
}
