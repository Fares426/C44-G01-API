namespace E_commerce.Service.MappingProfiles;

internal class UserProfiles : Profile
{
    public UserProfiles()
    {
        CreateMap<Address, AddressDTO>().ReverseMap();
    }
}
