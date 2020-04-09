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

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        /// <summary>
        /// Assigns the DB table / entity via IRoomManager and DI.
        /// </summary>
        private readonly IRoomManager _room;

        /// <summary>
        /// Constructor method for the controller.
        /// </summary>
        /// <param name="room">The Rooms table / entity passed by IRoomManager.</param>
        public RoomsController(IRoomManager room)
        {
            _room = room;
        }

        /// <summary>
        /// Gets all Room objects from the Rooms table.
        /// </summary>
        /// <returns>A list of all Room objects.</returns>
        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await _room.GetAllRooms();
        }

        /// <summary>
        /// Gets a single Room object from the Rooms table.
        /// </summary>
        /// <param name="id">The ID of the Room object to retrieve.</param>
        /// <returns>Returns a single Room object.</returns>
        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _room.GetRoomByID(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        /// <summary>
        /// Updates an existing Room object in the Hotels table.
        /// </summary>
        /// <param name="id">The ID of the Room to update.</param>
        /// <param name="room">The updated information for the Room.</param>
        /// <returns>Nothing.</returns>
        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            await _room.UpdateRoom(id, room);

            return NoContent();
        }

        /// <summary>
        /// Adds a new Room object to the Rooms table / entity.
        /// </summary>
        /// <param name="room">The Room object to insert into the table.</param>
        /// <returns>The newly created Room object.</returns>
        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            var result = await _room.CreateRoom(room);

            return CreatedAtAction("GetRoom", new { id = result.ID }, result);
        }

        /// <summary>
        /// Deletes a Room object from the Rooms table.
        /// </summary>
        /// <param name="id">The ID of the Room to delete.</param>
        /// <returns>Nothing.</returns>
        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            await _room.RemoveRoom(id);

            return NoContent();
        }

        /*private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.ID == id);
        }*/
    }
}
