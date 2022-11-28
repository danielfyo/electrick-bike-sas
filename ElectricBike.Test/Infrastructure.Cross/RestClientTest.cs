using ElectricBike.Application.Core.Services.Bicycles;
using ElectricBike.Application.Core.Services.Dto;
using ElectricBike.Infrastructure.Cross.ApiClient;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Categories;

namespace ElectricBike.Test.Infrastructure.Cross;

public class RestClientTest
{
    [Fact]
    [UnitTest]
    public void Should_retrieve_valid_rest_client()
    {
        var services = new ServiceCollection();
        services.ConfigureRestClient(new ApiOptions
        {
            BaseUrl = "https://localhost:5001"
        });
        var svcProvider = services.BuildServiceProvider();
        var svc = svcProvider.GetRequiredService<IRestHttpClient>();
        Assert.NotNull(svc);
    }
    
    [Fact]
    [UnitTest]
    public void Test()
    {
        var dto = new BicycleDto();
        var type = typeof(BicycleDto).Name;
        var type2 = dto.GetType().Name;
        var name = RestHttpClient.GetTypeName<BicycleDto>();
    }
}
