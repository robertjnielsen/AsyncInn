using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        /// <summary>
        /// Creates a new Amenities object and inserts it into the DB.
        /// </summary>
        /// <param name="amenities">The data for the new Amenities object.</param>
        /// <returns>The newly created Amenities object.</returns>
        Task<Amenities> CreateAmenities(Amenities amenities);

        /// <summary>
        /// Retrieves all Amenities objects from the DB.
        /// </summary>
        /// <returns>A list of all Amenities objects.</returns>
        Task<List<AmenityDTO>> GetAllAmenities();

        /// <summary>
        /// Retrieves a single Amenities object from the DB.
        /// </summary>
        /// <param name="amenitiesID">The ID of the Amenities object to retrieve.</param>
        /// <returns>The Amenities object requested.</returns>
        Task<AmenityDTO> GetAmenitiesByID(int amenitiesID);

        /// <summary>
        /// Updates an existing Amenities object in the DB.
        /// </summary>
        /// <param name="amenities">The updated data for the Amenities object.</param>
        /// <returns>Nothing.</returns>
        Task UpdateAmenities(Amenities amenities);

        /// <summary>
        /// Removes an Amenities object from the DB.
        /// </summary>
        /// <param name="amenitiesID">The ID of the Amenities object to delete.</param>
        /// <returns>Nothing.</returns>
        Task RemoveAmenities(int amenitiesID);
    }
}
