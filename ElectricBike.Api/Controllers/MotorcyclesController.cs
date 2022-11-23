using ElectricBike.Application.Core.Services.Motorcycles;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MotorcycleController : ControllerBase
{
    private readonly ILogger<MotorcycleController> _logger;

    public MotorcycleController(ILogger<MotorcycleController> logger) => _logger = logger;

    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<MotorcycleDto>> GetAll() =>new List<MotorcycleDto>();

    [HttpPost(nameof(Create))]
    public async Task<MotorcycleDto> Create(MotorcycleDto dto) => new MotorcycleDto();

    [HttpDelete("Delete/{id}")]
    public async Task<bool> Delete(int id) => true;

    [HttpPut(nameof(Update))]
    public async Task<bool> Update(MotorcycleDto dto) => true;

    [HttpGet("{nameof(GetById)}/{id}")]
    public async Task<MotorcycleDto> GetById(int id) => new MotorcycleDto();

    [HttpPost("{nameof(SearchMatching)}")]
    public Task<MotorcycleDto> SearchMatching(MotorcycleDto dto) =>
        throw new NotImplementedException();

    [HttpGet("{nameof(Consult)}/{dto}")]
    public async Task<MotorcycleDto> Consult(MotorcycleDto dto) => new MotorcycleDto();

    [HttpGet("{nameof(GetByIdMotorcycle)}/{id}")]
    public async Task<MotorcycleDto> GetByIdMotorcycle(int id) => new MotorcycleDto();
}