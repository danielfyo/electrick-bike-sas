using AutoMapper;
using ElectricBike.Domain.Core.PurchaseIntentions;

namespace ElectricBike.Application.Core.Services.PurchaseIntentions;

public class PurchaseIntentionService : IPurchaseIntentionService
{
    private readonly IPurchaseIntentionRepository _repo;
    private readonly IProductOfInterestRepository _productOfInterestRepository;
    private readonly IMapper _mapper;

    public PurchaseIntentionService(IPurchaseIntentionRepository repoIn, IMapper mapper, IProductOfInterestRepository productOfInterestRepository)
    {
        _repo = repoIn;
        _mapper = mapper;
        _productOfInterestRepository = productOfInterestRepository;
    }

    public async Task<PurchaseIntentionDto> Create(PurchaseIntentionDto dto) => 
        _mapper.Map<PurchaseIntentionDto>(await _repo.Add(_mapper.Map<PurchaseIntention>(dto)).ConfigureAwait(false));

    public async Task<PurchaseIntentionDto> GetById(Guid id) => 
        _mapper.Map<PurchaseIntentionDto>(await _repo.GetById(id).ConfigureAwait(false));

    public async Task<IEnumerable<PurchaseIntentionDto>> GetAll()
    {
        var intentions = await _repo.GetAll().ConfigureAwait(false);
        foreach (var intention in intentions)
        {
            intention.ProductsOfInterest = (await _productOfInterestRepository.GetAll()).
                Where(x => x.PurchaseIntentionId == intention.Id);
        }
        return _mapper.Map<IEnumerable<PurchaseIntentionDto>>(intentions);
    }

    public async Task<bool> Update(PurchaseIntentionDto dto) => 
        await _repo.Update(_mapper.Map<PurchaseIntention>(dto)).ConfigureAwait(false);

    public async Task<bool> Delete(Guid id) => await _repo.Delete(id).ConfigureAwait(false);
}