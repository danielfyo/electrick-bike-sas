using ElectricBike.Application.Core.Dtos;

namespace ElectricBike.Application.Core.Services.Bicycles;

public interface IBicycleService
{
    Task<BicycleDto> Create(BicycleDto dto);
    Task<BicycleDto> GetById(int id);
    Task<IEnumerable<BicycleDto>> GetAll();
    Task<bool> Update(BicycleDto dto);
    Task<bool> Delete(int id);
}