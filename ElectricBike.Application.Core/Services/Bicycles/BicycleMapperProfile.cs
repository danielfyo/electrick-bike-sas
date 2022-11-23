using AutoMapper;
using ElectricBike.Application.Core.Dtos;
using ElectricBike.Domain.Core.Bicycles;

namespace ElectricBike.Application.Core.Services.Bicycles;

public class BicycleMapperProfile  : Profile
{
    public BicycleMapperProfile()
    {
        CreateMap<Bicycle, BicycleDto>().ReverseMap();
    }
}