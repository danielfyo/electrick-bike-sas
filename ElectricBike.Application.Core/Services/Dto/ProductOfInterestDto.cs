using System.ComponentModel.DataAnnotations;
using ElectricBike.Infrastructure.Data.Base;

namespace ElectricBike.Application.Core.Services.Dto;

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