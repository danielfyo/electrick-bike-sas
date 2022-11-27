using ElectricBike.Domain.Core.PurchaseIntentions;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Infrastructure.Data.Core.PurchaseIntentions;

public static class PurchaseIntentionRepositoryConfigurator
{
    public static void ConfigurePurchaseIntentionRepository(this IServiceCollection services)
    {
        services.AddScoped<IPurchaseIntentionRepository, PurchaseIntentionRepository>();
        services.AddScoped<IProductOfInterestRepository, ProductOfInterestRepository>();
    }
}