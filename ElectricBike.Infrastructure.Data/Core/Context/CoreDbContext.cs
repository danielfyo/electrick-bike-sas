using ElectricBike.Domain.Core.Bicycles;
using ElectricBike.Domain.Core.EngineSuppliers;
using ElectricBike.Domain.Core.Manufacturers;
using ElectricBike.Domain.Core.Motorcycles;
using ElectricBike.Domain.Core.Persons;
using ElectricBike.Domain.Core.PurchaseIntentions;
using ElectricBike.Domain.Core.Users;
using ElectricBike.Infrastructure.Data.Context.Base;
using Microsoft.EntityFrameworkCore;

namespace ElectricBike.Infrastructure.Data.Core.Context
{
    public class CoreDbContext : DbContextBase, ICoreDbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }

        public virtual DbSet<Bicycle> Bicycles { get; set; } = null!;

        public virtual DbSet<EngineSupplier> EngineSuppliers { get; set; } = null!;

        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;

        public virtual DbSet<Motorcycle> Motorcycles { get; set; } = null!;

        public virtual DbSet<Person> Persons { get; set; } = null!;

        public virtual DbSet<ProductOfInterest> ProductOfInterests { get; set; } = null!;

        public virtual DbSet<PurchaseIntention> PurchaseIntentions { get; set; } = null!;

        public virtual DbSet<User> Users { get; set; } = null!;
    }
}