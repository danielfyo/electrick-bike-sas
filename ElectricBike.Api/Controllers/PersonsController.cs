using ElectricBike.Application.Core.Services.Persons;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonsController : ControllerBase
{
    private readonly ILogger<PersonsController> _logger;
    private readonly IPersonService _service;

    public PersonsController(ILogger<PersonsController> logger, IPersonService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost(nameof(Create))]
    public async Task<PersonDto> Create(PersonDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(PersonsController)} => {nameof(Create)}");
        return await _service.Create(dto).ConfigureAwait(false);
    }
    
    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<PersonDto>> GetAll()
    {
        _logger.Log(LogLevel.Information, $"{nameof(PersonsController)} => {nameof(GetAll)}");
        return await _service.GetAll().ConfigureAwait(false);
    }

    [HttpGet($"{nameof(GetById)}/"+"{id}")]
    public async Task<PersonDto> GetById(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(PersonsController)} => {nameof(GetById)} => {id}");
        return await _service.GetById(id).ConfigureAwait(false);
    }
   
    [HttpPut(nameof(Update))]
    public async Task<bool> Update(PersonDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(PersonsController)} => {nameof(Update)}");
        return await _service.Update(dto).ConfigureAwait(false);
    }
    
    [HttpDelete($"{nameof(Delete)}"+"/{id}")]
    public async Task<bool> Delete(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(PersonsController)} => {nameof(Delete)} => {id}");
        return await _service.Delete(id).ConfigureAwait(false);
    }
}