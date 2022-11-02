using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Domain.Core.Entities;

public class EngineSupplier : EntityBase
{
    [MaxLength(50)] 
    public string Name { get; set; } = default!;
    
    [MaxLength(200)]
    public string? Address { get; set; }
    
    [MaxLength(15)]
    public string? PhoneNumber { get; set; }
}