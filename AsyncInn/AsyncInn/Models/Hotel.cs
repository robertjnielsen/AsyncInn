using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of Hotel object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Street address of Hotel object.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// City of Hotel object.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State of Hotel object.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Phone number of Hotel object.
        /// </summary>
        public string Phone { get; set; }

        //Navigation Properties

        /// <summary>
        /// List of HotelRooms objects.
        /// </summary>
        public List<HotelRoom> HotelRooms { get; set; }

    }
}
