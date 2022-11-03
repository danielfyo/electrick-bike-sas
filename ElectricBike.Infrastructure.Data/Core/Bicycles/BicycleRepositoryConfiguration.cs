using ElectricBike.Domain.Core.Bicycles;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Infrastructure.Data.Core.Bicycles;

public static class BicycleRepositoryConfiguration
{
    public static void ConfigureBicycleRepository(this IServiceCollection services) =>
        services.AddScoped<IBicycleRepository, BicycleRepository>();
}