namespace ElectricBike.Infrastructure.Cross.ApiClient;

public class ApiOptions
{
    public string BaseUrl { get; set; } = default!;
    
    public string AllowedContentType { get; set; } = "application/json";

    public void CopyFrom(ApiOptions options)
    {
        BaseUrl = options.BaseUrl;
        AllowedContentType = options.AllowedContentType;
    }
}