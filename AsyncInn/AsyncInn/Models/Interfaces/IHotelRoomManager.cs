using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoomManager
    {
        /// <summary>
        /// Creates a new HotelRoom object and inserts it into the DB.
        /// </summary>
        /// <param name="hotelRoom">The HotelRoom object to insert into the DB.</param>
        /// <returns>The newly inserted HotelRoom object.</returns>
        Task<HotelRoomDTO> CreateHotelRoom(HotelRoom hotelRoom);

        /// <summary>
        /// Retrieve all HotelRoom objects.
        /// </summary>
        /// <returns>A list of all HotelRoom objects.</returns>
        Task<List<HotelRoomDTO>> GetAllHotelRooms();

        /// <summary>
        /// Retrieves a single HotelRoom object.
        /// </summary>
        /// <param name="roomNumber">The RoomNumber of the HotelRoom object.</param>
        /// <param name="hotelId">The HotelID of the HotelRoom object.</param>
        /// <returns>A single HotelRoomDTO object.</returns>
        Task<HotelRoomDTO> GetHotelRoomByRoomNumber(int roomNumber, int hotelId);

        /// <summary>
        /// Updates an existing HotelRoom object in the DB.
        /// </summary>
        /// <param name="hotelRoom">The updated HotelRoom data.</param>
        /// <returns>Nothing.</returns>
        Task UpdateHotelRoom(HotelRoom hotelRoom);

        /// <summary>
        /// Removes a HotelRoom object from the DB.
        /// </summary>
        /// <param name="roomNumber">The RoomNumber of the HotelRoom to delete.</param>
        /// <returns>Nothing.</returns>
        Task RemoveHotelRoom(int roomNumber);
    }
    

}
