using ElectricBike.Application.Core.Services.Bicycles;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BicycleController : ControllerBase
{
    private readonly ILogger<BicycleController> _logger;
    private readonly IBicycleService _service;

    public BicycleController(ILogger<BicycleController> logger, IBicycleService service)
    {
        _logger = logger;
        _service = service;
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
        return await _service.GetAll().ConfigureAwait(false);
    }

    [HttpGet("{nameof(GetById)}/{id}")]
    public async Task<BicycleDto> GetById(int id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(BicycleController)} => {nameof(GetById)} => {id}");
        return await _service.GetById(id).ConfigureAwait(false);
    }
   
    [HttpPut(nameof(Update))]
    public async Task<bool> Update(BicycleDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(BicycleController)} => {nameof(Update)}");
        return await _service.Update(dto).ConfigureAwait(false);
    }
    
    [HttpDelete("Delete/{id}")]
    public async Task<bool> Delete(int id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(BicycleController)} => {nameof(Delete)} => {id}");
        return await _service.Delete(id).ConfigureAwait(false);
    }
}