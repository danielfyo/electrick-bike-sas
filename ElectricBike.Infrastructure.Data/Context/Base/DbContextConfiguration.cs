using ElectricBike.Infrastructure.Data.Context.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Infrastructure.Data.Context.Base
{
    public static class DbContextConfiguration
    {
        public static void ConfigureDataBase(this IServiceCollection services, string sqlConnection) => 
            services.ConfigureCoreDbContext(sqlConnection);
    }
}
