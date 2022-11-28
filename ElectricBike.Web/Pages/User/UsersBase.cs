using ElectricBike.Application.Core.Services.Persons;
using ElectricBike.Application.Core.Services.Users;
using ElectricBike.Web.Pages.Base;

namespace ElectricBike.Web.Pages.User;

public class UsersBase : CustomComponentBase<UserDto>
{
    protected override string Title { get; set; } = "Usuarios";
    protected override string Description { get; set; } = "Creación, edición, eliminación, consulta";
    
    protected List<PersonDto> Persons = new ();
    
    protected override async Task OnInitializedAsync()
    {
        ToggleLoading(true);
        Persons = (await RestHttpClient.GetAll<PersonDto>() ?? Array.Empty<PersonDto>()).ToList();
        ToggleLoading(false);
        await base.OnInitializedAsync();
    }
    
    protected void OnSelectedItemChangedHandler(PersonDto value)
    {
        NewItem.PersonId = value.Id;
        NewItem.Person = value;
    }
    
    protected override async Task SaveEdit(Guid id)
    {
        ToggleLoading(true);
        var index = Items.FindIndex(item => item.Id == id);
        EditCache[id.ToString()].data.Person = NewItem.Person;
        EditCache[id.ToString()].data.PersonId = NewItem.PersonId;

        Items[index] = EditCache[id.ToString()].data;
        
        await base.SaveEdit(id);
        ToggleLoading(false);
    }
}