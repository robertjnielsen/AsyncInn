using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        Task<Amenities> CreateAmenities(Amenities amenities);
        Task UpdateAmenities(int AmenitiesID, Amenities amenities);
        Task<List<Amenities>> GetAllAmenities();
        Task<Amenities> GetAmenitiesByID(int AmenitiesID);
        Task RemoveAmenities(int AmenitiesID);
    }
}
