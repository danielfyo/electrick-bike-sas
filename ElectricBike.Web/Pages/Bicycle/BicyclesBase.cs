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
}