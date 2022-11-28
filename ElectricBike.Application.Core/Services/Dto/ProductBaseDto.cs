using System.ComponentModel.DataAnnotations;
using ElectricBike.Application.Core.Services.Manufacturers;
using ElectricBike.Infrastructure.Data.Base;

namespace ElectricBike.Application.Core.Services.Dto;

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