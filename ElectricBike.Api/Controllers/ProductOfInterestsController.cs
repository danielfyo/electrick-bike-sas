using ElectricBike.Application.Core.Services.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductOfInterestsController : ControllerBase
{
    private readonly ILogger<ProductOfInterestsController> _logger;

    public ProductOfInterestsController(ILogger<ProductOfInterestsController> logger) => _logger = logger;

    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<ProductOfInterestDto>> GetAll() =>new List<ProductOfInterestDto>();

    [HttpPost(nameof(Create))]
    public async Task<ProductOfInterestDto> Create(ProductOfInterestDto dto) => new ProductOfInterestDto();

    [HttpDelete("Delete/{id}")]
    public async Task<bool> Delete(int id) => true;

    [HttpPut(nameof(Update))]
    public async Task<bool> Update(ProductOfInterestDto dto) => true;

    [HttpGet("{nameof(GetById)}/{id}")]
    public async Task<ProductOfInterestDto> GetById(int id) => new ProductOfInterestDto();

    [HttpPost("{nameof(SearchMatching)}")]
    public Task<ProductOfInterestDto> SearchMatching(ProductOfInterestDto dto) =>
        throw new NotImplementedException();

    [HttpGet("{nameof(Consult)}/{dto}")]
    public async Task<ProductOfInterestDto> Consult(ProductOfInterestDto dto) => new ProductOfInterestDto();

    [HttpGet("{nameof(GetByIdProductOfInterest)}/{id}")]
    public async Task<ProductOfInterestDto> GetByIdProductOfInterest(int id) => new ProductOfInterestDto();
}