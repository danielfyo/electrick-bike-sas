namespace ElectricBike.Application.Core.Services.EngineSuppliers;

public interface IEngineSupplierService
{
    Task<EngineSupplierDto> Create(EngineSupplierDto dto);
    Task<EngineSupplierDto> GetById(Guid id);
    Task<IEnumerable<EngineSupplierDto>> GetAll();
    Task<bool> Update(EngineSupplierDto dto);
    Task<bool> Delete(Guid id);
}