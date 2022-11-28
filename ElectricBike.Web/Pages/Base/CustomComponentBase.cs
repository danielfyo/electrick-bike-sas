using AntDesign;
using AntDesign.TableModels;
using ElectricBike.Application.Core.Services.Dto;
using ElectricBike.Infrastructure.Cross.ApiClient;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace ElectricBike.Web.Pages.Base;

public abstract class CustomComponentBase<TDto> : ComponentBase where TDto : DtoBase
{
    protected abstract string Title { get; set; }
    protected abstract string Description { get; set; }
    protected bool ModalVisible;
    protected bool Loading { get; private set; }
    [Inject] private NotificationService Notice { get; set; } = default!;
    protected Form<TDto> Form { get; set; } = null!;
    protected TDto NewItem { get; set; } = default!;
    protected List<TDto> Items { get; set; } = new ();
    
    protected readonly IDictionary<string, (bool edit, TDto data)> EditCache = new Dictionary<string, (bool edit, TDto data)>();

    protected ITable Table = null!;
    
    [Inject] protected IRestHttpClient RestHttpClient { get; set; } = default!;
    
    protected override async Task OnInitializedAsync() => await LoadAllItems();

    protected async Task LoadAllItems()
    {
        ToggleLoading(true);
        Items = (await RestHttpClient.GetAll<TDto>() ?? Array.Empty<TDto>()).ToList();
        EditCache.Clear();
        Items.ForEach(item => EditCache[item.Id.ToString()] = (false, item));
        await ShowInfoMessage("Se han cargado los registros existentes en la base de datos", $"({Items.Count}) elementos");
        ToggleLoading(false);
    }

    protected async Task OnChange(QueryModel<TDto> queryModel) =>         
        await ShowInfoMessage("Se han cargado los registros existentes en la base de datos", string.Empty);


    protected Task HandleCancelCreation(MouseEventArgs e)
    {
        ModalVisible = false;
        return Task.CompletedTask;
    }

    protected void OnFinish(EditContext editContext) => ModalVisible = false;

    protected async Task OnFinishFailed(EditContext editContext) => 
        await ShowErrorMessage("Error creando el registro", "Por favor verifique los datos he intente nuevamente");

    protected void ToggleLoading(bool value) => Loading = value;
    
    protected void NewElement()
    {
        NewItem = (TDto)Activator.CreateInstance(typeof(TDto))!;
        ModalVisible = true;
    }
    
    protected async Task HandleOk(MouseEventArgs e)
    {
        ToggleLoading(true);
        var response = await RestHttpClient.Create(Form.Model);
        if (response != null)
        {
            await ShowSuccessMessage("Registro creado con éxito", string.Empty);
            ModalVisible = false;
            await LoadAllItems();
        }
        else
            await ShowErrorMessage("Error creando el nuevo registro", string.Empty);
        ToggleLoading(false);
    }
    
    protected void StartEdit(Guid id)
    {
        var data = EditCache[id.ToString()];
        EditCache[id.ToString()] = (true, data.data);
    }

    protected async Task CancelEdit(Guid id)
    {
        await LoadAllItems();
        
        ToggleLoading(true);
        var data = Items.FirstOrDefault(item => item.Id == id);
        EditCache[id.ToString()] = (false, data)!;
        ToggleLoading(false);
    }
    
    protected async Task Delete(TDto dto)
    {
        ToggleLoading(true);
        Items.Remove(dto); 
        EditCache.Remove(dto.Id.ToString());
        var success = await RestHttpClient.Delete<TDto>(dto.Id);
        if (success)
            await ShowSuccessMessage("Registro eliminado con éxito", $"Id: {dto.Id}");
        else
            await ShowErrorMessage("Error actualizando el registro", $"Id: {dto.Id}");
        ToggleLoading(false);
    }

    protected async Task SaveEdit(Guid id)
    {
        ToggleLoading(true);
        var index = Items.FindIndex(item => item.Id == id);
        Items[index] = EditCache[id.ToString()].data;
        var success = await RestHttpClient.Put(Items[index]);
        if (success)
        {
            await ShowSuccessMessage("Registro actualizado con éxito", $"Id: {id}");
            EditCache[id.ToString()] = (false, Items[index]);
        }
        else
            await ShowErrorMessage("Error actualizando el registro", $"Id: {id}");
        ToggleLoading(false);
    }
    
    private async Task NoticeWithIcon(NotificationType type, string title, string message) =>
        await Notice.Open(new NotificationConfig
        {
            Message = title,
            Description = message,
            NotificationType = type
        });

    protected async Task ShowSuccessMessage(string title, string message)
    {
        await NoticeWithIcon(NotificationType.Success, title, message);
    }

    protected async Task ShowInfoMessage(string title, string message)
    {
        await NoticeWithIcon(NotificationType.Info,  title, message);
    }

    protected async Task ShoWarningMessage(string title, string message)
    {
        await NoticeWithIcon(NotificationType.Warning,  title, message);
    }

    protected async Task ShowErrorMessage(string title, string message)
    {
        await NoticeWithIcon(NotificationType.Error,  title, message);
    }
}