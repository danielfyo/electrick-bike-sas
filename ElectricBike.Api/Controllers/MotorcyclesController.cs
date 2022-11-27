using ElectricBike.Application.Core.Services.Manufacturers;
using ElectricBike.Application.Core.Services.Motorcycles;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MotorcycleController : ControllerBase
{
    private readonly ILogger<MotorcycleController> _logger;
    private readonly IMotorcycleService _service;

    public MotorcycleController(ILogger<MotorcycleController> logger, IMotorcycleService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost(nameof(Create))]
    public async Task<MotorcycleDto> Create(MotorcycleDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(MotorcycleController)} => {nameof(Create)}");
        return await _service.Create(dto).ConfigureAwait(false);
    }
    
    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<MotorcycleDto>> GetAll()
    {
        _logger.Log(LogLevel.Information, $"{nameof(MotorcycleController)} => {nameof(GetAll)}");
        return await _service.GetAll().ConfigureAwait(false);
    }

    [HttpGet($"{nameof(GetById)}/"+"{id}")]
    public async Task<MotorcycleDto?> GetById(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(MotorcycleController)} => {nameof(GetById)} => {id}");
        return await _service.GetById(id).ConfigureAwait(false);;
    }
   
    [HttpPut(nameof(Update))]
    public async Task<bool> Update(MotorcycleDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(MotorcycleController)} => {nameof(Update)}");
        return await _service.Update(dto).ConfigureAwait(false);
    }
    
    [HttpDelete("Delete/{id}")]
    public async Task<bool> Delete(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(MotorcycleController)} => {nameof(Delete)} => {id}");
        return await _service.Delete(id).ConfigureAwait(false);
    }
}