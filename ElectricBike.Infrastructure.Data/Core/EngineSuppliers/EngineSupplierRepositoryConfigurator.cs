using ElectricBike.Domain.Core.EngineSuppliers;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Infrastructure.Data.Core.EngineSuppliers;

public static class EngineSupplierRepositoryConfigurator
{
    public static void ConfigureEngineSupplierRepository(this IServiceCollection services) =>
        services.AddScoped<IEngineSupplierRepository, EngineSupplierRepository>();
}