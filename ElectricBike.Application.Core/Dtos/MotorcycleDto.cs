using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Application.Core.Dtos;

public class MotorcycleDto : ProductBaseDto
{
    [Required] 
    public decimal BatteryAutonomy { get; set; }
    
    [Required] 
    public Guid EngineSupplierId { get; set; }

    [Required] public virtual EngineSupplierDto EngineSupplier { get; set; } = default!;
}