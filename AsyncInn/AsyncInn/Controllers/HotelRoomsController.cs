using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTO;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        /// <summary>
        /// Assigns the IHotelRoomManager interface for DI.
        /// </summary>
        private readonly IHotelRoomManager _context;

        /// <summary>
        /// Constructor method to inject the IHotelRoomManager interface.
        /// </summary>
        /// <param name="context"></param>
        public HotelRoomsController(IHotelRoomManager context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new HotelRoom object.
        /// </summary>
        /// <param name="hotelRoom">The data for the new HotelRoom object.</param>
        /// <returns>The newly created Hotelroom object.</returns>
        // POST: api/HotelRooms/new
        [HttpPost, Route("new")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            await _context.CreateHotelRoom(hotelRoom);

            return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelID }, hotelRoom);
        }

        /// <summary>
        /// Retrieve all HotelRoom objects.
        /// </summary>
        /// <returns>A list of all HotelRoom objects.</returns>
        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms()
        {
            return await _context.GetAllHotelRooms();
        }

        /// <summary>
        /// Retrieves a single HotelRoom object.
        /// </summary>
        /// <param name="hotelID">The ID of the given Hotel object.</param>
        /// <param name="roomNumber">The RoomNumber of the given HotelRoom object.</param>
        /// <returns>A single HotelRoomDTO object.</returns>
        // GET: api/HotelRooms/5/5
        [HttpGet, Route("{hotelId}/{roomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int hotelID, int roomNumber)
        {
            var hotelRoom = await _context.GetHotelRoomByRoomNumber(hotelID, roomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        /// <summary>
        /// Updates an existing HotelRoom object in the DB.
        /// </summary>
        /// <param name="roomNumber">The RoomNumber of the HotelRoom to update.</param>
        /// <param name="hotelRoom">The updated data for the HotelRoom.</param>
        /// <returns>Nothing.</returns>
        // PUT: api/HotelRooms/update/5
        [HttpPut, Route("update/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int roomNumber, HotelRoom hotelRoom)
        {
            if (roomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            await _context.UpdateHotelRoom(hotelRoom);

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing HotelRoom object from the DB.
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        // DELETE: api/HotelRooms/remove/5
        [HttpDelete, Route("remove/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int roomNumber)
        {
            await _context.RemoveHotelRoom(roomNumber);

            return NoContent();
        }

    }
}
