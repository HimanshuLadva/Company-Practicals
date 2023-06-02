using MultiiconPracticalTask.Models;

namespace MultiiconPracticalTask.Repository
{
    public interface IUserRepository
    {
        Task<bool> AddUser(UserModel model);
        Task<UserDetail> CheckLogin(LoginModel model);
        Task<bool> DeleteUser();
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetUserById();
        Task<bool> UpdateUser(UserModel model);
    }
}