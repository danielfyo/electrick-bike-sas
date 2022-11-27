using ElectricBike.Application.Core.Automapper;
using ElectricBike.Application.Core.Services.Bicycles;
using ElectricBike.Application.Core.Services.EngineSuppliers;
using ElectricBike.Application.Core.Services.Manufacturers;
using ElectricBike.Application.Core.Services.Motorcycles;
using ElectricBike.Application.Core.Services.Persons;
using ElectricBike.Application.Core.Services.PurchaseIntentions;
using ElectricBike.Application.Core.Services.Users;
using ElectricBike.Infrastructure.Data.Core.Context;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Application.Core;

public static class ApplicationConfigurator
{
    public static void ConfigureApplication(this IServiceCollection services, string dbConnectionString)
    {
        services.ConfigureCoreDbContext(dbConnectionString);
        
        services.ConfigureMapper();

        services.ConfigureBicycleService();
        services.ConfigureUserService();
        services.ConfigurePurchaseIntentionService();
        services.ConfigurePersonService();
        services.ConfigureMotorcycleService();
        services.ConfigureManufacturerService();
        services.ConfigureEngineSupplierService();
    }
}