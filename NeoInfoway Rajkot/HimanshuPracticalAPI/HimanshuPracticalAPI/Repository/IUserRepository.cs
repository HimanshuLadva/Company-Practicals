using HimanshuPracticalAPI.DBModels;
using HimanshuPracticalAPI.Models;

namespace HimanshuPracticalAPI.Repository
{
    public interface IUserRepository
    {
        Task<bool> AddUser(UserModel model);
        Task<UserDetail> CheckLogin(LoginModel model);
        Task<bool> DeleteUser(int Id);
        Task<List<UserViewModel>> GetAllUser();
        Task<UserModel> GetCurrentLoggedInUser();
        Task<UserModel> GetUserById(int Id);
        Task<List<Education>> GetUserEducation();
        Task<bool> UpdateUser(int Id, UserModel model);
    }
}