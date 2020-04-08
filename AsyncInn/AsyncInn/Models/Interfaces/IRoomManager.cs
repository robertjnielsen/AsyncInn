using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        Task<Room> CreateRoom(Room room);
        Task UpdateRoom(int RoomID, Room room);
        Task<List<Room>> GetAllRooms();
        Task<Room> GetRoomByID(int RoomID);
        Task RemoveRoom(int RoomID);
    }
}
