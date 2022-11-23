using ElectricBike.Infrastructure.Data.Core.Persons;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Application.Core.Services.Persons;

public static class PersonConfigurator
{
    public static void ConfigurePersonService(this IServiceCollection services)
    {
        services.AddScoped<IPersonService, PersonService>();
        services.ConfigurePersonRepository();
    }
}