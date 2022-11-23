using ElectricBike.Domain.Core.Users;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Infrastructure.Data.Core.Users;

public static class UserRepositoryConfigurator
{
    public static void ConfigureUserRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}