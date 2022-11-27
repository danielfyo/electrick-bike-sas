using ElectricBike.Application.Core.Services.Bicycles;
using ElectricBike.Application.Core.Services.Manufacturers;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BicycleController : ControllerBase
{
    private readonly ILogger<BicycleController> _logger;
    private readonly IBicycleService _service;
    private readonly IManufacturerService _manufacturerService;

    public BicycleController(ILogger<BicycleController> logger, IBicycleService service, IManufacturerService manufacturerService)
    {
        _logger = logger;
        _service = service;
        _manufacturerService = manufacturerService;
    }

    [HttpPost(nameof(Create))]
    public async Task<BicycleDto> Create(BicycleDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(BicycleController)} => {nameof(Create)}");
        return await _service.Create(dto).ConfigureAwait(false);
    }
    
    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<BicycleDto>> GetAll()
    {
        _logger.Log(LogLevel.Information, $"{nameof(BicycleController)} => {nameof(GetAll)}");
        var allBicycles = (await _service.GetAll().ConfigureAwait(false)).ToArray();

        foreach (var bicycle in allBicycles)
        {
            bicycle.Manufacturer = await _manufacturerService.GetById(bicycle.ManufacturerId);
        }
        return allBicycles;
    }

    [HttpGet($"{nameof(GetById)}/"+"{id}")]
    public async Task<BicycleDto?> GetById(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(BicycleController)} => {nameof(GetById)} => {id}");
        var bicycle = await _service.GetById(id).ConfigureAwait(false);
        if (bicycle == null)
            return null;
        bicycle.Manufacturer = await _manufacturerService.GetById(bicycle.ManufacturerId);
        return bicycle;
    }
   
    [HttpPut(nameof(Update))]
    public async Task<bool> Update(BicycleDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(BicycleController)} => {nameof(Update)}");
        return await _service.Update(dto).ConfigureAwait(false);
    }
    
    [HttpDelete($"{nameof(Delete)}"+"/{id}")]
    public async Task<bool> Delete(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(BicycleController)} => {nameof(Delete)} => {id}");
        return await _service.Delete(id).ConfigureAwait(false);
    }
}