using AutoMapper;
using ElectricBike.Domain.Core.Users;

namespace ElectricBike.Application.Core.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repoIn, IMapper mapper)
    {
        _repo = repoIn;
        _mapper = mapper;
    }

    public async Task<UserDto> Create(UserDto dto) => 
        _mapper.Map<UserDto>(await _repo.Add(_mapper.Map<User>(dto)).ConfigureAwait(false));

    public async Task<UserDto> GetById(int id) => 
        _mapper.Map<UserDto>(await _repo.GetAll().ConfigureAwait(false));

    public async Task<IEnumerable<UserDto>> GetAll() =>
        _mapper.Map<IEnumerable<UserDto>>((await _repo.GetAll().ConfigureAwait(false)));

    public async Task<bool> Update(UserDto dto) => 
        await _repo.Update(_mapper.Map<User>(dto)).ConfigureAwait(false);

    public async Task<bool> Delete(int id) => await _repo.Delete(id).ConfigureAwait(false);
}