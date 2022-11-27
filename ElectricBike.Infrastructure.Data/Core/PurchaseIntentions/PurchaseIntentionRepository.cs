using ElectricBike.Domain.Core.PurchaseIntentions;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Core.Context;

namespace ElectricBike.Infrastructure.Data.Core.PurchaseIntentions;

public class PurchaseIntentionRepository : BaseRepository<PurchaseIntention>, IPurchaseIntentionRepository
{
    public PurchaseIntentionRepository(ICoreDbContext unitOfWork) : base(unitOfWork) { }
}