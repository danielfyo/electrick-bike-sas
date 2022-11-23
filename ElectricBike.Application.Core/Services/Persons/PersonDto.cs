using System.ComponentModel.DataAnnotations;
using ElectricBike.Application.Core.Services.Dto;

namespace ElectricBike.Application.Core.Services.Persons;

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