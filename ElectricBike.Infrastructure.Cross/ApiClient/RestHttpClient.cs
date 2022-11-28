using System.Net.Http.Json;
using System.Text;
using ElectricBike.Application.Core.Services.Dto;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ElectricBike.Infrastructure.Cross.ApiClient;

public class RestHttpClient : IRestHttpClient 
{
    private readonly HttpClient _httpClient;
    private readonly ApiOptions _options;
    
    public RestHttpClient(IOptions<ApiOptions> optionsIn, HttpClient client)
    {
        _options = optionsIn.Value;
        _httpClient = client;
        _httpClient.BaseAddress = new Uri(_options.BaseUrl);
    }

    public async Task<TDto?> Create<TDto>(TDto dto) where TDto : DtoBase
    {
        var json = JsonConvert.SerializeObject(dto);
        var data = new StringContent(json, Encoding.UTF8, _options.AllowedContentType);
        var context = GetTypeName<TDto>();
        var url = $"/{context}/Create";
        var response = await _httpClient.PostAsync(url, data);
        //response.EnsureSuccessStatusCode();
        var flatResponse = await response.Content.ReadAsStringAsync();
        return await response.Content.ReadFromJsonAsync<TDto>();
    }
    
    public async Task<TDto?> GetById<TDto>(Guid id) where TDto : DtoBase
    {
        var url = $"/{typeof(TDto).Name.Replace("Dto", string.Empty)}/{id}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await  response.Content.ReadFromJsonAsync<TDto>();
    }
    
    public async Task<IEnumerable<TDto>?> GetAll<TDto>() where TDto : DtoBase
    {
        var context = GetTypeName<TDto>();
        var url = $"/{context}/GetAll";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await  response.Content.ReadFromJsonAsync<IEnumerable<TDto>>();  
    }
    
    public static string GetTypeName<TDto>() where TDto : DtoBase => 
        typeof(TDto).Name.Replace("Dto", string.Empty);

    public async Task<bool> Put<TDto>(TDto dto) where TDto : DtoBase
    {
        var json = JsonConvert.SerializeObject(dto);
        var data = new StringContent(json, Encoding.UTF8, _options.AllowedContentType);

        var response = await _httpClient.PutAsync($"/{typeof(TDto).Name.Replace("Dto", string.Empty)}/Update", data);
        return await response.Content.ReadFromJsonAsync<bool>();
    }
    
    public async Task<bool> Delete<TDto>(Guid id) where TDto : DtoBase
    {
        var url = $"/{typeof(TDto).Name.Replace("Dto", string.Empty)}/Delete/{id}";
        var response = await _httpClient.DeleteAsync(url);
        return bool.Parse(await response.Content.ReadAsStringAsync());
    }
}
