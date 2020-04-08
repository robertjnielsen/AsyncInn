using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoomManager
    {
        Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom);
        Task UpdateHotelRoom(int HotelRoomID, HotelRoom hotelRoom);
        Task<List<HotelRoom>> GetAllHotelRooms();
        Task<HotelRoom> GetHotelRoomByID(int HotelRoomID);
        Task RemoveHotelRoom(int HotelRoomID);
    }
}
