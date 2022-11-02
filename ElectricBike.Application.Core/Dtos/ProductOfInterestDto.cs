using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Application.Core.Dtos;

public class ProductOfInterestDto : DtoBase
{
    [Required]
    public Guid PurchaseIntentionId { get; set; }
    
    [Required]
    /// B = Bicycle, M = Motorcycle
    public char ProductType { get; set; }
    
    [Required] 
    public Guid ProductId { get; set; }
}