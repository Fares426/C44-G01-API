using E_commerce.ServiceAbstraction.Common;
using E_commerce.Shared.DataTransferObjects.Auth;

namespace E_commerce.ServiceAbstraction;

public interface IAuthService
{
    Task<Result<UserResponse>> LoginAsync(LoginRequest loginRequest);
    Task<Result<UserResponse>> RegisterAsync(RegisterRequest registerRequest);
    Task<bool> CheckEmailAsync(string email);
}
