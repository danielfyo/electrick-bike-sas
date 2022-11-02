using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Application.Core.Dtos
{
    public abstract class DtoBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}