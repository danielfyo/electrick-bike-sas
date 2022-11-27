using ElectricBike.Domain.Core.EngineSuppliers;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Core.Context;

namespace ElectricBike.Infrastructure.Data.Core.EngineSuppliers;

public class EngineSupplierRepository : BaseRepository<EngineSupplier>, IEngineSupplierRepository
{
    public EngineSupplierRepository(ICoreDbContext unitOfWork) : base(unitOfWork) { }
}