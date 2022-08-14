using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NetCuisine.Areas.Identity.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCuisine.Services
{
    public interface ICookieService
    {
        public Task SetAsync(string key, string value, int? expireTime);
        public void Remove(string key);
        public string Get(string key);
    }
    public class CookieService 
    {
        private readonly UserManager<NetCuisineUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

      
        public CookieService(UserManager<NetCuisineUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

       
    }
}
