using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        Task<Hotel> CreateHotel(Hotel hotel);
        Task UpdateHotel(int HotelID, Hotel hotel);
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelByID(int HotelID);
        Task RemoveHotel(int HotelID);
    }

}
