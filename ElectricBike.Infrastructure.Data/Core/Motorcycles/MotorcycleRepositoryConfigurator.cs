using ElectricBike.Domain.Core.Motorcycles;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Infrastructure.Data.Core.Motorcycles;

public static class MotorcycleRepositoryConfigurator
{
    public static void ConfigureMotorcycleRepository(this IServiceCollection services) =>
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
}