namespace ElectricBike.Application.Core.Services.Manufacturers;

public interface IManufacturerService
{
    Task<ManufacturerDto> Create(ManufacturerDto dto);
    Task<ManufacturerDto> GetById(Guid id);
    Task<IEnumerable<ManufacturerDto>> GetAll();
    Task<bool> Update(ManufacturerDto dto);
    Task<bool> Delete(Guid id);
}