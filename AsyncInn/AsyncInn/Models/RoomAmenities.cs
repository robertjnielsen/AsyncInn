using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        /// <summary>
        /// Composite Key / Primary Key.
        /// </summary>
        public int AmenitiesID { get; set; }

        /// <summary>
        /// Composite Key / Primary Key.
        /// </summary>
        public int RoomID { get; set; }

        // Navigation Properties

        public Room Room { get; set; }
        public Amenities Amenities { get; set; }
    }
}
