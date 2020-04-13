using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models.DTO;

namespace AsyncInn.Models.Services
{
    public class HotelService : IHotelManager
    {
        /// <summary>
        /// The DBContext for the AsyncInn DB.
        /// </summary>
        private AsyncInnDbContext _context;

        private IHotelRoomManager _hotelRooms;

        /// <summary>
        /// Constructor method for the service.
        /// </summary>
        /// <param name="context">The DBContext for the AsyncInn DB.</param>
        public HotelService(AsyncInnDbContext context, IHotelRoomManager hotelRooms)
        {
            _context = context;
            _hotelRooms = hotelRooms;
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
        public async Task<List<HotelDTO>> GetAllHotels()
        {
            // Retrieve all Hotel objects from the DB.
            List<Hotel> hotels = await _context.Hotels.ToListAsync();

            // Create a new List to contain the converted HotelDTO objects.
            List<HotelDTO> result = new List<HotelDTO>();

            // Enumerate through the Hotel objects, convert them to HotelDTO objects, add them to the newly created HotelDTO list.
            foreach (var hotel in hotels)
            {
                HotelDTO hotelDTO = ConvertHotelToHotelDTO(hotel);
                result.Add(hotelDTO);
            }

            return result;
        }

        /// <summary>
        /// Retrieves a single Hotel object from the DB.
        /// </summary>
        /// <param name="HotelID">The ID of the Hotel object to retrieve.</param>
        /// <returns>A single Hotel object.</returns>
        public async Task<HotelDTO> GetHotelByID(int hotelID)
        {
            // Finds the Hotel object in the DB with a matching ID.
            Hotel hotel = await _context.Hotels.FindAsync(hotelID);

            // Converts the Hotel object to a HotelDTO object.
            HotelDTO hotelDTO = ConvertHotelToHotelDTO(hotel);

            // Retrieves all HotelRoom objects associated with the Hotel object.
            hotelDTO.Rooms = await GetHotelRoomsByHotelID(hotelID);

            return hotelDTO;
        }

        /// <summary>
        /// Update an existing Hotel object in the DB.
        /// </summary>
        /// <param name="hotel">The updated data for the Hotel object.</param>
        /// <returns>Nothing.</returns>
        public async Task UpdateHotel(Hotel hotel)
        {
            // Modify the data in the existing Hotel object in the DB.
            _context.Update(hotel);

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a Hotel object from the DB.
        /// </summary>
        /// <param name="hotelID">The ID of the Hotel object to delete.</param>
        /// <returns>Nothing.</returns>
        public async Task RemoveHotel(int hotelID)
        {
            // Find the Hotel with the matching ID.
            HotelDTO result = await GetHotelByID(hotelID);

            // Convert HotelDTO to Hotel for removal from DB.
            Hotel hotel = new Hotel()
            {
                ID = result.ID,
                Name = result.Name,
                StreetAddress = result.StreetAddress,
                City = result.City,
                State = result.State,
                Phone = result.Phone
            };

            // Delete the Hotel from the DB.
            _context.Hotels.Remove(hotel);

            // Save the state of the DB.
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a list of HotelRoom objects for a given Hotel object.
        /// </summary>
        /// <param name="hotelID">The ID of the given Hotel object.</param>
        /// <returns>A list of HotelRoom objects.</returns>
        public async Task<List<HotelRoomDTO>> GetHotelRoomsByHotelID(int hotelID)
        {
            // Grab a list of all HotelRoom objects that match the given Hotel object ID.
            var result = await _context.HotelRooms.Where(x => x.HotelID == hotelID).ToListAsync();

            // Create a new List to hold the HotelRoomDTO objects.
            List<HotelRoomDTO> hotelRooms = new List<HotelRoomDTO>();

            foreach (var hotelRoom in result)
            {
                HotelRoomDTO room = await _hotelRooms.GetHotelRoomByRoomNumber(room.HotelID, hotelRoom.RoomNumber);
                hotelRooms.Add(room);

            }

            return hotelRooms;
                
        }

        /// <summary>
        /// Converts a Hotel object from the DB to a HotelDTO object.
        /// </summary>
        /// <param name="hotel">The Hotel object to be converted.</param>
        /// <returns>The newly converted HotelDTO object.</returns>
        public HotelDTO ConvertHotelToHotelDTO(Hotel hotel)
        {
            HotelDTO hotelDTO = new HotelDTO()
            {
                ID = hotel.ID,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone
            };

            return hotelDTO;
        }
    }
}
