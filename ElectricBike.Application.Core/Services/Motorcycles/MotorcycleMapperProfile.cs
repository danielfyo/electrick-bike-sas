using AutoMapper;
using ElectricBike.Application.Core.Services.EngineSuppliers;

namespace ElectricBike.Application.Core.Services.Motorcycles;

public class MotorcycleMapperProfile  : Profile
{
    public MotorcycleMapperProfile()
    {
        CreateMap<Domain.Core.EngineSuppliers.EngineSupplier, EngineSupplierDto>().ReverseMap();
    }
}