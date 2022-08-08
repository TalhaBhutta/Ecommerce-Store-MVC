using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NetCuisine.Areas.Identity.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCuisine.Services
{
    public interface IUserService
    {
        Task<NetCuisineUser> GetCurrentUserAsync();
        
    }
    public class UserService : IUserService
    {
        private readonly UserManager<NetCuisineUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

      
        public UserService(UserManager<NetCuisineUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<NetCuisineUser> GetCurrentUserAsync()
        {
            
            throw new System.NotImplementedException();
        }
    }
}
