using ElectricBike.Infrastructure.Data.Core.PurchaseIntentions;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Application.Core.Services.PurchaseIntentions;

public static class PurchaseIntentionConfigurator
{
    public static void ConfigurePurchaseIntentionService(this IServiceCollection services)
    {
        services.AddScoped<IPurchaseIntentionService, PurchaseIntentionService>();
        services.ConfigurePurchaseIntentionRepository();
    }
}