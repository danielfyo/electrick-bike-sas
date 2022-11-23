using AutoMapper;
using ElectricBike.Application.Core.Dtos;

namespace ElectricBike.Application.Core.Services.Users;

public class UserIntentionMapperProfile  : Profile
{
    public UserIntentionMapperProfile()
    {
        CreateMap<Domain.Core.EngineSuppliers.EngineSupplier, EngineSupplierDto>().ReverseMap();
    }
}