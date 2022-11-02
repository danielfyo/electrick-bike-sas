using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Domain.Core.Entities;

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