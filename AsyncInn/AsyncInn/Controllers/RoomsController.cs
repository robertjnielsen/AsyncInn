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
    public class RoomsController : ControllerBase
    {
        /// <summary>
        /// Assigns the DB table / entity via IRoomManager and DI.
        /// </summary>
        private readonly IRoomManager _rooms;

        /// <summary>
        /// Constructor method for the controller.
        /// </summary>
        /// <param name="room">The Rooms table / entity passed by IRoomManager.</param>
        public RoomsController(IRoomManager rooms)
        {
            _rooms = rooms;
        }

        /// <summary>
        /// Adds a new Room object to the Rooms table / entity.
        /// </summary>
        /// <param name="room">The Room object to insert into the table.</param>
        /// <returns>The newly created Room object.</returns>
        // POST: api/Rooms/new
        [HttpPost, Route("new")]
        public async Task<ActionResult<RoomDTO>> PostRoom(Room room)
        {
            var result = await _rooms.CreateRoom(room);

            return CreatedAtAction("GetRoom", new { id = result.ID }, result);
        }

        /// <summary>
        /// Gets all Room objects from the Rooms table.
        /// </summary>
        /// <returns>A list of all Room objects.</returns>
        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            return await _rooms.GetAllRooms();
        }

        /// <summary>
        /// Gets a single Room object from the Rooms table.
        /// </summary>
        /// <param name="id">The ID of the Room object to retrieve.</param>
        /// <returns>Returns a single Room object.</returns>
        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            var room = await _rooms.GetRoomByID(id);

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
        // PUT: api/Rooms/update/5
        [HttpPut, Route("update/{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            await _rooms.UpdateRoom(room);

            return NoContent();
        }

        /// <summary>
        /// Deletes a Room object from the Rooms table.
        /// </summary>
        /// <param name="id">The ID of the Room to delete.</param>
        /// <returns>Nothing.</returns>
        // DELETE: api/Rooms/remove/5
        [HttpDelete, Route("remove/{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            if (! await RoomExists(id))
            {
                return NotFound();
            }
            else
            {
                await _rooms.RemoveRoom(id);

                return NoContent();
            }
        }

        /// <summary>
        /// Check if a Room object exists in the DB.
        /// </summary>
        /// <param name="id">The ID of the Room object to check for.</param>
        /// <returns>A boolean value whether or not the Room object exists.</returns>
        private async Task<bool> RoomExists(int id)
        {
            RoomDTO room = await _rooms.GetRoomByID(id);

            if (room != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
