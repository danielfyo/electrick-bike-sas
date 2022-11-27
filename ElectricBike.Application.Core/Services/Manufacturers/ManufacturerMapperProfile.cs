using AutoMapper;
using ElectricBike.Domain.Core.Manufacturers;

namespace ElectricBike.Application.Core.Services.Manufacturers;

public class ManufacturerMapperProfile  : Profile
{
    public ManufacturerMapperProfile()
    {
        CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();
    }
}