using AutoMapper;
using ElectricBike.Application.Core.Services.EngineSuppliers;

namespace ElectricBike.Application.Core.Services.Manufacturers;

public class ManufacturerMapperProfile  : Profile
{
    public ManufacturerMapperProfile()
    {
        CreateMap<Domain.Core.EngineSuppliers.EngineSupplier, EngineSupplierDto>().ReverseMap();
    }
}