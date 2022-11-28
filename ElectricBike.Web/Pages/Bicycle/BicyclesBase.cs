using ElectricBike.Application.Core.Services.Bicycles;
using ElectricBike.Application.Core.Services.Manufacturers;
using ElectricBike.Web.Pages.Base;

namespace ElectricBike.Web.Pages.Bicycle;

public class BicyclesBase : CustomComponentBase<BicycleDto>
{
    protected override string Title { get; set; } = "Bicicletas";
    protected override string Description { get; set; } = "Creación, edición, eliminación, consulta";
    
    protected List<ManufacturerDto> Manufacturers = new ();
    
    protected override async Task OnInitializedAsync()
    {
        ToggleLoading(true);
        Manufacturers = (await RestHttpClient.GetAll<ManufacturerDto>() ?? Array.Empty<ManufacturerDto>()).ToList();
        ToggleLoading(false);
        await base.OnInitializedAsync();
    }
    
    protected void OnSelectedItemChangedHandler(ManufacturerDto value)
    {
        NewItem.ManufacturerId = value.Id;
        NewItem.Manufacturer = value;
    }
    
    protected override async Task SaveEdit(Guid id)
    {
        ToggleLoading(true);
        var index = Items.FindIndex(item => item.Id == id);
        EditCache[id.ToString()].data.Manufacturer = NewItem.Manufacturer;
        EditCache[id.ToString()].data.ManufacturerId = NewItem.ManufacturerId;

        Items[index] = EditCache[id.ToString()].data;
        
        await base.SaveEdit(id);
        ToggleLoading(false);
    }
}