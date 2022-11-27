namespace ElectricBike.Application.Core.Services.Bicycles;

public interface IBicycleService
{
    Task<BicycleDto> Create(BicycleDto dto);
    Task<BicycleDto?> GetById(Guid id);
    Task<IEnumerable<BicycleDto>> GetAll();
    Task<bool> Update(BicycleDto dto);
    Task<bool> Delete(Guid id);
}