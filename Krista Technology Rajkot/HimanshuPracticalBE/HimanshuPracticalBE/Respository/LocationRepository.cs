using HimanshuPracticalBE.DBModels;
using HimanshuPracticalBE.Models;
using Microsoft.EntityFrameworkCore;

namespace HimanshuPracticalBE.Respository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly HimanshuPracticlaDB _context;

        public LocationRepository(HimanshuPracticlaDB context)
        {
            _context = context;
        }

        public async Task<LocationModel> AddLocation(LocationModel model)
        {
            var data = new Location()
            {
                Name = model.Name,
                DepartmentId = model.DepartmentId
            };

            await _context.Locations.AddAsync(data);
            await _context.SaveChangesAsync();
            return await GetLocationById(data.Id);
        }

        public async Task<LocationModel> GetLocationById(int Id)
        {
            var data = await _context.Locations.FindAsync(Id);
            var result = new LocationModel()
            {
                Id = data!.Id,
                Name = data.Name,
                DepartmentId = data.DepartmentId
            };
            return result;
        }

        public async Task<List<LocationModel>> GetAllLocation()
        {
            var result = await _context.Locations.Select(data => new LocationModel()
            {
                Id = data.Id,
                Name = data.Name,
                DepartmentId = data.DepartmentId
            }).ToListAsync();
            return result;
        }

        public async Task<bool> DeleteLocation(int Id)
        {
            var data = await _context.Locations.FindAsync(Id);
            if (data == null) return false;

            _context.Locations.Remove(data);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
