using E_commerce.ServiceAbstraction;
using E_commerce.Shared.DataTransferObjects.Auth;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Presentation.Controllers;

public class AuthController(IAuthService authService)
    : APIBaseController
{
    //Post / Register
    [HttpPost("Register")]
    public async Task<ActionResult<UserResponse>> Register(RegisterRequest registerRequest)
    {
        var result = await authService.RegisterAsync(registerRequest);
        return HandleResult(result);
    }


    //Check Email Exists 


    //Post / Login => Token
    [HttpPost("Login")]
    public async Task<ActionResult<UserResponse>> Login(LoginRequest loginRequest)
    {
        var result = await authService.LoginAsync(loginRequest);
        return HandleResult(result);
    }



    [HttpGet("CheckEmail")]
    public async Task<ActionResult<bool>> CheckEmail(string email)
    {
        return Ok(await authService.CheckEmailAsync(email));
    }



}
