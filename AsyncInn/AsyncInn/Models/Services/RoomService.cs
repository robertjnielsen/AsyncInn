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
        public async Task<List<RoomDTO>> GetAllRooms()
        {
            // Retrieve all Room objects from the DB.
            var result = await _context.Rooms.ToListAsync();

            // Create a new list to hold the converted RoomDTO objects.
            List<RoomDTO> rooms = new List<RoomDTO>();

            // Enumarate through result and convert each Room object to a RoomDTO object, and add to the new list.
            foreach (var room in result)
            {
                RoomDTO roomDTO = ConvertRoomToRoomDTO(room);
                rooms.Add(roomDTO);
            }

            return rooms;
        }

        /// <summary>
        /// Retrieves a single Room object from the DB.
        /// </summary>
        /// <param name="roomID">The ID of the Room object to retrieve.</param>
        /// <returns>A single Room object.</returns>
        public async Task<RoomDTO> GetRoomByID(int roomID)
        {
            // Finds the Room object in the DB with a matching ID.
            Room result = await _context.Rooms.FindAsync(roomID);

            // Retrieve all Amenities associated with the Room object.
            var roomAmenities = await GetAmenitiesByRoomID(roomID);

            // Convert the Room object to a RoomDTO object.
            RoomDTO roomDTO = ConvertRoomToRoomDTO(result);

            // Assign the roomAmenities to the RoomDTO.
            roomDTO.Amenities = roomAmenities;

            return roomDTO;
        }

        /// <summary>
        /// Update an existing Room object in the DB.
        /// </summary>
        /// <param name="room">The updated data for the Room object.</param>
        /// <returns>Nothing.</returns>
        public async Task UpdateRoom(Room room)
        {
            // Modify the data in the existing Room object in the DB.
            _context.Update(room);

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a Room object from the DB.
        /// </summary>
        /// <param name="roomID">The ID of the Room object to delete.</param>
        /// <returns>Nothing.</returns>
        public async Task RemoveRoom(int roomID)
        {
            // Find the Room with the matching ID.
            var room = _context.Rooms.FindAsync(roomID);

            // Delete the Hotel from the DB.
            _context.Remove(room);

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all Amenities objects associated to a Room object.
        /// </summary>
        /// <param name="roomID">The ID of the given Room object.</param>
        /// <returns>A list of Amenities.</returns>
        public async Task<List<AmenityDTO>> GetAmenitiesByRoomID(int roomID)
        {
            // Retrieve all RoomAmenities associated with the given Room object.
            var result = await _context.RoomAmenities.Where(x => x.RoomID == roomID).ToListAsync();

            // Create a new List to hold the Amenities.
            List<AmenityDTO> amenities = new List<AmenityDTO>();

            // Enumerate through the result and add the Amenities to the AmeinityDTO list.
            foreach (var amenity in result)
            {
                AmenityDTO amenityDTO = await _amenities.GetAmenitiesByID(amenity.AmenitiesID);
                amenities.Add(amenityDTO);
            }

            return amenities;
        }

        /// <summary>
        /// Converts a Room object to a RoomDTO object.
        /// </summary>
        /// <param name="room">The Room object to be converted.</param>
        /// <returns>The newly converted RoomDTO object.</returns>
        public RoomDTO ConvertRoomToRoomDTO(Room room)
        {
            RoomDTO result = new RoomDTO()
            {
                ID = room.ID,
                Name = room.Name,
                Layout = room.Layout.ToString()
            };

            return result;
        }
    }
}
