using System.ComponentModel.DataAnnotations;

namespace ElectricBike.Application.Core.Services.Dto
{
    public abstract class DtoBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}