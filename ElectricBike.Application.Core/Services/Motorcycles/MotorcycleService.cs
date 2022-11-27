using AutoMapper;
using ElectricBike.Domain.Core.Manufacturers;
using ElectricBike.Domain.Core.Motorcycles;

namespace ElectricBike.Application.Core.Services.Motorcycles;

public class MotorcycleService : IMotorcycleService
{
    private readonly IMotorcycleRepository _repo;
    private readonly IManufacturerRepository _manufacturerRepo;
    private readonly IMapper _mapper;

    public MotorcycleService(IMotorcycleRepository repoIn, IMapper mapper, IManufacturerRepository manufacturerRepo)
    {
        _repo = repoIn;
        _mapper = mapper;
        _manufacturerRepo = manufacturerRepo;
    }

    public async Task<MotorcycleDto> Create(MotorcycleDto dto) => 
        _mapper.Map<MotorcycleDto>(await _repo.Add(_mapper.Map<Motorcycle>(dto)).ConfigureAwait(false));

    public async Task<MotorcycleDto?> GetById(Guid id)
    {
        var motorcycle = await _repo.GetById(id).ConfigureAwait(false);
        if (motorcycle == null)
            return null;
        
        motorcycle.Manufacturer = await _manufacturerRepo
            .GetById(motorcycle.ManufacturerId).ConfigureAwait(false) ?? new ();
        return _mapper.Map<MotorcycleDto>(motorcycle);
    }

    public async Task<IEnumerable<MotorcycleDto>> GetAll() =>
        _mapper.Map<IEnumerable<MotorcycleDto>>((await _repo.GetAll().ConfigureAwait(false)));

    public async Task<bool> Update(MotorcycleDto dto) => 
        await _repo.Update(_mapper.Map<Motorcycle>(dto)).ConfigureAwait(false);

    public async Task<bool> Delete(Guid id) => await _repo.Delete(id).ConfigureAwait(false);
}