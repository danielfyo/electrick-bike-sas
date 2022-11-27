using AutoMapper;
using ElectricBike.Domain.Core.Persons;
using ElectricBike.Domain.Core.Users;

namespace ElectricBike.Application.Core.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    private readonly IPersonRepository _personRepo;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repoIn, IMapper mapper, IPersonRepository personRepo)
    {
        _repo = repoIn;
        _mapper = mapper;
        _personRepo = personRepo;
    }

    public async Task<UserDto> Create(UserDto dto) => 
        _mapper.Map<UserDto>(await _repo.Add(_mapper.Map<User>(dto)).ConfigureAwait(false));

    public async Task<UserDto?> GetById(Guid id)
    {
        var user = await _repo.GetById(id).ConfigureAwait(false);
        if (user == null)
            return null;
        user.Person = await _personRepo.GetById(user.PersonId).ConfigureAwait(false) ?? new ();
        return _mapper.Map<UserDto>(user);
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {
        var users = await _repo.GetAll().ConfigureAwait(false);
        foreach (var user in users)
        {
            user.Person = await _personRepo.GetById(user.PersonId).ConfigureAwait(false) ?? new();
        }
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<bool> Update(UserDto dto) => 
        await _repo.Update(_mapper.Map<User>(dto)).ConfigureAwait(false);

    public async Task<bool> Delete(Guid id) => await _repo.Delete(id).ConfigureAwait(false);
}