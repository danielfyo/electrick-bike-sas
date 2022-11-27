using ElectricBike.Domain.Core.PurchaseIntentions;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Context.Core;

namespace ElectricBike.Infrastructure.Data.Core.PurchaseIntentions;

public class ProductOfInterestRepository : BaseRepository<ProductOfInterest>, IProductOfInterestRepository
{
    public ProductOfInterestRepository(ICoreDbContext unitOfWork) : base(unitOfWork) { }
}