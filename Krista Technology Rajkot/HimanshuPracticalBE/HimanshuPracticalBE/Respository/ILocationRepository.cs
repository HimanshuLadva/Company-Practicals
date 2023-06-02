using HimanshuPracticalBE.Models;

namespace HimanshuPracticalBE.Respository
{
    public interface ILocationRepository
    {
        Task<LocationModel> AddLocation(LocationModel model);
        Task<bool> DeleteLocation(int Id);
        Task<List<LocationModel>> GetAllLocation();
        Task<LocationModel> GetLocationById(int Id);
    }
}