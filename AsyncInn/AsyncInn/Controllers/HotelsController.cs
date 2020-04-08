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
    public class HotelsController : ControllerBase
    {
        /// <summary>
        /// Assigns the DB table / entity via IHotelManager and DI.
        /// </summary>
        private readonly IHotelManager _hotel;

        /// <summary>
        /// Constructor method for the controller.
        /// </summary>
        /// <param name="hotel">The Hotels table / entity passed by IHotelManager.</param>
        public HotelsController(IHotelManager hotel)
        {
            _hotel = hotel;
        }

        /// <summary>
        /// Adds a new Hotel object to the Hotels table / entity.
        /// </summary>
        /// <param name="hotel">The Hotel object to insert into the table.</param>
        /// <returns>The newly created Hotel object.</returns>
        // POST: api/Hotels
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            var result = await _hotel.CreateHotel(hotel);

            return CreatedAtAction("GetHotel", new { id = result.ID }, result);
        }

        /// <summary>
        /// Gets all Hotel objects from the Hotels table.
        /// </summary>
        /// <returns>Returns a list of all Hotel objects.</returns>
        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return await _hotel.GetAllHotels();
        }

        /// <summary>
        /// Gets a single Hotel object from the Hotels table.
        /// </summary>
        /// <param name="id">The ID of the Hotel object to retrieve.</param>
        /// <returns>Returns a single Hotel object.</returns>
        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _hotel.GetHotelByID(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        /// <summary>
        /// Updates an existing Hotel object in the Hotels table.
        /// </summary>
        /// <param name="id">The ID of the Hotel to update.</param>
        /// <param name="hotel">The updated information for the Hotel.</param>
        /// <returns>Nothing.</returns>
        // PUT: api/Hotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
           if (id != hotel.ID)
           {
               return BadRequest();
           }

            await _hotel.UpdateHotel(id, hotel);

            return NoContent();
        }

        /// <summary>
        /// Deletes a Hotel object from the Hotels table.
        /// </summary>
        /// <param name="id">The ID of the Hotel to delete.</param>
        /// <returns>Nothing.</returns>
        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            await _hotel.RemoveHotel(id);

            return NoContent();
        }
    }
}
