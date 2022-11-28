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
}