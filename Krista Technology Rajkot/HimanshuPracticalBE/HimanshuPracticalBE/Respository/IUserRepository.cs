using HimanshuPracticalBE.Models;

namespace HimanshuPracticalBE.Respository
{
    public interface IUserRepository
    {
        Task<bool> AddUser(UserModel model);
        Task<bool> AssignDeptORLocationToUser(int userID, CheckedObj checkedObj);
        Task<bool> DeleteUser(int Id);
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetUserById(int Id);
        Task<List<UserDepartmentModel>> GetUserDepartments(int userID);
        Task<List<UserLocationModel>> GetUserLocations(int userID);
        Task<bool> UpdateUser(int Id, UserModel model);
    }
}