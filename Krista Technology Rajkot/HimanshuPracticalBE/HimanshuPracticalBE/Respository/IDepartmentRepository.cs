using HimanshuPracticalBE.Models;

namespace HimanshuPracticalBE.Respository
{
    public interface IDepartmentRepository
    {
        Task<DepartmentModel> AddDepartment(DepartmentModel model);
        Task<bool> DeleteDepartment(int Id);
        Task<List<DepartmentModel>> GetAllDepartment();
        Task<DepartmentModel> GetDepartmentById(int Id);
        Task<List<DepartmentwiseLocation>> GetDepartmentWiseLocation(int userID);
    }
}