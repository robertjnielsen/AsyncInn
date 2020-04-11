
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Amenities
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of the Amenity.
        /// </summary>
        public string Name { get; set; }

        // Navigation Properties

        /// <summary>
        /// List of RoomAmenities objects.
        /// </summary>
        public RoomAmenities RoomAmenities { get; set; }

    }
}
