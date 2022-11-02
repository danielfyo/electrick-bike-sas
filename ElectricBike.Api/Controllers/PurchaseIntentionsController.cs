using ElectricBike.Application.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseIntentionsController : ControllerBase
{
    private readonly ILogger<PurchaseIntentionsController> _logger;

    public PurchaseIntentionsController(ILogger<PurchaseIntentionsController> logger) => _logger = logger;

    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<PurchaseIntentionDto>> GetAll() =>new List<PurchaseIntentionDto>();

    [HttpPost(nameof(Create))]
    public async Task<PurchaseIntentionDto> Create(PurchaseIntentionDto dto) => new PurchaseIntentionDto();

    [HttpDelete("Delete/{id}")]
    public async Task<bool> Delete(int id) => true;

    [HttpPut(nameof(Update))]
    public async Task<bool> Update(PurchaseIntentionDto dto) => true;

    [HttpGet("{nameof(GetById)}/{id}")]
    public async Task<PurchaseIntentionDto> GetById(int id) => new PurchaseIntentionDto();

    [HttpPost("{nameof(SearchMatching)}")]
    public Task<PurchaseIntentionDto> SearchMatching(PurchaseIntentionDto dto) =>
        throw new NotImplementedException();

    [HttpGet("{nameof(Consult)}/{dto}")]
    public async Task<PurchaseIntentionDto> Consult(PurchaseIntentionDto dto) => new PurchaseIntentionDto();

    [HttpGet("{nameof(GetByIdPurchaseIntention)}/{id}")]
    public async Task<PurchaseIntentionDto> GetByIdPurchaseIntention(int id) => new PurchaseIntentionDto();
}