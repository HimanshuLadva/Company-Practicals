

using HimanshuPractIcalTaskBE.DBModels;
using HimanshuPractIcalTaskBE.Models;

namespace HimanshuPractIcalTaskBE.Repository
{
    public interface IUserRepository
    {
        Task<bool> AddUser(UserModel model);
        Task<bool> DeleteUser(int Id);
        Task<List<UserViewModel>> GetAllUser();
        Task<UserViewModel> GetUserById(int Id);
        Task<List<Education>> GetUserEducation();
        Task<bool> UpdateUser(int Id, UserModel model);
    }
}