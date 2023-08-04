
using SimpleBookAPI;

namespace BookAPI.Services.IServices
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(AppUser applicationUser, IEnumerable<string> roles);
    }
}
