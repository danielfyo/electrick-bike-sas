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
    private readonly IManufacturerService _manufacturerService;

    public MotorcycleController(ILogger<MotorcycleController> logger, IMotorcycleService service, IManufacturerService manufacturerService)
    {
        _logger = logger;
        _service = service;
        _manufacturerService = manufacturerService;
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
        var allMotorcycles = (await _service.GetAll().ConfigureAwait(false)).ToArray();
        foreach (var motorcycle in allMotorcycles)
        {
            motorcycle.Manufacturer = await _manufacturerService.GetById(motorcycle.ManufacturerId);
        }
        return allMotorcycles;
    }

    [HttpGet($"{nameof(GetById)}/"+"{id}")]
    public async Task<MotorcycleDto?> GetById(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(MotorcycleController)} => {nameof(GetById)} => {id}");
        var motorcycle = await _service.GetById(id).ConfigureAwait(false);
        if (motorcycle == null)
            return null;
        motorcycle.Manufacturer = await _manufacturerService.GetById(motorcycle.ManufacturerId);
        return motorcycle;
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