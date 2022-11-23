using ElectricBike.Infrastructure.Data.Core.Users;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Application.Core.Services.Users;

public static class UserConfigurator
{
    public static void ConfigureUserService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.ConfigureUserRepository();
    }
}