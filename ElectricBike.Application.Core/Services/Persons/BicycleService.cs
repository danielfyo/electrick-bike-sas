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

    public async Task<PersonDto> Create(PersonDto dto) => 
        _mapper.Map<PersonDto>(await _repo.Add(_mapper.Map<Person>(dto)).ConfigureAwait(false));

    public async Task<PersonDto> GetById(int id) => 
        _mapper.Map<PersonDto>(await _repo.GetAll().ConfigureAwait(false));

    public async Task<IEnumerable<PersonDto>> GetAll() =>
        _mapper.Map<IEnumerable<PersonDto>>((await _repo.GetAll().ConfigureAwait(false)));

    public async Task<bool> Update(PersonDto dto) => 
        await _repo.Update(_mapper.Map<Person>(dto)).ConfigureAwait(false);

    public async Task<bool> Delete(int id) => await _repo.Delete(id).ConfigureAwait(false);
}