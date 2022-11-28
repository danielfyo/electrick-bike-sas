using ElectricBike.Application.Core.Services.Manufacturers;
using ElectricBike.Web.Pages.Base;

namespace ElectricBike.Web.Pages.Manufacturer;

public class ManufacturersBase : CustomComponentBase<ManufacturerDto>
{
    protected override string Title { get; set; } = "Fabricantes";
    protected override string Description { get; set; } = "Creación, edición, eliminación, consulta";
}