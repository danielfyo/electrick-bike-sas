using AutoMapper;
using ElectricBike.Domain.Core.PurchaseIntentions;

namespace ElectricBike.Application.Core.Services.PurchaseIntentions;

public class PurchaseIntentionMapperProfile  : Profile
{
    public PurchaseIntentionMapperProfile()
    {
        CreateMap<PurchaseIntention, PurchaseIntentionDto>().ReverseMap();
    }
}