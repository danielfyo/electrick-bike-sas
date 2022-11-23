using System.ComponentModel.DataAnnotations;
using ElectricBike.Application.Core.Services.Dto;
using ElectricBike.Application.Core.Services.Persons;

namespace ElectricBike.Application.Core.Services.Users;

public class UserDto : DtoBase
{
    [Required]
    [MaxLength(20)]
    public string Username { get; set; } = default!;
    
    [Required]
    [MaxLength(8)]
    public string Password { get; set; } = default!;
    
    [Required]
    public Guid PersonId { get; set; } = default!;

    public virtual PersonDto Person { get; set; } = default!;
}