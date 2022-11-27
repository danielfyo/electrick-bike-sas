using System.ComponentModel.DataAnnotations;
using ElectricBike.Application.Core.Services.Dto;
using ElectricBike.Application.Core.Services.Users;

namespace ElectricBike.Application.Core.Services.PurchaseIntentions;

public class PurchaseIntentionDto : DtoBase
{
    [Required]
    public DateTimeOffset Date { get; set; }
    
    [Required] 
    public Guid UserId { get; set; }

    [Required] 
    public UserDto User { get; set; } = default!;
    
    public IEnumerable<ProductOfInterestDto> ProductsOfInterest { get; set; }
}