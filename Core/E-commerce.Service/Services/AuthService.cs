using E_commerce.Domain.Entities.Auth;
using E_commerce.Service.Contracts;
using E_commerce.ServiceAbstraction.Common;
using E_commerce.Shared.DataTransferObjects.Auth;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Service.Services;

internal class AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
    : IAuthService
{
    public async Task<bool> CheckEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email) != null;
    }

    public async Task<Result<UserResponse>> LoginAsync(LoginRequest loginRequest)
    {
        var user = await userManager.FindByEmailAsync(loginRequest.Email);
        if (user == null)
            return Result<UserResponse>.Fail(Error.Unauthorized(description: "Invalid Email or Password"));

        var result = await userManager.CheckPasswordAsync(user, loginRequest.Password);

        if (!result)
            return Result<UserResponse>.Fail(Error.Unauthorized(description: "Invalid Email or Password"));

        var roles = await userManager.GetRolesAsync(user);
        var token = tokenService.GetToken(user, roles);
        return new UserResponse(user.Email, user.DisplayName, token);
    }

    public async Task<Result<UserResponse>> RegisterAsync(RegisterRequest registerRequest)
    {
        var user = new ApplicationUser
        {
            Email = registerRequest.Email,
            UserName = registerRequest.UserName,
            DisplayName = registerRequest.DisplayName,
            PhoneNumber = registerRequest.PhoneNumber
        };

        var result = await userManager.CreateAsync(user, registerRequest.Password);

        if (!result.Succeeded)
            return result.Errors.Select(e => Error.Validation(e.Code, e.Description)).ToList();


        var token = tokenService.GetToken(user, []);
        return new UserResponse(user.Email, user.DisplayName, token);


    }
}
