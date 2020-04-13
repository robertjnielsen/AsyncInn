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
    public class HotelsController : ControllerBase
    {
        /// <summary>
        /// Assigns the DB table / entity via IHotelManager and DI.
        /// </summary>
        private readonly IHotelManager _hotels;

        /// <summary>
        /// Constructor method for the controller.
        /// </summary>
        /// <param name="hotel">The Hotels table / entity passed by IHotelManager.</param>
        public HotelsController(IHotelManager hotels)
        {
            _hotels = hotels;
        }

        /// <summary>
        /// Adds a new Hotel object to the Hotels table / entity.
        /// </summary>
        /// <param name="hotel">The Hotel object to insert into the table.</param>
        /// <returns>The newly created Hotel object.</returns>
        // POST: api/Hotels/new
        [HttpPost, Route("new")]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            var result = await _hotels.CreateHotel(hotel);

            return CreatedAtAction("GetHotel", new { id = result.ID }, result);
        }

        /// <summary>
        /// Gets all Hotel objects from the Hotels table.
        /// </summary>
        /// <returns>Returns a list of all Hotel objects.</returns>
        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
            return await _hotels.GetAllHotels();
        }

        /// <summary>
        /// Gets a single Hotel object from the Hotels table.
        /// </summary>
        /// <param name="id">The ID of the Hotel object to retrieve.</param>
        /// <returns>Returns a single Hotel object.</returns>
        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            var hotel = await _hotels.GetHotelByID(id);

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
        // PUT: api/Hotels/update/5
        [HttpPut, Route("update/{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
           if (id != hotel.ID)
           {
               return BadRequest();
           }

            await _hotels.UpdateHotel(hotel);

            return NoContent();
        }

        /// <summary>
        /// Deletes a Hotel object from the Hotels table.
        /// </summary>
        /// <param name="id">The ID of the Hotel to delete.</param>
        /// <returns>Nothing.</returns>
        // DELETE: api/Hotels/remove/5
        [HttpDelete, Route("remove/{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            if (! await HotelExists(id))
            {
                return NotFound();
            }
            else
            {
                await _hotels.RemoveHotel(id);

                return NoContent();
            }
        }

        /// <summary>
        /// Check if a Hotel object exists within the DB.
        /// </summary>
        /// <param name="id">The ID of the Hotel object to check for.</param>
        /// <returns>A boolean value if the Hotel exists or not.</returns>
        private async Task<bool> HotelExists(int id)
        {
            HotelDTO hotel = await _hotels.GetHotelByID(id);

            if (hotel != null)
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
