using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        /// <summary>
        /// Foreign Key / Composite Key.
        /// </summary>
        public int HotelID { get; set; }

        /// <summary>
        /// Composite Key.
        /// </summary>
        public int RoomNumber { get; set; }

        /// <summary>
        /// Foreign Key.
        /// </summary>
        public int RoomID { get; set; }

        /// <summary>
        /// Rate of HotelRoom object per night.
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Is HotelRoom object pet friendly?
        /// </summary>
        public bool PetFriendly { get; set; }

        //Navigation Properties
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
