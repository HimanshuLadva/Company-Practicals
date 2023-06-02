using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MultiiconPracticalTask.Repository
{
    public class BaseRepository:IBaseRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //public bool IsContextNull()
        //{
        //    if(_httpContextAccessor.HttpContext == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        public string GetUserId()
        {
            string userId = string.Empty;
                userId = _httpContextAccessor!.HttpContext!.Request.HttpContext.User.Claims.First(c => c.Type == "UserId").Value;

            return userId;
        }
    }
}
