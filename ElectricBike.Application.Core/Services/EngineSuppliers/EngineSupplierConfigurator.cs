using ElectricBike.Infrastructure.Data.Core.EngineSuppliers;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Application.Core.Services.EngineSuppliers;

public static class EngineSupplierConfigurator
{
    public static void ConfigureEngineSupplierService(this IServiceCollection services)
    {
        services.AddScoped<IEngineSupplierService, EngineSupplierService>();
        services.ConfigureEngineSupplierRepository();
    }
}