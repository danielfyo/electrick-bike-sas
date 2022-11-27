using AutoMapper;
using ElectricBike.Domain.Core.EngineSuppliers;

namespace ElectricBike.Application.Core.Services.EngineSuppliers;

public class EngineSupplierService : IEngineSupplierService
{
    private readonly IEngineSupplierRepository _repo;
    private readonly IMapper _mapper;

    public EngineSupplierService(IEngineSupplierRepository repoIn, IMapper mapper)
    {
        _repo = repoIn;
        _mapper = mapper;
    }

    public async Task<EngineSupplierDto> Create(EngineSupplierDto dto) => 
        _mapper.Map<EngineSupplierDto>(await _repo.Add(_mapper.Map<Domain.Core.EngineSuppliers.EngineSupplier>(dto)).ConfigureAwait(false));

    public async Task<EngineSupplierDto> GetById(Guid id) => 
        _mapper.Map<EngineSupplierDto>(await _repo.GetAll().ConfigureAwait(false));

    public async Task<IEnumerable<EngineSupplierDto>> GetAll() =>
        _mapper.Map<IEnumerable<EngineSupplierDto>>((await _repo.GetAll().ConfigureAwait(false)));

    public async Task<bool> Update(EngineSupplierDto dto) => 
        await _repo.Update(_mapper.Map<Domain.Core.EngineSuppliers.EngineSupplier>(dto)).ConfigureAwait(false);

    public async Task<bool> Delete(Guid id) => await _repo.Delete(id).ConfigureAwait(false);
}