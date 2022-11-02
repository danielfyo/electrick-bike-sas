using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Application.Core.Dtos;

public class PersonDto : DtoBase
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