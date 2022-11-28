using ElectricBike.Application.Core.Services.Dto;

namespace ElectricBike.Infrastructure.Cross.ApiClient;

public interface IRestHttpClient
{
    Task<TDto?> Create<TDto>(TDto dto) where TDto : DtoBase;
    Task<TDto?> GetById<TDto>(Guid id) where TDto : DtoBase;
    Task<IEnumerable<TDto>?> GetAll<TDto>() where TDto : DtoBase;
    Task<bool> Put<TDto>(TDto dto) where TDto : DtoBase;
    Task<bool> Delete<TDto>(Guid id) where TDto : DtoBase;
}