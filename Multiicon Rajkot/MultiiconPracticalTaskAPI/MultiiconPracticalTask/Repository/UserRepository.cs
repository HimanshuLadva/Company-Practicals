using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MultiiconPracticalTask.DBModels;
using MultiiconPracticalTask.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiiconPracticalTask.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserBookDBContext _dBContext;
        private readonly IConfiguration _configuration;
        private readonly IBaseRepository _baseRepository;
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;

        public UserRepository(UserBookDBContext dBContext, IConfiguration configuration,IOptions<JwtBearerTokenSettings> jwtTokenOptions, IBaseRepository baseRepository)
        {
            _dBContext = dBContext;
            _configuration = configuration;
            _baseRepository = baseRepository;
            _jwtBearerTokenSettings = jwtTokenOptions.Value;
        }

        public async Task<bool> AddUser(UserModel model)
        {
            var data = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                IsAdmin = model.IsAdmin,
            };

            await _dBContext.Users.AddAsync(data);
            return await _dBContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUser(UserModel model)
        {
            var appUserID = _baseRepository.GetUserId();
            var data = await _dBContext.Users.FindAsync(Convert.ToInt32(appUserID));

            if (data == null)
            {
                return false;
            }

            data.FirstName = model.FirstName;
            data.LastName = model.LastName;
            data.IsAdmin = model.IsAdmin;
            data.Password = model.Password;

            _dBContext.Users.Update(data);
            return await _dBContext.SaveChangesAsync() > 0;
        }

        public async Task<UserModel> GetUserById()
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
                IsAdmin = data.IsAdmin,
            };

            return result;
        }

        public async Task<UserDetail> CheckLogin(LoginModel model)
        {
            var data = await _dBContext.Users.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

            var result = new UserDetail()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = data.Password,
                IsAdmin = data.IsAdmin,
            };

            var authClaims = new List<Claim>
            {
                new Claim("UserName", model.Email),
                new Claim("UserId", data.Id.ToString()),
                new Claim("DisplayName", data.FirstName +""+ data.LastName),
                new Claim("Role", data.IsAdmin ? "Admin":"User"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

                /*new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, model.Email),
                new Claim(ClaimTypes.NameIdentifier, data.Id.ToString()),
                new Claim(ClaimTypes.GivenName,data.FirstName +""+ data.LastName),
                new Claim(ClaimTypes.Role, data.IsAdmin ? "Admin":"User")*/

                // new Claim(ClaimTypes.Name, model.Email),
                //new Claim(ClaimTypes.NameIdentifier, data.Id.ToString()),
             };

            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtBearerTokenSettings:SecretKey"]));

            var token = new JwtSecurityToken(
               issuer: _configuration["JwtBearerTokenSettings:ValidIssuer"],
               audience: _configuration["JwtBearerTokenSettings:ValidAudience"],
               expires: DateTime.Now.AddSeconds(_jwtBearerTokenSettings.ExpiryTimeInSeconds),
               claims: authClaims,
               signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
           );

            //var cookieOptions = new CookieOptions();
            //cookieOptions.HttpOnly = true;
            //cookieOptions.Expires = DateTime.Now.AddDays(0);
            result.Token = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
        public async Task<List<UserModel>> GetAllUser()
        {
            var result = await _dBContext.Users.Where(x => x.IsDeleted == false).Select(data => new UserModel()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = data.Password,
                IsAdmin = data.IsAdmin
            }).ToListAsync();

            return result;
        }

        public async Task<bool> DeleteUser()
        {
            var appUserID = _baseRepository.GetUserId();
            var data = await _dBContext.Users.FindAsync(Convert.ToInt32(appUserID));
            if (data == null) return false;

            data.IsDeleted = true;
            _dBContext.Users.Update(data);
            await _dBContext.SaveChangesAsync();
            return true;
        }

    }
}
