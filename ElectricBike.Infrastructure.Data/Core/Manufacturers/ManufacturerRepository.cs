using ElectricBike.Domain.Core.Manufacturers;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Core.Context;

namespace ElectricBike.Infrastructure.Data.Core.Manufacturers;

public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
{
    public ManufacturerRepository(ICoreDbContext unitOfWork) : base(unitOfWork) { }
}