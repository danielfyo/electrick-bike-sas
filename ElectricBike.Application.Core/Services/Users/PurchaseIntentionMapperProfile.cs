using AutoMapper;
using ElectricBike.Domain.Core.Users;

namespace ElectricBike.Application.Core.Services.Users;

public class UserIntentionMapperProfile  : Profile
{
    public UserIntentionMapperProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}