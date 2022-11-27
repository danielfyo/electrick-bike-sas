using System.Reflection.Metadata.Ecma335;
using ElectricBike.Application.Core.Services.Persons;
using ElectricBike.Application.Core.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserService _service;
    private readonly IPersonService _personService;

    public UsersController(ILogger<UsersController> logger, IUserService service, IPersonService personService)
    {
        _logger = logger;
        _service = service;
        _personService = personService;
    }

    [HttpPost(nameof(Create))]
    public async Task<UserDto> Create(UserDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(UsersController)} => {nameof(Create)}");
        return await _service.Create(dto).ConfigureAwait(false);
    }
    
    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<UserDto>> GetAll()
    {
        _logger.Log(LogLevel.Information, $"{nameof(UsersController)} => {nameof(GetAll)}");
        var users = (await _service.GetAll().ConfigureAwait(false)).ToArray();
        foreach (var user in users)
        {
            user.Person = await _personService.GetById(user.PersonId).ConfigureAwait(false);
        }
        return users;
    }

    [HttpGet($"{nameof(GetById)}/"+"{id}")]
    public async Task<UserDto?> GetById(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(UsersController)} => {nameof(GetById)} => {id}");
        var user =  await _service.GetById(id).ConfigureAwait(false);
        if (user == null)
            return null;
        user.Person = await _personService.GetById(user.PersonId).ConfigureAwait(false);
        return user;
    }
   
    [HttpPut(nameof(Update))]
    public async Task<bool> Update(UserDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(UsersController)} => {nameof(Update)}");
        return await _service.Update(dto).ConfigureAwait(false);
    }
    
    [HttpDelete($"{nameof(Delete)}"+"/{id}")]
    public async Task<bool> Delete(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(UsersController)} => {nameof(Delete)} => {id}");
        return await _service.Delete(id).ConfigureAwait(false);
    }
}