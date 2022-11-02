using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Domain.Core.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}