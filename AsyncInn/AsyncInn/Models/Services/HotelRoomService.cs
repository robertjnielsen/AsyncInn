using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelRoomService : IHotelRoomManager
    {
        private readonly AsyncInnDbContext _context;
        private readonly IRoomManager _room;
        public HotelRoomService(AsyncInnDbContext context, IRoomManager room)
        {
            _context = context;
            _room = room;
        }
        public async Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Add(hotelRoom);
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task<List<HotelRoom>> GetAllHotelRooms()
        {
            var result = await _context.HotelRooms.ToListAsync();
            return result;
        }

     

        public async Task<HotelRoom> GetHotelRoomByRoomNumber(int roomNumber, int hotelId)
        {
            var result = await _context.HotelRooms.Where(x => x.RoomNumber == roomNumber && x.HotelID == hotelId)
                                                  .SingleAsync();
            return result;
        }

        public Task RemoveHotelRoom(int HotelRoomID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHotelRoom(int HotelRoomID, HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }
    }
}
