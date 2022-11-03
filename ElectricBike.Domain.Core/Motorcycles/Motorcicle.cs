using System.ComponentModel.DataAnnotations;
using ElectricBike.Domain.Core.Base;
using ElectricBike.Domain.Core.EngineSuppliers;

namespace ElectricBike.Domain.Core.Motorcycles;

public class Motorcycle : ProductBase
{
    [Required] 
    public decimal BatteryAutonomy { get; set; }
    
    [Required] 
    public Guid EngineSupplierId { get; set; }

    [Required] public virtual EngineSupplier EngineSupplier { get; set; } = default!;
}