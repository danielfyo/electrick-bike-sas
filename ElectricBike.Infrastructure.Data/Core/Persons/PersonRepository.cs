using ElectricBike.Domain.Core.Persons;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Core.Context;

namespace ElectricBike.Infrastructure.Data.Core.Persons;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(ICoreDbContext unitOfWork) : base(unitOfWork) { }
}