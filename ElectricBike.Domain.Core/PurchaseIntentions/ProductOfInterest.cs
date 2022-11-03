using System.ComponentModel.DataAnnotations;
using ElectricBike.Domain.Core.Base;

namespace ElectricBike.Domain.Core.PurchaseIntentions;

public class ProductOfInterest : EntityBase
{
    [Required]
    public Guid PurchaseIntentionId { get; set; }
    
    [Required]
    /// B = Bicycle, M = Motorcycle
    public char ProductType { get; set; }
    
    [Required] 
    public Guid ProductId { get; set; }
}