using ElectricBike.Application.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BicycleController : ControllerBase
{
    private readonly ILogger<BicycleController> _logger;

    public BicycleController(ILogger<BicycleController> logger) => _logger = logger;

    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<BicycleDto>> GetAll() =>new List<BicycleDto>();

    [HttpPost(nameof(Create))]
    public async Task<BicycleDto> Create(BicycleDto dto) => new BicycleDto();

    [HttpDelete("Delete/{id}")]
    public async Task<bool> Delete(int id) => true;

    [HttpPut(nameof(Update))]
    public async Task<bool> Update(BicycleDto dto) => true;

    [HttpGet("{nameof(GetById)}/{id}")]
    public async Task<BicycleDto> GetById(int id) => new BicycleDto();

    [HttpPost("{nameof(SearchMatching)}")]
    public Task<BicycleDto> SearchMatching(BicycleDto dto) =>
        throw new NotImplementedException();

    [HttpGet("{nameof(Consult)}/{dto}")]
    public async Task<BicycleDto> Consult(BicycleDto dto) => new BicycleDto();

    [HttpGet("{nameof(GetByIdBicycle)}/{id}")]
    public async Task<BicycleDto> GetByIdBicycle(int id) => new BicycleDto();
}