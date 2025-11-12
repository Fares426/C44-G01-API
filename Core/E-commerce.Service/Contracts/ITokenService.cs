using E_commerce.Domain.Entities.Auth;

namespace E_commerce.Service.Contracts;

public interface ITokenService
{
    string GetToken(ApplicationUser user, IList<string> roles);
}
