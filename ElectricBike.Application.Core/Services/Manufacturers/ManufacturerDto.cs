using System.ComponentModel.DataAnnotations;
using ElectricBike.Application.Core.Services.Dto;

namespace ElectricBike.Application.Core.Services.Manufacturers;

public class ManufacturerDto : DtoBase
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = default!;
}