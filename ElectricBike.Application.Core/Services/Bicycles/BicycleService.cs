using AutoMapper;
using ElectricBike.Domain.Core.Bicycles;

namespace ElectricBike.Application.Core.Services.Bicycles;

public class BicycleService : IBicycleService
{
    private readonly IBicycleRepository _repo;
    private readonly IMapper _mapper;

    public BicycleService(IBicycleRepository repoIn, IMapper mapper)
    {
        _repo = repoIn;
        _mapper = mapper;
    }

    public async Task<BicycleDto> Create(BicycleDto dto) => 
        _mapper.Map<BicycleDto>(await _repo.Add(_mapper.Map<Bicycle>(dto)).ConfigureAwait(false));

    public async Task<BicycleDto> GetById(int id) => 
        _mapper.Map<BicycleDto>(await _repo.GetAll().ConfigureAwait(false));

    public async Task<IEnumerable<BicycleDto>> GetAll() =>
        _mapper.Map<IEnumerable<BicycleDto>>((await _repo.GetAll().ConfigureAwait(false)));

    public async Task<bool> Update(BicycleDto dto) => 
        await _repo.Update(_mapper.Map<Bicycle>(dto)).ConfigureAwait(false);

    public async Task<bool> Delete(int id) => await _repo.Delete(id).ConfigureAwait(false);
}