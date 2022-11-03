using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Domain.Core.Base
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}