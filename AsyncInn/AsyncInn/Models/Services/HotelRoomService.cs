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
    public class HotelRoomService : IHotelRoomManager
    {
        /// <summary>
        /// The DB context.
        /// </summary>
        private readonly AsyncInnDbContext _context;

        /// <summary>
        /// The IRoomManager interface for DI.
        /// </summary>
        private readonly IRoomManager _rooms;

        /// <summary>
        /// Constructor method to inject the DBContext and the IRoomManager interface.
        /// </summary>
        /// <param name="context">The DBContext.</param>
        /// <param name="rooms">The IRoomManager interface.</param>
        public HotelRoomService(AsyncInnDbContext context, IRoomManager rooms)
        {
            _context = context;
            _rooms = rooms;
        }

        /// <summary>
        /// Creates a new HotelRoom object and inserts it into the DB.
        /// </summary>
        /// <param name="hotelRoom">The data for the new HotelRoom object.</param>
        /// <returns>The newly inserted HotelRoom object.</returns>
        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoom hotelRoom)
        {
            // Converts the HotelRoom object to a HotelRoomDTO object.
            HotelRoomDTO hotelRoomDTO = ConvertHotelRoomToHotelRoomDTO(hotelRoom);

            // Add the new object to the DB.
            _context.Add(hotelRoomDTO);

            // Save the state of the DB.
            await _context.SaveChangesAsync();

            return hotelRoomDTO;
        }

        /// <summary>
        /// Retrieves all HotelRoom objects from the DB.
        /// </summary>
        /// <returns>A list of HotelRoomDTO objects.</returns>
        public async Task<List<HotelRoomDTO>> GetAllHotelRooms()
        {
            // Retrieve all HotelRoom objects.
            var result = await _context.HotelRooms.ToListAsync();

            List<HotelRoomDTO> hotelRooms = new List<HotelRoomDTO>();

            // Enumerate through the result and convert each HotelRoom object to a HotelRoomDTO object, then add to the new list.
            foreach (var hotelRoom in result)
            {
                HotelRoomDTO hotelRoomDTO = ConvertHotelRoomToHotelRoomDTO(hotelRoom);
                hotelRooms.Add(hotelRoomDTO);
            }

            return hotelRooms;
        }

        /// <summary>
        /// Retrieves a single HotelRoom object.
        /// </summary>
        /// <param name="roomNumber">The RoomNumber of the HotelRoom object.</param>
        /// <param name="hotelId">The HotelID of the HotelRoom object.</param>
        /// <returns>A single HotelRoomDTO object.</returns>
        public async Task<HotelRoomDTO> GetHotelRoomByRoomNumber(int roomNumber, int hotelId)
        {
            // Retrieve the HotelRoom object.
            var result = await _context.HotelRooms.Where(x => x.RoomNumber == roomNumber && x.HotelID == hotelId)
                                                  .SingleAsync();

            // Convert the result to a HotelRoomDTO object.
            HotelRoomDTO hotelRoom = ConvertHotelRoomToHotelRoomDTO(result);

            // Retrieve the Room object associated with the HotelRoom object.
            RoomDTO room = await _rooms.GetRoomByID(hotelRoom.RoomID);

            hotelRoom.Room = room;

            return hotelRoom;
        }

        /// <summary>
        /// Updates an existing HotelRoom object in the DB.
        /// </summary>
        /// <param name="hotelRoom">The updated HotelRoom data.</param>
        /// <returns>Nothing.</returns>
        public async Task UpdateHotelRoom(HotelRoom hotelRoom)
        {
            // Update the HotelRoom object in the DB.
            _context.Update(hotelRoom);

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a HotelRoom object from the DB.
        /// </summary>
        /// <param name="roomNumber">The RoomNumber of the HotelRoom object to remove.</param>
        /// <returns>Nothing.</returns>
        public async Task RemoveHotelRoom(int roomNumber)
        {
            // Find the correct HotelRoom object.
            var result = await _context.HotelRooms.Where(x => x.RoomNumber == roomNumber).SingleAsync();

            // Remove the HotelRoom from the DB.
            _context.Remove(result);

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Converts a HotelRoom object to a HotelRoomDTO object.
        /// </summary>
        /// <param name="hotelRoom">The HotelRoom object to convert.</param>
        /// <returns>The newly converted HotelRoomDTO object.</returns>
        private HotelRoomDTO ConvertHotelRoomToHotelRoomDTO(HotelRoom hotelRoom)
        {
            HotelRoomDTO result = new HotelRoomDTO()
            {
                HotelID = hotelRoom.HotelID,
                RoomNumber = hotelRoom.RoomNumber,
                RoomID = hotelRoom.RoomID,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly
            };

            return result;
        }
    }
}
