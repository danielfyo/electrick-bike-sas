using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Domain.Core.Entities;

public class Manufacturer : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = default!;
}