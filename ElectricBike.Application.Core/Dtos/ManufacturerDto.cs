using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Application.Core.Dtos;

public class ManufacturerDto : DtoBase
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = default!;
}