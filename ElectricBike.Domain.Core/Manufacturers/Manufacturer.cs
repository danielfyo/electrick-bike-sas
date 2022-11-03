using System.ComponentModel.DataAnnotations;
using ElectricBike.Domain.Core.Base;

namespace ElectricBike.Domain.Core.Manufacturers;

public class Manufacturer : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = default!;
}