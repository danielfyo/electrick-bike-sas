namespace ElectricBike.Application.Core.Services.Persons;

public interface IPersonService
{
    Task<PersonDto> Create(PersonDto dto);
    Task<PersonDto> GetById(Guid id);
    Task<IEnumerable<PersonDto>> GetAll();
    Task<bool> Update(PersonDto dto);
    Task<bool> Delete(Guid id);
}