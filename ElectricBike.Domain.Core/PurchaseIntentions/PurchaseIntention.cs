using System.ComponentModel.DataAnnotations;
using ElectricBike.Domain.Core.Base;
using ElectricBike.Domain.Core.Users;

namespace ElectricBike.Domain.Core.PurchaseIntentions;

public class PurchaseIntention : EntityBase
{
    [Required]
    public DateTimeOffset Date { get; set; }
    
    [Required] 
    public Guid UserId { get; set; }

    [Required] 
    public User User { get; set; } = default!;

    public virtual IEnumerable<ProductOfInterest> ProductsOfInterest { get; set; } = default!;
}