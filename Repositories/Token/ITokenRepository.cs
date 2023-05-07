using Microsoft.AspNetCore.Identity;

namespace TaskManagerAPI.Repositories.Token
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
