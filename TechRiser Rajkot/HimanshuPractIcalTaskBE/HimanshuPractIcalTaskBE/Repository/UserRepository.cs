
using HimanshuPractIcalTaskBE.DBModels;
using HimanshuPractIcalTaskBE.Models;
using Microsoft.EntityFrameworkCore;

namespace HimanshuPractIcalTaskBE.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HimanshuPracticalDB _dBContext;
        private readonly IConfiguration _configuration;

        public UserRepository(HimanshuPracticalDB dBContext, IConfiguration configuration)
        {
            _dBContext = dBContext;
            _configuration = configuration;
        }

        public async Task<bool> AddUser(UserModel model)
        {
            var data = new Users()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Website = model.Website,
                GitLink = model.GitLink,
                EducationId = model.EducationId,
            };

            await _dBContext.Users.AddAsync(data);
            return await _dBContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUser(int Id, UserModel model)
        {
            var data = await _dBContext.Users.FindAsync(Id);

            if (data == null)
            {
                return false;
            }

            data.FirstName = model.FirstName;
            data.LastName = model.LastName;
            data.Password = model.Password;
            data.EducationId = model.EducationId;
            data.Website = model.Website;
            data.GitLink = model.GitLink;

            _dBContext.Users.Update(data);
            return await _dBContext.SaveChangesAsync() > 0;
        }

        public async Task<UserViewModel> GetUserById(int Id)
        {

            var data = await _dBContext.Users.FindAsync(Id);

            var result = new UserViewModel()
            {
                Id = data!.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = data.Password,
                Website = data.Website,
                GitLink = data.GitLink,
                Education = _dBContext!.Educations!.Where(x => x.Id == data.EducationId).FirstOrDefault().EducationName,
            };
            return result;
        }

        public async Task<List<UserViewModel>> GetAllUser()
        {
            var result = await _dBContext.Users.Where(x => x.IsDeleted == false).Select(data => new UserViewModel()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = data.Password,
                Website = data.Website,
                GitLink = data.GitLink,
                Education = _dBContext!.Educations!.Where(x => x.Id == data.EducationId).FirstOrDefault().EducationName,
            }).ToListAsync();

            return result;
        }

        public async Task<bool> DeleteUser(int Id)
        {
            var data = await _dBContext.Users.FindAsync(Id);
            if (data == null) return false;

            data.IsDeleted = true;
            _dBContext.Users.Update(data);
            return await _dBContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Education>> GetUserEducation()
        {
            var data = await _dBContext.Educations.ToListAsync();
            return data;
        }

    }
}
