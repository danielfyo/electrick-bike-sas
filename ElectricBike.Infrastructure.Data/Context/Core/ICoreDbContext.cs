using ElectricBike.Domain.Core.Entities;
using ElectricBike.Infrastructure.Data.Context.Base;
using Microsoft.EntityFrameworkCore;

namespace ElectricBike.Infrastructure.Data.Context.Core
{
    public interface ICoreDbContext : IDbContextBase
    {
        DbSet<Bicycle> Bicycles { get; set; }
        
        DbSet<EngineSupplier> EngineSuppliers { get; set; }
        
        DbSet<Manufacturer> Manufacturers { get; set; }
        
        DbSet<Motorcycle> Motorcycles { get; set; }
        
        DbSet<Person> Persons { get; set; }

        DbSet<ProductOfInterest> ProductOfInterests { get; set; }

        DbSet<PurchaseIntention> PurchaseIntentions { get; set; }
        
        DbSet<User> Users { get; set; }
    }
}

