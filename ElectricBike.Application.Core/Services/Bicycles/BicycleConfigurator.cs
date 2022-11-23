using ElectricBike.Infrastructure.Data.Core.Bicycles;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Application.Core.Services.Bicycles;

public static class BicycleConfigurator
{
    public static void ConfigureBicycleService(this IServiceCollection services)
    {
        services.AddScoped<IBicycleService, BicycleService>();
        services.ConfigureBicycleRepository();
    }
}