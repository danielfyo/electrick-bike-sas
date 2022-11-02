using ElectricBike.Application.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger) => _logger = logger;

    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<UserDto>> GetAll() =>new List<UserDto>();

    [HttpPost(nameof(Create))]
    public async Task<UserDto> Create(UserDto dto) => new UserDto();

    [HttpDelete("Delete/{id}")]
    public async Task<bool> Delete(int id) => true;

    [HttpPut(nameof(Update))]
    public async Task<bool> Update(UserDto dto) => true;

    [HttpGet("{nameof(GetById)}/{id}")]
    public async Task<UserDto> GetById(int id) => new UserDto();

    [HttpPost("{nameof(SearchMatching)}")]
    public Task<UserDto> SearchMatching(UserDto dto) =>
        throw new NotImplementedException();

    [HttpGet("{nameof(Consult)}/{dto}")]
    public async Task<UserDto> Consult(UserDto dto) => new UserDto();

    [HttpGet("{nameof(GetByIdUser)}/{id}")]
    public async Task<UserDto> GetByIdUser(int id) => new UserDto();
}