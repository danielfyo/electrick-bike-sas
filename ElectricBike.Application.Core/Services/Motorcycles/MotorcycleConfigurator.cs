using ElectricBike.Infrastructure.Data.Core.Manufacturers;
using ElectricBike.Infrastructure.Data.Core.Motorcycles;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Application.Core.Services.Motorcycles;

public static class MotorcycleConfigurator
{
    public static void ConfigureMotorcycleService(this IServiceCollection services)
    {
        services.AddScoped<IMotorcycleService, MotorcycleService>();
        services.ConfigureMotorcycleRepository();
        services.ConfigureManufacturerRepository();
    }
}