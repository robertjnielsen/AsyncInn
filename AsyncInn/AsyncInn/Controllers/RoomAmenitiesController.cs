using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAmenitiesController : ControllerBase
    {
        /// <summary>
        /// The DBContext.
        /// </summary>
        private readonly AsyncInnDbContext _context;

        /// <summary>
        /// Constructor method to inject the DBContext.
        /// </summary>
        /// <param name="context">The DBContext.</param>
        public RoomAmenitiesController(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates and inserts a new RoomAmenities object into the DB.
        /// </summary>
        /// <param name="roomAmenities">The data for the new RoomAmenities object.</param>
        /// <returns>The newly inserted RoomAmenities object.</returns>
        // POST: api/RoomAmenities/new/5/5
        [HttpPost, Route("new/{roomID}/{amenitiesID}")]
        public async Task<ActionResult<RoomAmenities>> PostRoomAmenities(RoomAmenities roomAmenities)
        {
            // Add the new RoomAmenities object to the DB.
            _context.RoomAmenities.Add(roomAmenities);

            // Save the state of the DB.
            await _context.SaveChangesAsync();

            // Return the new RoomAmenities object.
            return CreatedAtAction("GetRoomAmenities", new { id = roomAmenities.RoomID }, roomAmenities);
        }

        /// <summary>
        /// Deletes a RoomAmenities object from the DB.
        /// </summary>
        /// <param name="id">The ID of the RoomAmenities object to delete.</param>
        /// <returns>Nothing.</returns>
        // DELETE: api/RoomAmenities/remove/5/5
        [HttpDelete, Route("remove/{roomID}/{amenitiesID}")]
        public async Task<ActionResult<RoomAmenities>> DeleteRoomAmenities(int id)
        {
            var roomAmenities = await _context.RoomAmenities.FindAsync(id);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            _context.RoomAmenities.Remove(roomAmenities);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
