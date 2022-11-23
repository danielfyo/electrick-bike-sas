using ElectricBike.Application.Core.Services.Persons;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBike.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonsController : ControllerBase
{
    private readonly ILogger<PersonsController> _logger;

    public PersonsController(ILogger<PersonsController> logger) => _logger = logger;

    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<PersonDto>> GetAll() =>new List<PersonDto>();

    [HttpPost(nameof(Create))]
    public async Task<PersonDto> Create(PersonDto dto) => new PersonDto();

    [HttpDelete("Delete/{id}")]
    public async Task<bool> Delete(int id) => true;

    [HttpPut(nameof(Update))]
    public async Task<bool> Update(PersonDto dto) => true;

    [HttpGet("{nameof(GetById)}/{id}")]
    public async Task<PersonDto> GetById(int id) => new PersonDto();

    [HttpPost("{nameof(SearchMatching)}")]
    public Task<PersonDto> SearchMatching(PersonDto dto) =>
        throw new NotImplementedException();

    [HttpGet("{nameof(Consult)}/{dto}")]
    public async Task<PersonDto> Consult(PersonDto dto) => new PersonDto();

    [HttpGet("{nameof(GetByIdPerson)}/{id}")]
    public async Task<PersonDto> GetByIdPerson(int id) => new PersonDto();
}