using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelService : IHotelManager
    {
        private AsyncInnDbContext _context;

        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public Task<Hotel> CreateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public Task<Hotel> GetHotelByID(int HotelID)
        {
            throw new NotImplementedException();
        }

        public Task RemoveHotel(int HotelID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHotel(int HotelID, Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
