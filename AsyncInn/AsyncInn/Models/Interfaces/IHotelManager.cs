using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        /// <summary>
        /// Creates a new Hotel object and stores it in the DB.
        /// </summary>
        /// <param name="hotel">The data for the new Hotel object to be stored.</param>
        /// <returns>The newly created Hotel object.</returns>
        Task<Hotel> CreateHotel(Hotel hotel);

        /// <summary>
        /// Get all Hotel objects in the DB.
        /// </summary>
        /// <returns>A list of all Hotel objects in the DB.</returns>
        Task<List<HotelDTO>> GetAllHotels();

        /// <summary>
        /// Get a single Hotel object from the DB.
        /// </summary>
        /// <param name="hotelID">The ID of the Hotel object to retrieve.</param>
        /// <returns>A single Hotel object from the DB.</returns>
        Task<HotelDTO> GetHotelByID(int hotelID);

        /// <summary>
        /// Updates the data in an existing Hotel object in the DB.
        /// </summary>
        /// <param name="hotel">The data for the Hotel object to update.</param>
        /// <returns>Nothing.</returns>
        Task UpdateHotel(Hotel hotel);

        /// <summary>
        /// Deletes a Hotel object from the DB.
        /// </summary>
        /// <param name="hotelID">The ID of the Hotel object to delete.</param>
        /// <returns>Nothing.</returns>
        Task RemoveHotel(int hotelID);

        /// <summary>
        /// Gets all HotelRoom objects for a given Hotel object.
        /// </summary>
        /// <param name="id">The ID of the Hotel object.</param>
        /// <returns>A list of HotelRoom objects.</returns>
        Task<List<HotelRoomDTO>> GetHotelRoomsByHotelID(int id);
    }

}
