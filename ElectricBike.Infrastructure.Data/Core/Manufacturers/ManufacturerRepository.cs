using ElectricBike.Domain.Core.Manufacturers;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Context.Core;

namespace ElectricBike.Infrastructure.Data.Core.Manufacturers;

public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
{
    public ManufacturerRepository(ICoreDbContext unitOfWork) : base(unitOfWork) { }
}