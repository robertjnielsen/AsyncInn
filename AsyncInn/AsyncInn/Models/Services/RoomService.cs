using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomService : IRoomManager
    {
        /// <summary>
        /// The DBContext for the AsyncInn DB.
        /// </summary>
        private AsyncInnDbContext _context;

        /// <summary>
        /// Implements access to IAmenitiesManager interface within the RoomService service.
        /// </summary>
        private IAmenitiesManager _amenities;

        /// <summary>
        /// Constructor method for the service.
        /// </summary>
        /// <param name="context">The DBContext for the AsyncInn DB.</param>
        /// <param name="amenities">The IAmenitiesManager interface to access Room Amenities.</param>
        public RoomService(AsyncInnDbContext context, IAmenitiesManager amenities)
        {
            _context = context;
            _amenities = amenities;
        }

        /// <summary>
        /// Insert a new Room object into the Rooms table.
        /// </summary>
        /// <param name="room">The data for the new Room object.</param>
        /// <returns>The newly created Room object.</returns>
        public async Task<Room> CreateRoom(Room room)
        {
            // Adds the new Room to the DB.
            _context.Rooms.Add(room);

            // Saves the new Room in the DB.
            await _context.SaveChangesAsync();

            return room;
        }

        /// <summary>
        /// Retrieves all Room objects from the DB.
        /// </summary>
        /// <returns>A list of all Room objects.</returns>
        public async Task<List<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        /// <summary>
        /// Retrieves a single Room object from the DB.
        /// </summary>
        /// <param name="roomID">The ID of the Room object to retrieve.</param>
        /// <returns>A single Room object.</returns>
        public async Task<Room> GetRoomByID(int roomID)
        {
            // Finds the Room object in the DB with a matching ID.
            Room room = await _context.Rooms.FindAsync(roomID);
            room.RoomAmenities = await GetRoomAmenities(roomID);

            return room;
        }

        /// <summary>
        /// Deletes a Room object from the DB.
        /// </summary>
        /// <param name="roomID">The ID of the Room object to delete.</param>
        /// <returns>Nothing.</returns>
        public async Task RemoveRoom(int roomID)
        {
            // Find the Room with the matching ID.
            Room room = await GetRoomByID(roomID);

            // Delete the Hotel from the DB.
            _context.Rooms.Remove(room);

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update an existing Room object in the DB.
        /// </summary>
        /// <param name="roomID">The ID of the Room object to update.</param>
        /// <param name="room">The updated data for the Room object.</param>
        /// <returns>Nothing.</returns>
        public async Task UpdateRoom(int roomID, Room room)
        {
            // Modify the data in the existing Room object in the DB.
            _context.Entry(room).State = EntityState.Modified;

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }

        public async Task<List<RoomAmenities>> GetRoomAmenities(int id)
        {
            var result = await _context.RoomAmenities.Where(x => x.RoomID == id)
                                        .Include(x => x.Amenities)
                                        .ToListAsync();

            return result;
        }
    }
}
