using ElectricBike.Application.Core.Services.Persons;
using ElectricBike.Web.Pages.Base;

namespace ElectricBike.Web.Pages.Person;

public class PersonsBase : CustomComponentBase<PersonDto>
{
    protected override string Title { get; set; } = "Clientes";
    protected override string Description { get; set; } = "Creación, edición, eliminación, consulta";
}