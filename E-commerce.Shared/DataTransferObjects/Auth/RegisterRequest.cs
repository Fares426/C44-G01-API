using System.ComponentModel.DataAnnotations;

namespace E_commerce.Shared.DataTransferObjects.Auth;

public record RegisterRequest(string DisplayName, [EmailAddress] string Email, string Password
    , string? UserName = "MMM", string? PhoneNumber = "");