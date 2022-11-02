using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Domain.Core.Entities;

public class PurchaseIntention : EntityBase
{
    [Required]
    public DateTimeOffset Date { get; set; }
    
    [Required] 
    public Guid UserId { get; set; }

    [Required] 
    public User User { get; set; } = default!;
}