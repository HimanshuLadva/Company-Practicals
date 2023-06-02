using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HimanshuPracticalAPI.Repository
{
    public class BaseRepository:IBaseRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            string userId = string.Empty;
            //userId = _httpContextAccessor!.HttpContext!.Request.HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            userId = _httpContextAccessor!.HttpContext!.Request.HttpContext.User.Claims.First(c => c.Type == "UserId").Value;

            return userId;
        }
    }
}
