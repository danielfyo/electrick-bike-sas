using AntDesign;
using ElectricBike.Application.Core.Services.Dto;
using ElectricBike.Infrastructure.Cross.ApiClient;
using Microsoft.AspNetCore.Components;

namespace ElectricBike.Web.Pages.Base;

public abstract class CustomComponentBase<TDto> : ComponentBase where TDto : DtoBase
{
    protected abstract string Title { get; set; }
    protected abstract string Description { get; set; }
    [Inject] private NotificationService Notice { get; set; } = default!;
    protected Form<TDto> Form { get; set; }
    
    protected List<TDto> Items { get; set; } = new ();
    protected readonly IDictionary<string, (bool edit, TDto data)> EditCache = new Dictionary<string, (bool edit, TDto data)>();

    [Inject] protected IRestHttpClient RestHttpClient { get; set; } = default!;
    
    protected override async Task OnInitializedAsync()
    {
        Items = (await RestHttpClient.GetAll<TDto>() ?? Array.Empty<TDto>()).ToList();
        await ShowInfoMessage("Se han cargado los registros existentes en la base de datos", $"({Items.Count}) elementos");
        Items.ForEach(item => EditCache[item.Id.ToString()] = (false, item));
    }
    
    protected void StartEdit(Guid id)
    {
        var data = EditCache[id.ToString()];
        EditCache[id.ToString()] = (true, data.data); // add a copy in cache
    }

    protected void CancelEdit(Guid id)
    {
        var data = Items.FirstOrDefault(item => item.Id == id);
        EditCache[id.ToString()] = (false, data)!; // recovery
    }
    
    protected async Task Delete(Guid id)
    {
        var index = Items.FindIndex(item => item.Id == id);
        Items[index] = EditCache[id.ToString()].data;
        var success = await RestHttpClient.Delete<TDto>(id);
        if (success)
        {
            await ShowSuccessMessage("Registro eliminado con éxito", $"Id: {id}");
            EditCache.Remove(id.ToString());
        } 
        else
            await ShowErrorMessage("Error actualizando el registro", $"Id: {id}");
        
    }

    protected async Task SaveEdit(Guid id)
    {
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