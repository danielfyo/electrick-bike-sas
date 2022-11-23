using ElectricBike.Application.Core.Dtos;

namespace ElectricBike.Application.Core.Services.Persons;

public interface IPersonService
{
    Task<PersonDto> Create(PersonDto dto);
    Task<PersonDto> GetById(int id);
    Task<IEnumerable<PersonDto>> GetAll();
    Task<bool> Update(PersonDto dto);
    Task<bool> Delete(int id);
}