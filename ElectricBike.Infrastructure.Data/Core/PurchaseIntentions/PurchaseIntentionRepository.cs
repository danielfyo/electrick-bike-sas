using ElectricBike.Domain.Core.PurchaseIntentions;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Context.Base;

namespace ElectricBike.Infrastructure.Data.Core.PurchaseIntentions;

public class PurchaseIntentionRepository : BaseRepository<PurchaseIntention>, IPurchaseIntentionRepository
{
    public PurchaseIntentionRepository(IDbContextBase unitOfWork) : base(unitOfWork) { }
}