using E_commerce.ServiceAbstraction;
using E_commerce.Shared.DataTransferObjects.Auth;
using E_commerce.Shared.DataTransferObjects.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_commerce.Presentation.Controllers;
[Authorize]
public class UsersController(IUserService userService)
    : APIBaseController
{
    [HttpGet]
    public async Task<ActionResult<UserResponse>> GetUser()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var result = await userService.GetUserByEmailAsync(email);
        return HandleResult(result);
    }

    [HttpGet("Address")]
    public async Task<ActionResult<AddressDTO>> GetAddress()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var result = await userService.GetAddressAsync(email);
        return HandleResult(result);
    }


    [HttpPut("Address")]
    public async Task<ActionResult<AddressDTO>> UpdateAddress(AddressDTO addressDTO)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var result = await userService.UpdateAddressAsync(email, addressDTO);
        return HandleResult(result);
    }
}
