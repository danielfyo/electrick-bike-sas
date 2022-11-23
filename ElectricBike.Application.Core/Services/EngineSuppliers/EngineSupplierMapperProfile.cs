using AutoMapper;
using ElectricBike.Application.Core.Services.EngineSuppliers;

namespace ElectricBike.Application.Core.Services.EngineSupplier;

public class EngineSupportMapperProfile  : Profile
{
    public EngineSupportMapperProfile()
    {
        CreateMap<Domain.Core.EngineSuppliers.EngineSupplier, EngineSupplierDto>().ReverseMap();
    }
}