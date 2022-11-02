using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Application.Core.Dtos;

public class EngineSupplierDto : DtoBase
{
    [MaxLength(50)] 
    public string Name { get; set; } = default!;
    
    [MaxLength(200)]
    public string? Address { get; set; }
    
    [MaxLength(15)]
    public string? PhoneNumber { get; set; }
}