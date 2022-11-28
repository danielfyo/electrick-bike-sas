using System.Reflection.Metadata.Ecma335;
using ElectricBike.Application.Core.Services.Persons;
using ElectricBike.Application.Core.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _service;

    public UserController(ILogger<UserController> logger, IUserService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost(nameof(Create))]
    public async Task<UserDto> Create(UserDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(UserController)} => {nameof(Create)}");
        return await _service.Create(dto).ConfigureAwait(false);
    }
    
    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<UserDto>> GetAll()
    {
        _logger.Log(LogLevel.Information, $"{nameof(UserController)} => {nameof(GetAll)}");
        return await _service.GetAll().ConfigureAwait(false);
    }

    [HttpGet($"{nameof(GetById)}/"+"{id}")]
    public async Task<UserDto?> GetById(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(UserController)} => {nameof(GetById)} => {id}");
        return await _service.GetById(id).ConfigureAwait(false);
    }
   
    [HttpPut(nameof(Update))]
    public async Task<bool> Update(UserDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(UserController)} => {nameof(Update)}");
        return await _service.Update(dto).ConfigureAwait(false);
    }
    
    [HttpDelete($"{nameof(Delete)}"+"/{id}")]
    public async Task<bool> Delete(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(UserController)} => {nameof(Delete)} => {id}");
        return await _service.Delete(id).ConfigureAwait(false);
    }
}