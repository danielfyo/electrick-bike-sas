using ElectricBike.Domain.Core.Motorcycles;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Context.Base;

namespace ElectricBike.Infrastructure.Data.Core.Motorcycles;

public class MotorcycleRepository : BaseRepository<Motorcycle>, IMotorcycleRepository
{
    public MotorcycleRepository(IDbContextBase unitOfWork) : base(unitOfWork) { }
}