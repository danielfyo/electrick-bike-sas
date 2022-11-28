using ElectricBike.Application.Core.Services.EngineSuppliers;
using ElectricBike.Application.Core.Services.Manufacturers;
using ElectricBike.Application.Core.Services.Motorcycles;
using ElectricBike.Web.Pages.Base;

namespace ElectricBike.Web.Pages.Motorcycle;

public class MotorcyclesBase : CustomComponentBase<MotorcycleDto>
{
    protected override string Title { get; set; } = "Motocicletas";
    protected override string Description { get; set; } = "Creación, edición, eliminación, consulta";
    
    protected List<ManufacturerDto> Manufacturers = new ();
    protected List<EngineSupplierDto> EngineSuppliers = new ();
    
    protected override async Task OnInitializedAsync()
    {
        ToggleLoading(true);
        Manufacturers = (await RestHttpClient.GetAll<ManufacturerDto>() ?? Array.Empty<ManufacturerDto>()).ToList();
        EngineSuppliers = (await RestHttpClient.GetAll<EngineSupplierDto>() ?? Array.Empty<EngineSupplierDto>()).ToList();
        ToggleLoading(false);
        await base.OnInitializedAsync();
    }
    
    protected void OnSelectedItemChangedHandler(ManufacturerDto value)
    {
        NewItem.ManufacturerId = value.Id;
        NewItem.Manufacturer = value;
    }
    
    protected void OnSelectedItemChangedHandler(EngineSupplierDto value)
    {
        NewItem.EngineSupplierId = value.Id;
        NewItem.EngineSupplier = value;
    }
    
    protected override async Task SaveEdit(Guid id)
    {
        ToggleLoading(true);
        var index = Items.FindIndex(item => item.Id == id);
        EditCache[id.ToString()].data.Manufacturer = NewItem.Manufacturer;
        EditCache[id.ToString()].data.ManufacturerId = NewItem.ManufacturerId;
        
        EditCache[id.ToString()].data.EngineSupplier = NewItem.EngineSupplier;
        EditCache[id.ToString()].data.EngineSupplierId = NewItem.EngineSupplierId;

        Items[index] = EditCache[id.ToString()].data;
        
        await base.SaveEdit(id);
        ToggleLoading(false);
    }
}