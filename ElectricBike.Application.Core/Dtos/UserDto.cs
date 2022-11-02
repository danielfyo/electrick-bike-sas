using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Application.Core.Dtos;

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