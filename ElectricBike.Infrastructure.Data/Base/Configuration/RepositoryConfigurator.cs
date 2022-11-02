using ElectricBike.Infrastructure.Data.Context.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ElectricBike.Infrastructure.Data.Base.Configuration
{
    public static class RepositoryConfigurator
    {
        public static void ConfigureBaseRepository(this IServiceCollection services, DbSettings settings) =>
            services.ConfigureContext(settings);

        public static void ConfigureContext(this IServiceCollection services, DbSettings settings)
        {
            services.Configure<DbSettings>(o => o.CopyFrom(settings));
            services.TryAddScoped<ICoreDbContext, CoreDbContext>();
        }
    }
}