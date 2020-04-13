using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.DTO
{
    public class RoomDTO
    {
        /// <summary>
        /// The ID of the Room object.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The name of the Room object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The layout of the Room object.
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// A list of the Amenities associated with the Room object.
        /// </summary>
        public List<AmenityDTO> Amenities { get; set; }
    }
}
