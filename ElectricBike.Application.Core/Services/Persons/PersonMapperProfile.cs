using AutoMapper;
using ElectricBike.Domain.Core.Persons;

namespace ElectricBike.Application.Core.Services.Persons;

public class PersonMapperProfile  : Profile
{
    public PersonMapperProfile()
    {
        CreateMap<Person, PersonDto>().ReverseMap();
    }
}