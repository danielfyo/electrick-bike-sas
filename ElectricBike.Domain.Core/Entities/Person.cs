using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Domain.Core.Entities;

public class Person : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = default!;
    
    [Required]
    [MaxLength(50)]
    public string SureName { get; set; } = default!;
    
    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = default!;

    [MaxLength(15)]
    public string? Cellphone { get; set; }
    
    public DateTimeOffset? DateOfBirth { get; set; }
}