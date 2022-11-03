using System.ComponentModel.DataAnnotations;
using ElectricBike.Domain.Core.Manufacturers;

namespace ElectricBike.Domain.Core.Base;

public abstract class ProductBase : EntityBase
{
    [Required]
    public double Cost { get; set; } = default!;
    
    [Required]
    public ushort YearOfManufacture { get; set; } = default!;
    
    [Required]
    public Guid ManufacturerId { get; set; } = default!;
    
    public virtual Manufacturer Manufacturer { get; set; } = default!;
}