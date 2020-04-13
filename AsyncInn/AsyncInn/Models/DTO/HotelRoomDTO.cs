using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.DTO
{
    public class HotelRoomDTO
    {
        /// <summary>
        /// The ID of the Hotel object associated with the HotelRoom object.
        /// </summary>
        public int HotelID { get; set; }

        /// <summary>
        /// The room number of the HotelRoom object.
        /// </summary>
        public int RoomNumber { get; set; }

        /// <summary>
        /// The ID of the Room object associated with the HotelRoom object.
        /// </summary>
        public int RoomID { get; set; }

        /// <summary>
        /// The nightly rate of the HotelRoom object.
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Whether or not the HotelRoom object is pet friendly.
        /// </summary>
        public bool PetFriendly { get; set; }

        /// <summary>
        /// The Room object associate with the HotelRoom object.
        /// </summary>
        public RoomDTO Room { get; set; }
    }
}
