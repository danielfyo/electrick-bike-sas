using ElectricBike.Application.Core.Services.Dto;
using ElectricBike.Application.Core.Services.EngineSuppliers;

namespace ElectricBike.Application.Core.Services.Motorcycles
{

    public class MotorcycleDto : ProductBaseDto
    {
        [Required]
        public decimal BatteryAutonomy { get; set; }

        [Required]
        public Guid EngineSupplierId { get; set; }

        [Required]
        public virtual EngineSupplierDto EngineSupplier { get; set; } = default!;
        public string? Line { get; set; }
    }
}