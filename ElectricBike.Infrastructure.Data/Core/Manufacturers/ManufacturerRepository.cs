using ElectricBike.Domain.Core.Manufacturers;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Context.Base;

namespace ElectricBike.Infrastructure.Data.Core.Manufacturers;

public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
{
    public ManufacturerRepository(IDbContextBase unitOfWork) : base(unitOfWork) { }
}