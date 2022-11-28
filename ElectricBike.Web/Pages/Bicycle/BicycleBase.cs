using ElectricBike.Application.Core.Services.Bicycles;
using ElectricBike.Application.Core.Services.Manufacturers;
using ElectricBike.Web.Pages.Base;

namespace ElectricBike.Web.Pages.Bicycle;

public class BicycleBase : CustomComponentBase<BicycleDto>
{
    protected override string Title { get; set; } = "Bicicletas";
    protected override string Description { get; set; } = "Creación, edición, eliminación, Consulta";
    
    protected List<ManufacturerDto> Manufacturers = new ();
    
    protected override async Task OnInitializedAsync()
    {
        ToggleLoading(true);
        await LoadAllItems();
        Manufacturers = (await RestHttpClient.GetAll<ManufacturerDto>() ?? Array.Empty<ManufacturerDto>()).ToList();
        ToggleLoading(false);
    }
    
    protected void OnSelectedItemChangedHandler(ManufacturerDto value)
    {
        NewItem.ManufacturerId = value.Id;
        NewItem.Manufacturer = value;
    }
}