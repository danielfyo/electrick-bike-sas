using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Domain.Core.Entities;

public class Motorcycle : ProductBase
{
    [Required] 
    public decimal BatteryAutonomy { get; set; }
    
    [Required] 
    public Guid EngineSupplierId { get; set; }

    [Required] public virtual EngineSupplier EngineSupplier { get; set; } = default!;
}