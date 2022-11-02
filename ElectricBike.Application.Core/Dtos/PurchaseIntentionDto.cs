using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Application.Core.Dtos;

public class PurchaseIntentionDto : DtoBase
{
    [Required]
    public DateTimeOffset Date { get; set; }
    
    [Required] 
    public Guid UserId { get; set; }

    [Required] 
    public UserDto User { get; set; } = default!;
}