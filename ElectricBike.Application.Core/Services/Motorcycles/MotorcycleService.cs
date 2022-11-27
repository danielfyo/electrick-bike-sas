using AutoMapper;
using ElectricBike.Domain.Core.EngineSuppliers;
using ElectricBike.Domain.Core.Manufacturers;
using ElectricBike.Domain.Core.Motorcycles;

namespace ElectricBike.Application.Core.Services.Motorcycles;

public class MotorcycleService : IMotorcycleService
{
    private readonly IMotorcycleRepository _repo;
    private readonly IManufacturerRepository _manufacturerRepo;
    private readonly IEngineSupplierRepository _engineSupplierRepo;
    private readonly IMapper _mapper;

    public MotorcycleService(IMotorcycleRepository repoIn, IMapper mapper, IManufacturerRepository manufacturerRepo, 
        IEngineSupplierRepository engineSupplierRepo)
    {
        _repo = repoIn;
        _mapper = mapper;
        _manufacturerRepo = manufacturerRepo;
        _engineSupplierRepo = engineSupplierRepo;
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

        motorcycle.EngineSupplier = await _engineSupplierRepo
            .GetById(motorcycle.EngineSupplierId).ConfigureAwait(false) ?? new ();
        
        return _mapper.Map<MotorcycleDto>(motorcycle);
    }

    public async Task<IEnumerable<MotorcycleDto>> GetAll()
    {
        var motorcycles = await _repo.GetAll().ConfigureAwait(false);
        foreach (var motorcycle in motorcycles)
        {
            motorcycle.EngineSupplier = await _engineSupplierRepo
                .GetById(motorcycle.EngineSupplierId).ConfigureAwait(false) ?? new ();
            
            motorcycle.Manufacturer = await _manufacturerRepo
                .GetById(motorcycle.ManufacturerId).ConfigureAwait(false) ?? new();
        }
        return _mapper.Map<IEnumerable<MotorcycleDto>>(motorcycles);
    }

    public async Task<bool> Update(MotorcycleDto dto) => 
        await _repo.Update(_mapper.Map<Motorcycle>(dto)).ConfigureAwait(false);

    public async Task<bool> Delete(Guid id) => await _repo.Delete(id).ConfigureAwait(false);
}