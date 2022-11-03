using ElectricBike.Domain.Core.Bicycles;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Context.Base;

namespace ElectricBike.Infrastructure.Data.Core.Bicycles;

public class BicycleRepository : BaseRepository<Bicycle>, IBicycleRepository
{
    public BicycleRepository(IDbContextBase unitOfWork) : base(unitOfWork) { }
}