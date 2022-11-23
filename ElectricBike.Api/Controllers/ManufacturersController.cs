using ElectricBike.Application.Core.Services.Manufacturers;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ManufacturerController : ControllerBase
{
    private readonly ILogger<ManufacturerController> _logger;

    public ManufacturerController(ILogger<ManufacturerController> logger) => _logger = logger;

    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<ManufacturerDto>> GetAll() =>new List<ManufacturerDto>();

    [HttpPost(nameof(Create))]
    public async Task<ManufacturerDto> Create(ManufacturerDto dto) => new ManufacturerDto();

    [HttpDelete("Delete/{id}")]
    public async Task<bool> Delete(int id) => true;

    [HttpPut(nameof(Update))]
    public async Task<bool> Update(ManufacturerDto dto) => true;

    [HttpGet("{nameof(GetById)}/{id}")]
    public async Task<ManufacturerDto> GetById(int id) => new ManufacturerDto();

    [HttpPost("{nameof(SearchMatching)}")]
    public Task<ManufacturerDto> SearchMatching(ManufacturerDto dto) =>
        throw new NotImplementedException();

    [HttpGet("{nameof(Consult)}/{dto}")]
    public async Task<ManufacturerDto> Consult(ManufacturerDto dto) => new ManufacturerDto();

    [HttpGet("{nameof(GetByIdManufacturer)}/{id}")]
    public async Task<ManufacturerDto> GetByIdManufacturer(int id) => new ManufacturerDto();
}