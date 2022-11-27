using AutoMapper;
using ElectricBike.Domain.Core.Motorcycles;

namespace ElectricBike.Application.Core.Services.Motorcycles;

public class MotorcycleService : IMotorcycleService
{
    private readonly IMotorcycleRepository _repo;
    private readonly IMapper _mapper;

    public MotorcycleService(IMotorcycleRepository repoIn, IMapper mapper)
    {
        _repo = repoIn;
        _mapper = mapper;
    }

    public async Task<MotorcycleDto> Create(MotorcycleDto dto) => 
        _mapper.Map<MotorcycleDto>(await _repo.Add(_mapper.Map<Motorcycle>(dto)).ConfigureAwait(false));

    public async Task<MotorcycleDto> GetById(Guid id) => 
        _mapper.Map<MotorcycleDto>(await _repo.GetById(id).ConfigureAwait(false));

    public async Task<IEnumerable<MotorcycleDto>> GetAll() =>
        _mapper.Map<IEnumerable<MotorcycleDto>>((await _repo.GetAll().ConfigureAwait(false)));

    public async Task<bool> Update(MotorcycleDto dto) => 
        await _repo.Update(_mapper.Map<Motorcycle>(dto)).ConfigureAwait(false);

    public async Task<bool> Delete(Guid id) => await _repo.Delete(id).ConfigureAwait(false);
}