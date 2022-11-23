using AutoMapper;
using ElectricBike.Domain.Core.PurchaseIntentions;

namespace ElectricBike.Application.Core.Services.PurchaseIntentions;

public class PurchaseIntentionService : IPurchaseIntentionService
{
    private readonly IPurchaseIntentionRepository _repo;
    private readonly IMapper _mapper;

    public PurchaseIntentionService(IPurchaseIntentionRepository repoIn, IMapper mapper)
    {
        _repo = repoIn;
        _mapper = mapper;
    }

    public async Task<PurchaseIntentionDto> Create(PurchaseIntentionDto dto) => 
        _mapper.Map<PurchaseIntentionDto>(await _repo.Add(_mapper.Map<PurchaseIntention>(dto)).ConfigureAwait(false));

    public async Task<PurchaseIntentionDto> GetById(int id) => 
        _mapper.Map<PurchaseIntentionDto>(await _repo.GetAll().ConfigureAwait(false));

    public async Task<IEnumerable<PurchaseIntentionDto>> GetAll() =>
        _mapper.Map<IEnumerable<PurchaseIntentionDto>>((await _repo.GetAll().ConfigureAwait(false)));

    public async Task<bool> Update(PurchaseIntentionDto dto) => 
        await _repo.Update(_mapper.Map<PurchaseIntention>(dto)).ConfigureAwait(false);

    public async Task<bool> Delete(int id) => await _repo.Delete(id).ConfigureAwait(false);
}