using System.ComponentModel.DataAnnotations;

namespace E_commerce.Shared.DataTransferObjects.Auth;

public record LoginRequest([EmailAddress] string Email, string Password);
