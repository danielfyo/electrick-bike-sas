using AutoMapper;
using ElectricBike.Application.Core.Dtos;
using ElectricBike.Domain.Core.Manufacturers;

namespace ElectricBike.Application.Core.Services.Manufacturers;

public class ManufacturerService : IManufacturerService
{
    private readonly IManufacturerRepository _repo;
    private readonly IMapper _mapper;

    public ManufacturerService(IManufacturerRepository repoIn, IMapper mapper)
    {
        _repo = repoIn;
        _mapper = mapper;
    }

    public async Task<ManufacturerDto> Create(ManufacturerDto dto) => 
        _mapper.Map<ManufacturerDto>(await _repo.Add(_mapper.Map<Manufacturer>(dto)).ConfigureAwait(false));

    public async Task<ManufacturerDto> GetById(int id) => 
        _mapper.Map<ManufacturerDto>(await _repo.GetAll().ConfigureAwait(false));

    public async Task<IEnumerable<ManufacturerDto>> GetAll() =>
        _mapper.Map<IEnumerable<ManufacturerDto>>((await _repo.GetAll().ConfigureAwait(false)));

    public async Task<bool> Update(ManufacturerDto dto) => 
        await _repo.Update(_mapper.Map<Manufacturer>(dto)).ConfigureAwait(false);

    public async Task<bool> Delete(int id) => await _repo.Delete(id).ConfigureAwait(false);
}