using ElectricBike.Application.Core.Services.EngineSuppliers;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EngineSupplierController : ControllerBase
{
    private readonly ILogger<EngineSupplierController> _logger;
    private readonly IEngineSupplierService _service;

    public EngineSupplierController(ILogger<EngineSupplierController> logger, IEngineSupplierService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost(nameof(Create))]
    public async Task<EngineSupplierDto> Create(EngineSupplierDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(EngineSupplierController)} => {nameof(Create)}");
        return await _service.Create(dto).ConfigureAwait(false);
    }
    
    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<EngineSupplierDto>> GetAll()
    {
        _logger.Log(LogLevel.Information, $"{nameof(EngineSupplierController)} => {nameof(GetAll)}");
        return await _service.GetAll().ConfigureAwait(false);
    }

    [HttpGet($"{nameof(GetById)}/"+"{id}")]
    public async Task<EngineSupplierDto> GetById(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(EngineSupplierController)} => {nameof(GetById)} => {id}");
        return await _service.GetById(id).ConfigureAwait(false);
    }
   
    [HttpPut(nameof(Update))]
    public async Task<bool> Update(EngineSupplierDto dto)
    {
        _logger.Log(LogLevel.Information, $"{nameof(EngineSupplierController)} => {nameof(Update)}");
        return await _service.Update(dto).ConfigureAwait(false);
    }
    
    [HttpDelete($"{nameof(Delete)}"+"/{id}")]
    public async Task<bool> Delete(Guid id)
    {
        _logger.Log(LogLevel.Information, $"{nameof(EngineSupplierController)} => {nameof(Delete)} => {id}");
        return await _service.Delete(id).ConfigureAwait(false);
    }
}