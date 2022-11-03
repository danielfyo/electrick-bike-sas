using ElectricBike.Domain.Core.Users;
using ElectricBike.Infrastructure.Data.Base;
using ElectricBike.Infrastructure.Data.Context.Base;

namespace ElectricBike.Infrastructure.Data.Core.Users;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IDbContextBase unitOfWork) : base(unitOfWork) { }
}