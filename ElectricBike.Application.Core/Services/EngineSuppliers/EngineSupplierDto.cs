using System.ComponentModel.DataAnnotations;
using ElectricBike.Application.Core.Services.Dto;

namespace ElectricBike.Application.Core.Services.EngineSuppliers;

public class EngineSupplierDto : DtoBase
{
    [MaxLength(50)] 
    public string Name { get; set; } = default!;
    
    [MaxLength(200)]
    public string? Address { get; set; }
    
    [MaxLength(15)]
    public string? PhoneNumber { get; set; }
}