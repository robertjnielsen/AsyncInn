using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        /// <summary>
        /// Create a new Room object and add it to the DB.
        /// </summary>
        /// <param name="room">The data for the new Room object.</param>
        /// <returns>The newly created Room object.</returns>
        Task<Room> CreateRoom(Room room);
        
        /// <summary>
        /// Retrieve all Room objects from the DB.
        /// </summary>
        /// <returns>A list of all Room objects.</returns>
        Task<List<RoomDTO>> GetAllRooms();

        /// <summary>
        /// Retrieve a single Room object from the DB.
        /// </summary>
        /// <param name="roomID">The ID of the Room object to retrieve.</param>
        /// <returns>The specified Room object.</returns>
        Task<RoomDTO> GetRoomByID(int roomID);

        /// <summary>
        /// Updates an existing Room object in the DB.
        /// </summary>
        /// <param name="room">The updated Room object data.</param>
        /// <returns>Nothing.</returns>
        Task UpdateRoom(Room room);

        /// <summary>
        /// Deletes a Room object from the DB.
        /// </summary>
        /// <param name="roomID">The ID of the Room object to delete.</param>
        /// <returns>Nothing.</returns>
        Task RemoveRoom(int roomID);

        /// <summary>
        /// Retrieves a list of Amenities associated with a given Room object.
        /// </summary>
        /// <param name="roomID">The ID of the Room object.</param>
        /// <returns>A list of Amenities.</returns>
        Task<List<AmenityDTO>> GetAmenitiesByRoomID(int roomID);
    }
}
