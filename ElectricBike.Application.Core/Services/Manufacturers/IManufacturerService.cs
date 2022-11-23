namespace ElectricBike.Application.Core.Services.Manufacturers;

public interface IManufacturerService
{
    Task<ManufacturerDto> Create(ManufacturerDto dto);
    Task<ManufacturerDto> GetById(int id);
    Task<IEnumerable<ManufacturerDto>> GetAll();
    Task<bool> Update(ManufacturerDto dto);
    Task<bool> Delete(int id);
}