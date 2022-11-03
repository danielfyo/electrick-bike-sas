using ElectricBike.Domain.Core.EngineSuppliers;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Context.Base;

namespace ElectricBike.Infrastructure.Data.Core.EngineSuppliers;

public class EngineSupplierRepository : BaseRepository<EngineSupplier>, IEngineSupplierRepository
{
    public EngineSupplierRepository(IDbContextBase unitOfWork) : base(unitOfWork) { }
}