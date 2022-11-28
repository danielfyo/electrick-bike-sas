using ElectricBike.Application.Core.Services.Bicycles;
using ElectricBike.Application.Core.Services.Dto;
using ElectricBike.Application.Core.Services.Manufacturers;
using ElectricBike.Web.Pages.Base;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace ElectricBike.Web.Pages.Bicycle;

public class BicycleBase : CustomComponentBase<BicycleDto>
{
    protected bool ModalVisible;
    protected bool Loading;
    protected BicycleDto NewBicycle { get; set; } = new ();
    protected override string Title { get; set; } = "Bicicletas";
    protected override string Description { get; set; } = "Creación, edición, eliminación, Consulta";
    protected IEnumerable<ManufacturerDto>? Manufacturers { get; set; } = new List<ManufacturerDto>();
    
    protected void NewElement()
    {
        NewBicycle = new();
        ModalVisible = true;
    }
    
    protected async Task HandleCancelCreation(MouseEventArgs e)
    {
        ModalVisible = false;
    }
    
    protected void OnFinish(EditContext editContext)
    {
        ModalVisible = false;
    }
    
    protected void ToggleLoading(bool value) => Loading = value;
    
    protected async Task OnFinishFailed(EditContext editContext)
    {
        await ShowErrorMessage("Error creando el registro", "Por favor verifique los datos he intente nuevamente");
    }
    
    protected async Task HandleOk(MouseEventArgs e)
    {
        var response = await RestHttpClient.Create(Form.Model);
        if (response != null)
        {
            EditCache.Add(response.Id.ToString(), (false, response));
            await ShowSuccessMessage("Registro creado con éxito", string.Empty);
        }
        else
            await ShowErrorMessage("Error creando el nuevo registro", string.Empty);

    }

    protected override async Task OnInitializedAsync()
    {
        Manufacturers = await RestHttpClient.GetAll<ManufacturerDto>();
        await base.OnInitializedAsync();
    }
}