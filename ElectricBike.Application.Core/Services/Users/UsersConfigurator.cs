using ElectricBike.Infrastructure.Data.Core.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ElectricBike.Application.Core.Services.Users;

public static class UserConfigurator
{
    public static void ConfigureUserService(this IServiceCollection services)
    {
        services.TryAddTransient<IUserService, UserService>();
        services.ConfigureUserRepository();
    }
}