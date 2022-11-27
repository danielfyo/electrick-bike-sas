namespace ElectricBike.Application.Core.Services.Motorcycles;

public interface IMotorcycleService
{
    Task<MotorcycleDto> Create(MotorcycleDto dto);
    Task<MotorcycleDto> GetById(Guid id);
    Task<IEnumerable<MotorcycleDto>> GetAll();
    Task<bool> Update(MotorcycleDto dto);
    Task<bool> Delete(Guid id);
}