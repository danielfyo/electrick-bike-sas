using AutoMapper;
using ElectricBike.Domain.Core.Persons;

namespace ElectricBike.Application.Core.Services.Persons;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repo;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository repoIn, IMapper mapper)
    {
        _repo = repoIn;
        _mapper = mapper;
    }

    public async Task<PersonDto> Create(PersonDto dto)
    {
        if (dto.BirthDay != null && dto.DateOfBirth == null)
            dto.DateOfBirth = dto.BirthDay;
        return _mapper.Map<PersonDto>(await _repo.Add(_mapper.Map<Person>(dto)).ConfigureAwait(false));
    }

    public async Task<PersonDto> GetById(Guid id)
    {
        var person = _mapper.Map<PersonDto>(await _repo.GetById(id).ConfigureAwait(false));
        person.BirthDay = person.DateOfBirth?.DateTime;
        return person;
    }

    public async Task<IEnumerable<PersonDto>> GetAll()
    {
        var persons = _mapper.Map<IEnumerable<PersonDto>>(await _repo.GetAll().ConfigureAwait(false));
        foreach (var person in persons)
        {
            person.BirthDay = person.DateOfBirth?.DateTime;
        }
        return persons;
    }

    public async Task<bool> Update(PersonDto dto)
    {
        if (dto.BirthDay != null && dto.DateOfBirth == null)
            dto.DateOfBirth = dto.BirthDay;
        return await _repo.Update(_mapper.Map<Person>(dto)).ConfigureAwait(false);
    }

    public async Task<bool> Delete(Guid id) => await _repo.Delete(id).ConfigureAwait(false);
}