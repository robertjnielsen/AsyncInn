using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.DTO
{
    public class HotelDTO
    {
        /// <summary>
        /// The ID of the Hotel object.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The Name of the Hotel object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The street address of the Hotel object.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// The city of the Hotel object.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The state of the Hotel object.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The phone number of the Hotel object.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// A list of rooms this Hotel object contains.
        /// </summary>
        public List<HotelRoomDTO> Rooms { get; set; }
    }
}
