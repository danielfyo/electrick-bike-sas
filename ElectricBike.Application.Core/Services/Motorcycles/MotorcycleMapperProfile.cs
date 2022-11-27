using AutoMapper;
using ElectricBike.Domain.Core.Motorcycles;

namespace ElectricBike.Application.Core.Services.Motorcycles;

public class MotorcycleMapperProfile  : Profile
{
    public MotorcycleMapperProfile()
    {
        CreateMap<Motorcycle, MotorcycleDto>().ReverseMap();
    }
}