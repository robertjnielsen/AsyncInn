using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        /// <summary>
        /// Primary Key.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of Room object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Layout of Room object.
        /// </summary>
        public int Layout { get; set; }

        // Navigation Properties
        public List<RoomAmenities> RoomAmenities { get; set; }

        public List<HotelRoom> HotelRooms { get; set; }
    }

    /// <summary>
    /// Enum of Room object Layout.
    /// </summary>
    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }


}
