using ElectricBike.Domain.Core.EngineSuppliers;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Context.Core;

namespace ElectricBike.Infrastructure.Data.Core.EngineSuppliers;

public class EngineSupplierRepository : BaseRepository<EngineSupplier>, IEngineSupplierRepository
{
    public EngineSupplierRepository(ICoreDbContext unitOfWork) : base(unitOfWork) { }
}