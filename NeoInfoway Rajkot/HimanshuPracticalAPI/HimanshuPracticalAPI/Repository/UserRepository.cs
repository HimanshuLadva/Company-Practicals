using HimanshuPracticalAPI.DBModels;
using HimanshuPracticalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace HimanshuPracticalAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HimanshuPracticalDB _dBContext;
        private readonly IConfiguration _configuration;
        private readonly IBaseRepository _baseRepository;
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(HimanshuPracticalDB dBContext, IConfiguration configuration, IOptions<JwtBearerTokenSettings> jwtTokenOptions, IBaseRepository baseRepository, IHttpContextAccessor httpContextAccessor)
        {
            _dBContext = dBContext;
            _configuration = configuration;
            _baseRepository = baseRepository;
            _jwtBearerTokenSettings = jwtTokenOptions.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddUser(UserModel model)
        {
            var data = new Users()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                GenderId = model.GenderId,
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
            data.GenderId = model.GenderId;

            _dBContext.Users.Update(data);
            return await _dBContext.SaveChangesAsync() > 0;
        }

        public async Task<UserModel> GetCurrentLoggedInUser()
        {

            var appUserID = _baseRepository.GetUserId();
            var data = await _dBContext.Users.FindAsync(Convert.ToInt32(appUserID));

            var result = new UserModel()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = data.Password,
                GenderId = data.GenderId,
                EducationId = data.EducationId,
            };
            return result;
        }

        public async Task<UserModel> GetUserById(int Id)
        {

            var data = await _dBContext.Users.FindAsync(Id);

            var result = new UserModel()
            {
                Id = data!.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = data.Password,
                GenderId = data.GenderId,
                EducationId = data.EducationId,
            };
            return result;
        }

        public async Task<UserDetail> CheckLogin(LoginModel model)
        {
            var data = await _dBContext.Users.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefaultAsync();

            var result = new UserDetail()
            {
                Id = data!.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = data.Password,
                GenderId = data.GenderId,
                EducationId = data.EducationId,
            };

            var authClaims = new List<Claim>
            {
                new Claim("UserName", model.Email),
                new Claim("UserId", data.Id.ToString()),
                new Claim("DisplayName", data.FirstName +""+ data.LastName),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtBearerTokenSettings:SecretKey"]));

            var token = new JwtSecurityToken(
               issuer: _configuration["JwtBearerTokenSettings:ValidIssuer"],
               audience: _configuration["JwtBearerTokenSettings:ValidAudience"],
               expires: DateTime.Now.AddSeconds(_jwtBearerTokenSettings.ExpiryTimeInSeconds),
               claims: authClaims,
               signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
           );

            result.Token = new JwtSecurityTokenHandler().WriteToken(token);
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
                GenderId = data.GenderId,
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
