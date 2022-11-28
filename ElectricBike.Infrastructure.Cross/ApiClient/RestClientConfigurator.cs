using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ElectricBike.Infrastructure.Cross.ApiClient;

public static class BicycleHttpClientConfigurator
{
    public static void ConfigureRestClient(this IServiceCollection services, ApiOptions options)
    {
        
        services.Configure<ApiOptions>(x=> x.CopyFrom(options));
        services.AddHttpClient<IRestHttpClient, RestHttpClient>();
    }
}