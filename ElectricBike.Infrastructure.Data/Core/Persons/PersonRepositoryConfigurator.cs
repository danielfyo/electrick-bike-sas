using ElectricBike.Domain.Core.Persons;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricBike.Infrastructure.Data.Core.Persons;

public static class PersonRepositoryConfigurator
{
    public static void ConfigurePersonRepository(this IServiceCollection services) =>
        services.AddScoped<IPersonRepository, PersonRepository>();
}