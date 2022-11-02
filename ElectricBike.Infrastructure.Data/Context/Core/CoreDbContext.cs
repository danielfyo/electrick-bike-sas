using ElectricBike.Domain.Core.Entities;
using ElectricBike.Infrastructure.Data.Context.Base;
using Microsoft.EntityFrameworkCore;

namespace ElectricBike.Infrastructure.Data.Context.Core
{
    public class CoreDbContext : DbContextBase, ICoreDbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }

        public virtual DbSet<Bicycle> Bicycles { get; set; }
        
        public virtual DbSet<EngineSupplier> EngineSuppliers { get; set; }
        
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        
        public virtual DbSet<Motorcycle> Motorcycles { get; set; }
        
        public virtual DbSet<Person> Persons { get; set; }
        
        public virtual DbSet<ProductOfInterest> ProductOfInterests { get; set; }

        public virtual DbSet<PurchaseIntention> PurchaseIntentions { get; set; }
        
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region Unique Keys
            //modelBuilder.Entity<Usuario>().HasIndex(x => x.Username).HasDatabaseName("UniqueKey_Usuario_Username").IsUnique();
            //modelBuilder.Entity<Persona>().HasIndex(x => x.Identificacion).HasDatabaseName("UniqueKey_Persona_Identificacion").IsUnique();
            //modelBuilder.Entity<Vehiculo>().HasIndex(x => x.Placa).HasDatabaseName("UniqueKey_Vehiculo_Placa").IsUnique();
            #endregion

            //base.OnModelCreating(modelBuilder);
        }
    }
}