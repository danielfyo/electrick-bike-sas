using ElectricBike.Infrastructure.Data.Core.Manufacturers;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Application.Core.Services.Manufacturers;

public static class ManufacturerConfigurator
{
    public static void ConfigureManufacturerService(this IServiceCollection services)
    {
        services.AddScoped<IManufacturerService, ManufacturerService>();
        services.ConfigureManufacturerRepository();
    }
}