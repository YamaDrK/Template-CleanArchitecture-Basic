using System.Security.Claims;
using Application.Interfaces.Services;

namespace WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int UserId { get; } = 0;

        public bool IsAuthenticated { get; } = false;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var id = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(id, out var userId))
            {
                UserId = userId;
                IsAuthenticated = true;
            }
        }
    }
}
