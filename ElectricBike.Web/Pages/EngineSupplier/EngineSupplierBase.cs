using ElectricBike.Application.Core.Services.EngineSuppliers;
using ElectricBike.Web.Pages.Base;

namespace ElectricBike.Web.Pages.EngineSupplier;

public class EngineSupplierBase : CustomComponentBase<EngineSupplierDto>
{
    protected override string Title { get; set; } = "Proveedores de motores";
    protected override string Description { get; set; } = "Creación, edición, eliminación, consulta";
}