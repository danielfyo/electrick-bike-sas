using ElectricBike.Application.Core.Services.EngineSuppliers;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EngineSupplierController : ControllerBase
{
    private readonly ILogger<EngineSupplierController> _logger;

    public EngineSupplierController(ILogger<EngineSupplierController> logger) => _logger = logger;

    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<EngineSupplierDto>> GetAll() =>new List<EngineSupplierDto>();

    [HttpPost(nameof(Create))]
    public async Task<EngineSupplierDto> Create(EngineSupplierDto dto) => new EngineSupplierDto();

    [HttpDelete("Delete/{id}")]
    public async Task<bool> Delete(int id) => true;

    [HttpPut(nameof(Update))]
    public async Task<bool> Update(EngineSupplierDto dto) => true;

    [HttpGet("{nameof(GetById)}/{id}")]
    public async Task<EngineSupplierDto> GetById(int id) => new EngineSupplierDto();

    [HttpPost("{nameof(SearchMatching)}")]
    public Task<EngineSupplierDto> SearchMatching(EngineSupplierDto dto) =>
        throw new NotImplementedException();

    [HttpGet("{nameof(Consult)}/{dto}")]
    public async Task<EngineSupplierDto> Consult(EngineSupplierDto dto) => new EngineSupplierDto();

    [HttpGet("{nameof(GetByIdEngineSupplier)}/{id}")]
    public async Task<EngineSupplierDto> GetByIdEngineSupplier(int id) => new EngineSupplierDto();
}