using E_commerce.ServiceAbstraction.Common;
using E_commerce.Shared.DataTransferObjects.Auth;
using E_commerce.Shared.DataTransferObjects.Users;

namespace E_commerce.ServiceAbstraction;

public interface IUserService
{
    Task<Result<UserResponse>> GetUserByEmailAsync(string email);
    Task<Result<AddressDTO>> GetAddressAsync(string email);
    Task<Result<AddressDTO>> UpdateAddressAsync(string email, AddressDTO addressDTO);
}
