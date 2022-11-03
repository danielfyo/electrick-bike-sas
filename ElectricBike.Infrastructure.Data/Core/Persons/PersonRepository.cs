using ElectricBike.Domain.Core.Persons;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Context.Base;

namespace ElectricBike.Infrastructure.Data.Core.Persons;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(IDbContextBase unitOfWork) : base(unitOfWork) { }
}