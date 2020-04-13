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
    public class AmenitiesController : ControllerBase
    {
        /// <summary>
        /// Assigns the DB table / entity via IRoomManager and DI.
        /// </summary>
        private readonly IAmenitiesManager _amenities;

        /// <summary>
        /// Constructor method for the controller.
        /// </summary>
        /// <param name="room">The Rooms table / entity passed by IRoomManager.</param>
        public AmenitiesController(IAmenitiesManager amenities)
        {
            _amenities = amenities;
        }

        /// <summary>
        /// Adds a new Amenities object to the Amenities table / entity.
        /// </summary>
        /// <param name="amenities">The Amenities object to insert into the table.</param>
        /// <returns>The newly created Amenities object.</returns>
        // POST: api/Amenities/new
        [HttpPost, Route("new")]
        public async Task<ActionResult<AmenityDTO>> PostAmenities(Amenities amenities)
        {
            var result = await _amenities.CreateAmenities(amenities);

            return CreatedAtAction("GetAmenities", new { id = result.ID }, result);
        }

        /// <summary>
        /// Gets all Amenities objects from the Amenities table.
        /// </summary>
        /// <returns>A list of all Amenities objects.</returns>
        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
            return await _amenities.GetAllAmenities();
        }

        /// <summary>
        /// Gets a single Amenities object from the Amenities table.
        /// </summary>
        /// <param name="id">The ID of the Amenities object to retrieve.</param>
        /// <returns>Returns a single Amenities object.</returns>
        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenities(int id)
        {
            var result = await _amenities.GetAmenitiesByID(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        /// <summary>
        /// Updates an existing Amenities object in the Amenities table.
        /// </summary>
        /// <param name="id">The ID of the Amenities object to update.</param>
        /// <param name="amenities">The updated information for the Amenities object.</param>
        /// <returns>Nothing.</returns>
        // PUT: api/Amenities/update/5
        [HttpPut, Route("update/{id}")]
        public async Task<IActionResult> PutAmenities(int id, Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return BadRequest();
            }

            await _amenities.UpdateAmenities(amenities);

            return NoContent();
        }

        /// <summary>
        /// Deletes an Amenities object from the Amenities table.
        /// </summary>
        /// <param name="id">The ID of the Amenities object to delete.</param>
        /// <returns>Nothing.</returns>
        // DELETE: api/Amenities/remove/5
        [HttpDelete, Route("remove/{id}")]
        public async Task<ActionResult<Amenities>> DeleteAmenities(int id)
        {
            if (! await AmenitiesExists(id))
            {
                return NotFound();
            }
            else
            {
                await _amenities.RemoveAmenities(id);

                return NoContent();
            }
        }

        /// <summary>
        /// Checks to see if a given Amenities object exists in the DB.
        /// </summary>
        /// <param name="id">The ID of the given Amenities object.</param>
        /// <returns>A boolean determined by whether the object exists or not.</returns>
        private async Task<bool> AmenitiesExists(int id)
        {
            AmenityDTO result = await _amenities.GetAmenitiesByID(id);

            if (result != null)
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
