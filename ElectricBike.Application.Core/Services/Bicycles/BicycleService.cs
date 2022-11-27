using AutoMapper;
using ElectricBike.Domain.Core.Bicycles;
using ElectricBike.Domain.Core.Manufacturers;

namespace ElectricBike.Application.Core.Services.Bicycles;

public class BicycleService : IBicycleService
{
    private readonly IBicycleRepository _repo;
    private readonly IManufacturerRepository _manufacturerRepo;
    private readonly IMapper _mapper;

    public BicycleService(IBicycleRepository repoIn, IMapper mapper, IManufacturerRepository manufacturerRepo)
    {
        _repo = repoIn;
        _mapper = mapper;
        _manufacturerRepo = manufacturerRepo;
    }

    public async Task<BicycleDto> Create(BicycleDto dto) => 
        _mapper.Map<BicycleDto>(await _repo.Add(_mapper.Map<Bicycle>(dto)).ConfigureAwait(false));

    public async Task<BicycleDto?> GetById(Guid id)
    {
        var bicycle = await _repo.GetById(id).ConfigureAwait(false);
        if (bicycle == null)
            return null;
        bicycle.Manufacturer = await _manufacturerRepo.GetById(bicycle.ManufacturerId) ?? new ();
        return _mapper.Map<BicycleDto>(bicycle);
    }

    public async Task<IEnumerable<BicycleDto>> GetAll()
    {
        var bicycles = await _repo.GetAll().ConfigureAwait(false);
        foreach (var bicycle in bicycles)
        {
            bicycle.Manufacturer = await _manufacturerRepo.GetById(bicycle.ManufacturerId)
                    .ConfigureAwait(false) ?? new();
        }
        return _mapper.Map<IEnumerable<BicycleDto>>(bicycles);
    }

    public async Task<bool> Update(BicycleDto dto) => 
        await _repo.Update(_mapper.Map<Bicycle>(dto)).ConfigureAwait(false);

    public async Task<bool> Delete(Guid id) => await _repo.Delete(id).ConfigureAwait(false);
}