using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ElectricBike.Infrastructure.Data.Core.Context
{
    public static class CoreDbContextConfiguration
    {
        public static void ConfigureCoreDbContext(this IServiceCollection services, string stringConnection)
        {
            services.TryAddScoped<ICoreDbContext, CoreDbContext>();
            services.AddDbContextFactory<CoreDbContext>(x => x.UseSqlServer(stringConnection));
        }
    }
}
