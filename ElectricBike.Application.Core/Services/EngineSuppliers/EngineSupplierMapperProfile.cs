using AutoMapper;
using ElectricBike.Application.Core.Dtos;

namespace ElectricBike.Application.Core.Services.EngineSupplier;

public class EngineSupportMapperProfile  : Profile
{
    public EngineSupportMapperProfile()
    {
        CreateMap<Domain.Core.EngineSuppliers.EngineSupplier, EngineSupplierDto>().ReverseMap();
    }
}