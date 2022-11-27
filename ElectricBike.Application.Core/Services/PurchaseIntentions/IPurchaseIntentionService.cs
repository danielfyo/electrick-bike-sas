namespace ElectricBike.Application.Core.Services.PurchaseIntentions;

public interface IPurchaseIntentionService
{
    Task<PurchaseIntentionDto> Create(PurchaseIntentionDto dto);
    Task<PurchaseIntentionDto> GetById(Guid id);
    Task<IEnumerable<PurchaseIntentionDto>> GetAll();
    Task<bool> Update(PurchaseIntentionDto dto);
    Task<bool> Delete(Guid id);
}