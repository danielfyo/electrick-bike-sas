using ElectricBike.Domain.Core.PurchaseIntentions;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Context.Core;

namespace ElectricBike.Infrastructure.Data.Core.PurchaseIntentions;

public class PurchaseIntentionRepository : BaseRepository<PurchaseIntention>, IPurchaseIntentionRepository
{
    public PurchaseIntentionRepository(ICoreDbContext unitOfWork) : base(unitOfWork) { }
}