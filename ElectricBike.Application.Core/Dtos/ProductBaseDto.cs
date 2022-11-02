using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Application.Core.Dtos;

public abstract class ProductBaseDto : DtoBase
{
    [Required]
    public double Cost { get; set; } = default!;
    
    [Required]
    public ushort YearOfManufacture { get; set; } = default!;
    
    [Required]
    public Guid ManufacturerId { get; set; } = default!;
    
    public virtual ManufacturerDto Manufacturer { get; set; } = default!;
}