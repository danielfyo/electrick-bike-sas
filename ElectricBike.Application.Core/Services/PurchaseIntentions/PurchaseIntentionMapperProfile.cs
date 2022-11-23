using AutoMapper;
using ElectricBike.Application.Core.Services.EngineSuppliers;

namespace ElectricBike.Application.Core.Services.PurchaseIntentions;

public class PurchaseIntentionMapperProfile  : Profile
{
    public PurchaseIntentionMapperProfile()
    {
        CreateMap<Domain.Core.EngineSuppliers.EngineSupplier, EngineSupplierDto>().ReverseMap();
    }
}